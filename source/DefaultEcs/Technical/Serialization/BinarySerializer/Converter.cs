using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static unsafe class Converter
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

                return (s, b, p) => (T)(object)_readAction(s, b, p);
            }
        }

        public delegate void WriteAction<T>(in T value, Stream stream, byte[] buffer, byte* bufferP);
        public delegate T ReadAction<out T>(Stream stream, byte[] buffer, byte* bufferP);

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

    internal static unsafe class Converter<T>
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
                        DynamicMethod writeMethod = new DynamicMethod($"Write_{nameof(T)}", typeof(void), new[] { _type.MakeByRefType(), typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
                        ILGenerator writeGenerator = writeMethod.GetILGenerator();

                        DynamicMethod readMethod = new DynamicMethod($"Read_{nameof(T)}", _type, new[] { typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
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
                                writeGenerator.Emit(OpCodes.Ldarg_2);
                                writeGenerator.Emit(OpCodes.Ldarg_3);
                                writeGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Write)));

                                readGenerator.Emit(typeInfo.IsClass ? OpCodes.Ldloc : OpCodes.Ldloca_S, readValue);
                                readGenerator.Emit(OpCodes.Ldarg_0);
                                readGenerator.Emit(OpCodes.Ldarg_1);
                                readGenerator.Emit(OpCodes.Ldarg_2);
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
                catch
                {
                    _writeAction = (in T _, Stream __, byte[] ___, byte* ____) => throw new InvalidOperationException($"Unable to handle type {_type.FullName}");
                    _readAction = (_, __, ___) => throw new InvalidOperationException($"Unable to handle type {_type.FullName}");
                }
            }
        }

        #endregion

        #region Methods

        private static void WriteArray(in T[] values, Stream stream, byte[] buffer, byte* bufferP)
        {
            *(int*)bufferP = values?.Length ?? -1;
            stream.Write(buffer, 0, sizeof(int));

            if (values != null)
            {
                for (int i = 0; i < values.Length; ++i)
                {
                    Write(values[i], stream, buffer, bufferP);
                }
            }
        }

        private static T[] ReadArray(Stream stream, byte[] buffer, byte* bufferP)
        {
            T[] values = default;

            if (stream.Read(buffer, 0, sizeof(int)) == sizeof(int))
            {
                int length = *(int*)bufferP;
                if (length >= 0)
                {
                    values = new T[length];

                    for (int i = 0; i < values.Length; ++i)
                    {
                        values[i] = Read(stream, buffer, bufferP);
                    }
                }
            }
            else
            {
                throw new EndOfStreamException($"Could not deserialize type {typeof(T[]).FullName}");
            }

            return values;
        }

        public static void Write(in T value, Stream stream, byte[] buffer, byte* bufferP)
        {
            if (value == default)
            {
                stream.WriteByte(0);
            }
            else if (_type == value.GetType())
            {
                stream.WriteByte(1);
                _writeAction(value, stream, buffer, bufferP);
            }
            else
            {
                stream.WriteByte(2);
                string typeName = value.GetType().AssemblyQualifiedName;
                StringConverter.Write(typeName, stream, buffer, bufferP);
                Converter.GetWriteAction(typeName)(value, stream, buffer, bufferP);
            }
        }

        public static T Read(Stream stream, byte[] buffer, byte* bufferP)
        {
            switch (stream.ReadByte())
            {
                case 0:
                    return default;

                case 1:
                    return _readAction(stream, buffer, bufferP);

                default:
                    return Converter.GetReadAction<T>(StringConverter.Read(stream, buffer, bufferP))(stream, buffer, bufferP);
            }
        }

        public static void WrapperWrite(in object value, Stream stream, byte[] buffer, byte* bufferP) => Write((T)value, stream, buffer, bufferP);

        #endregion
    }
}
