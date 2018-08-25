using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace DefaultEcs.Technical.Serialization.BinarySerializer
{
    internal static unsafe class Converter<T>
    {
        #region Types

        private delegate void WriteAction(in T value, Stream stream, byte[] buffer, byte* bufferP);
        private delegate T ReadAction(Stream stream, byte[] buffer, byte* bufferP);

        #endregion

        #region Fields

        private static readonly WriteAction _writeAction;
        private static readonly ReadAction _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {

            if (typeof(T) == typeof(string))
            {
                _writeAction = (WriteAction)new Converter<string>.WriteAction(StringConverter.Write);
                _readAction = (ReadAction)new Converter<string>.ReadAction(StringConverter.Read);
            }
            else if (typeof(T).GetTypeInfo().IsArray)
            {
                Type elementType = typeof(T).GetTypeInfo().GetElementType();

                _writeAction = (WriteAction)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(WriteArray)).CreateDelegate(typeof(WriteAction));
                _readAction = (ReadAction)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(ReadArray)).CreateDelegate(typeof(ReadAction));
            }
            else if (!typeof(T).GetTypeInfo().IsValueType)
            {
                DynamicMethod writeMethod = new DynamicMethod($"Write_{nameof(T)}", typeof(void), new[] { typeof(T).MakeByRefType(), typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
                ILGenerator writeGenerator = writeMethod.GetILGenerator();

                DynamicMethod readMethod = new DynamicMethod($"Read_{nameof(T)}", typeof(T), new[] { typeof(Stream), typeof(byte[]), typeof(byte*) }, typeof(Converter<T>), true);
                ILGenerator readGenerator = readMethod.GetILGenerator();
                LocalBuilder readValue = readGenerator.DeclareLocal(typeof(T));
                readGenerator.Emit(OpCodes.Call, typeof(Activator).GetTypeInfo().GetDeclaredMethods(nameof(Activator.CreateInstance)).First(m => m.GetParameters().Length == 0).MakeGenericMethod(typeof(T)));
                readGenerator.Emit(OpCodes.Stloc, readValue);

                foreach (FieldInfo fieldInfo in typeof(T).GetTypeInfo().DeclaredFields.Where(f => !f.IsStatic))
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

                writeGenerator.Emit(OpCodes.Ret);
                _writeAction = (WriteAction)writeMethod.CreateDelegate(typeof(WriteAction));

                readGenerator.Emit(OpCodes.Ldloc, readValue);
                readGenerator.Emit(OpCodes.Ret);
                _readAction = (ReadAction)readMethod.CreateDelegate(typeof(ReadAction));
            }
            else
            {
                try
                {
                    TypeInfo unmanagedType = typeof(UnmanagedConverter<>).MakeGenericType(typeof(T)).GetTypeInfo();

                    _writeAction = (WriteAction)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Write)).CreateDelegate(typeof(WriteAction));
                    _readAction = (ReadAction)unmanagedType.GetDeclaredMethod(nameof(UnmanagedConverter<bool>.Read)).CreateDelegate(typeof(ReadAction));
                }
                catch
                {
                    _writeAction = (in T _, Stream __, byte[] ___, byte* ____) => throw new InvalidOperationException($"Unable to handle type {typeof(T).FullName}");
                    _readAction = (_, __, ___) => throw new InvalidOperationException($"Unable to handle type {typeof(T).FullName}");
                }
            }
        }

        #endregion

        #region Methods

        public static void WriteArray(in T[] values, Stream stream, byte[] buffer, byte* bufferP)
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

        public static void Write(in T value, Stream stream, byte[] buffer, byte* bufferP)
        {
            if (value == default)
            {
                stream.WriteByte(0);
            }
            else
            {
                stream.WriteByte(1);
                _writeAction(value, stream, buffer, bufferP);
            }
        }

        public static T[] ReadArray(Stream stream, byte[] buffer, byte* bufferP)
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

        public static T Read(Stream stream, byte[] buffer, byte* bufferP) => stream.ReadByte() > 0 ? _readAction(stream, buffer, bufferP) : default;

        #endregion
    }
}
