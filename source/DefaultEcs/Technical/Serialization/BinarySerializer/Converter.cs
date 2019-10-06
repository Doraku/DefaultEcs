using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static class Converter
    {
        #region Types

        private interface IReadActionWrapper
        {
            ReadAction<T> Get<T>();
        }

        private class ClassReadActionWrapper : IReadActionWrapper
        {
            private readonly Delegate _readAction;

            public ClassReadActionWrapper(Delegate readAction)
            {
                _readAction = readAction;
            }

            public ReadAction<T> Get<T>() => (ReadAction<T>)_readAction;
        }

        private class StructReadActionWrapper<TReal> : IReadActionWrapper
        {
            private readonly ReadAction<TReal> _readAction;

            public StructReadActionWrapper(Delegate readAction)
            {
                _readAction = (ReadAction<TReal>)readAction;
            }

            public ReadAction<T> Get<T>()
            {
                if (typeof(TReal) == typeof(T))
                {
                    return (ReadAction<T>)(Delegate)_readAction;
                }

                return (in StreamReaderWrapper r) => (T)(object)_readAction(r);
            }
        }

        public delegate void WriteAction<T>(in T value, in StreamWriterWrapper writer);
        public delegate T ReadAction<out T>(in StreamReaderWrapper reader);

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<string, WriteAction<object>> _writeActions = new ConcurrentDictionary<string, WriteAction<object>>();
        private static readonly ConcurrentDictionary<string, IReadActionWrapper> _readActions = new ConcurrentDictionary<string, IReadActionWrapper>();

        #endregion

        #region Methods

        public static WriteAction<object> GetWriteAction(string typeName)
        {
            if (!_writeActions.TryGetValue(typeName, out WriteAction<object> writeAction))
            {
                lock (_writeActions)
                {
                    if (!_writeActions.ContainsKey(typeName))
                    {
                        writeAction = (WriteAction<object>)typeof(Converter<>).MakeGenericType(Type.GetType(typeName, true)).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.WrapperWrite))
                            .CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(typeName, writeAction, (_, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(string typeName)
        {
            if (!_readActions.TryGetValue(typeName, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(typeName))
                    {
                        Type type = Type.GetType(typeName, true);
                        TypeInfo typeInfo = type.GetTypeInfo();

                        Delegate action = typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.Read))
                            .CreateDelegate(typeof(ReadAction<>).MakeGenericType(type));

                        if (!typeInfo.IsValueType || type == typeof(T))
                        {
                            readAction = typeInfo.IsValueType ? (IReadActionWrapper)new StructReadActionWrapper<T>(action) : new ClassReadActionWrapper(action);
                        }
                        else
                        {
                            readAction = (IReadActionWrapper)Activator.CreateInstance(typeof(StructReadActionWrapper<>).MakeGenericType(type), action);
                        }

                        _readActions.AddOrUpdate(typeName, readAction, (_, d) => d);
                    }
                }
            }

            return readAction.Get<T>();
        }

        #endregion
    }

    internal static class Converter<T>
    {
        #region Fields

        private static readonly Type _type;
        private static readonly Converter.WriteAction<T> _writeAction;
        private static readonly Converter.ReadAction<T> _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            _type = typeof(T);
            TypeInfo typeInfo = _type.GetTypeInfo();

            if (_type == typeof(string))
            {
                _writeAction = (Converter.WriteAction<T>)(Delegate)new Converter.WriteAction<string>(StringConverter.Write);
                _readAction = (Converter.ReadAction<T>)(Delegate)new Converter.ReadAction<string>(StringConverter.Read);
            }
            else if (typeInfo.IsArray)
            {
                Type elementType = typeInfo.GetElementType();

                _writeAction = (Converter.WriteAction<T>)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(WriteArray)).CreateDelegate(typeof(Converter.WriteAction<T>));
                _readAction = (Converter.ReadAction<T>)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(ReadArray)).CreateDelegate(typeof(Converter.ReadAction<T>));
            }
            else
            {
                try
                {
                    if (typeInfo.IsUnmanaged())
                    {
                        TypeInfo unmanagedType = typeof(UnmanagedConverter<>).MakeGenericType(_type).GetTypeInfo();

                        _writeAction = (Converter.WriteAction<T>)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Write)).CreateDelegate(typeof(Converter.WriteAction<T>));
                        _readAction = (Converter.ReadAction<T>)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Read)).CreateDelegate(typeof(Converter.ReadAction<T>));
                    }
                    else
                    {
                        DynamicMethod writeMethod = new DynamicMethod($"Write_{nameof(T)}", typeof(void), new[] { _type.MakeByRefType(), typeof(StreamWriterWrapper).MakeByRefType() }, typeof(Converter<T>), true);
                        ILGenerator writeGenerator = writeMethod.GetILGenerator();

                        DynamicMethod readMethod = new DynamicMethod($"Read_{nameof(T)}", _type, new[] { typeof(StreamReaderWrapper).MakeByRefType() }, typeof(Converter<T>), true);
                        ILGenerator readGenerator = readMethod.GetILGenerator();
                        LocalBuilder readValue = readGenerator.DeclareLocal(_type);

                        if (typeInfo.IsClass)
                        {
                            readGenerator.Emit(OpCodes.Ldsfld, typeof(Converter<T>).GetTypeInfo().GetDeclaredField(nameof(_type)));
                            readGenerator.Emit(OpCodes.Call, typeof(ObjectInitializer).GetTypeInfo().GetDeclaredMethod(nameof(ObjectInitializer.Create)));
                            readGenerator.Emit(OpCodes.Stloc, readValue);
                        }
                        else
                        {
                            readGenerator.Emit(OpCodes.Ldloca_S, readValue);
                            readGenerator.Emit(OpCodes.Initobj, _type);
                        }

                        while (typeInfo != null)
                        {
                            foreach (FieldInfo fieldInfo in typeInfo.DeclaredFields.Where(f => !f.IsStatic))
                            {
                                writeGenerator.Emit(OpCodes.Ldarg_0);
                                if (typeInfo.IsClass)
                                {
                                    writeGenerator.Emit(OpCodes.Ldind_Ref);
                                }
                                writeGenerator.Emit(OpCodes.Ldflda, fieldInfo);
                                writeGenerator.Emit(OpCodes.Ldarg_1);
                                writeGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Write)));

                                readGenerator.Emit(typeInfo.IsClass ? OpCodes.Ldloc : OpCodes.Ldloca_S, readValue);
                                readGenerator.Emit(OpCodes.Ldarg_0);
                                readGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Read)));
                                readGenerator.Emit(OpCodes.Stfld, fieldInfo);
                            }

                            typeInfo = typeInfo.BaseType?.GetTypeInfo();
                        }

                        writeGenerator.Emit(OpCodes.Ret);
                        _writeAction = (Converter.WriteAction<T>)writeMethod.CreateDelegate(typeof(Converter.WriteAction<T>));

                        readGenerator.Emit(OpCodes.Ldloc, readValue);
                        readGenerator.Emit(OpCodes.Ret);
                        _readAction = (Converter.ReadAction<T>)readMethod.CreateDelegate(typeof(Converter.ReadAction<T>));
                    }
                }
                catch (Exception exception)
                {
                    _writeAction = (in T _, in StreamWriterWrapper __) => throw new InvalidOperationException($"Unable to handle type {_type.FullName}", exception);
                    _readAction = (in StreamReaderWrapper _) => throw new InvalidOperationException($"Unable to handle type {_type.FullName}", exception);
                }
            }
        }

        #endregion

        #region Methods

        private static void WriteArray(in T[] values, in StreamWriterWrapper writer)
        {
            writer.Write(values.Length);

            for (int i = 0; i < values.Length; ++i)
            {
                Write(values[i], writer);
            }
        }

        private static T[] ReadArray(in StreamReaderWrapper reader)
        {
            T[] values = new T[reader.Read<int>()];

            for (int i = 0; i < values.Length; ++i)
            {
                values[i] = Read(reader);
            }

            return values;
        }

        public static void Write(in T value, in StreamWriterWrapper writer)
        {
            if (value == default)
            {
                writer.WriteByte(0);
            }
            else if (_type == value.GetType())
            {
                writer.WriteByte(1);
                _writeAction(value, writer);
            }
            else
            {
                writer.WriteByte(2);
                string typeName = value.GetType().AssemblyQualifiedName;
                writer.WriteString(typeName);
                Converter.GetWriteAction(typeName)(value, writer);
            }
        }

        public static T Read(in StreamReaderWrapper reader)
        {
            return (reader.ReadByte()) switch
            {
                0 => default,
                1 => _readAction(reader),
                _ => Converter.GetReadAction<T>(reader.ReadString())(reader),
            };
        }

        public static void WrapperWrite(in object value, in StreamWriterWrapper writer) => Write((T)value, writer);

        #endregion
    }
}
