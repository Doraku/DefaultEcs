using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static unsafe class Converter
    {
        #region Types

        public delegate void WriteAction<T>(in T value, Stream stream, byte[] buffer, byte* bufferP);
        public delegate T ReadAction<out T>(Stream stream, byte[] buffer, byte* bufferP);

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<string, WriteAction<object>> _writeActions = new ConcurrentDictionary<string, WriteAction<object>>();
        private static readonly ConcurrentDictionary<string, Delegate> _readActions = new ConcurrentDictionary<string, Delegate>();

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
                        Type type = Type.GetType(typeName, true);

                        DynamicMethod writeMethod = new DynamicMethod($"Write_{typeName}", typeof(void), new[] { typeof(object).MakeByRefType(), typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter), true);
                        ILGenerator writeGenerator = writeMethod.GetILGenerator();

                        writeGenerator.Emit(OpCodes.Ldarg_0);
                        writeGenerator.Emit(OpCodes.Ldarg_1);
                        writeGenerator.Emit(OpCodes.Ldarg_2);
                        writeGenerator.Emit(OpCodes.Ldarg_3);
                        writeGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(type).GetTypeInfo().GetDeclaredMethod(nameof(Converter<string>.Write)));
                        writeGenerator.Emit(OpCodes.Ret);

                        writeAction = (WriteAction<object>)writeMethod.CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(typeName, writeAction, (t, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(string typeName)
        {
            if (!_readActions.TryGetValue(typeName, out Delegate readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(typeName))
                    {
                        Type type = Type.GetType(typeName, true);

                        readAction = typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.Read))
                            .CreateDelegate(typeof(ReadAction<>).MakeGenericType(type));

                        _readActions.AddOrUpdate(typeName, readAction, (t, d) => d);
                    }
                }
            }

            return (ReadAction<T>)readAction;
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
                    TypeInfo unmanagedType = typeof(UnmanagedConverter<>).MakeGenericType(_type).GetTypeInfo();

                    _writeAction = (Converter.WriteAction<T>)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Write)).CreateDelegate(typeof(Converter.WriteAction<T>));
                    _readAction = (Converter.ReadAction<T>)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Read)).CreateDelegate(typeof(Converter.ReadAction<T>));

                    return;
                }
                catch { }

                try
                {
                    DynamicMethod writeMethod = new DynamicMethod($"Write_{nameof(T)}", typeof(void), new[] { _type.MakeByRefType(), typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
                    ILGenerator writeGenerator = writeMethod.GetILGenerator();

                    DynamicMethod readMethod = new DynamicMethod($"Read_{nameof(T)}", _type, new[] { typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
                    ILGenerator readGenerator = readMethod.GetILGenerator();
                    LocalBuilder readValue = readGenerator.DeclareLocal(_type);

                    readGenerator.Emit(OpCodes.Ldsfld, typeof(Converter<T>).GetTypeInfo().GetDeclaredField(nameof(_type)));
                    if (!typeInfo.IsValueType)
                    {
                        readGenerator.Emit(OpCodes.Call, typeof(ObjectInitializer).GetTypeInfo().GetDeclaredMethod(nameof(ObjectInitializer.Create)));
                        readGenerator.Emit(OpCodes.Castclass, _type);
                        readGenerator.Emit(OpCodes.Stloc, readValue);
                    }

                    while (typeInfo != null)
                    {
                        foreach (FieldInfo fieldInfo in typeInfo.DeclaredFields.Where(f => !f.IsStatic))
                        {
                            writeGenerator.Emit(OpCodes.Ldarg_0);
                            writeGenerator.Emit(OpCodes.Ldind_Ref);
                            writeGenerator.Emit(OpCodes.Ldflda, fieldInfo);
                            writeGenerator.Emit(OpCodes.Ldarg_1);
                            writeGenerator.Emit(OpCodes.Ldarg_2);
                            writeGenerator.Emit(OpCodes.Ldarg_3);
                            writeGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Write)));

                            readGenerator.Emit(OpCodes.Ldloc, readValue);
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
                Converter<string>.Write(typeName, stream, buffer, bufferP);
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
                    return Converter.GetReadAction<T>(Converter<string>.Read(stream, buffer, bufferP))(stream, buffer, bufferP);
            }
        }

        #endregion
    }
}
