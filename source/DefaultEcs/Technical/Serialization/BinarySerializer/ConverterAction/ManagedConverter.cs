using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace DefaultEcs.Technical.Serialization.BinarySerializer.ConverterAction
{
    internal static class ManagedConverter
    {
        public static (WriteAction<T>, ReadAction<T>) GetActions<T>()
        {
            Type type = typeof(T);
            TypeInfo typeInfo = type.GetTypeInfo();

            DynamicMethod writeMethod = new DynamicMethod($"Write_{nameof(T)}", typeof(void), new[] { typeof(StreamWriterWrapper).MakeByRefType(), type.MakeByRefType() }, typeof(ManagedConverter), true);
            ILGenerator writeGenerator = writeMethod.GetILGenerator();

            DynamicMethod readMethod = new DynamicMethod($"Read_{nameof(T)}", type, new[] { typeof(StreamReaderWrapper).MakeByRefType() }, typeof(ManagedConverter), true);
            ILGenerator readGenerator = readMethod.GetILGenerator();
            LocalBuilder readValue = readGenerator.DeclareLocal(type);

            if (typeInfo.IsClass)
            {
                readGenerator.Emit(OpCodes.Ldtoken, type);
                readGenerator.Emit(OpCodes.Call, typeof(ObjectInitializer).GetTypeInfo().GetDeclaredMethod(nameof(ObjectInitializer.Create)));
                readGenerator.Emit(OpCodes.Stloc, readValue);
            }
            else
            {
                readGenerator.Emit(OpCodes.Ldloca_S, readValue);
                readGenerator.Emit(OpCodes.Initobj, type);
            }

            while (typeInfo != null)
            {
                foreach (FieldInfo fieldInfo in typeInfo.DeclaredFields.Where(f => !f.IsStatic))
                {
                    writeGenerator.Emit(OpCodes.Ldarg_0);
                    writeGenerator.Emit(OpCodes.Ldarg_1);
                    if (typeInfo.IsClass)
                    {
                        writeGenerator.Emit(OpCodes.Ldind_Ref);
                    }
                    writeGenerator.Emit(OpCodes.Ldflda, fieldInfo);
                    writeGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Write)));

                    readGenerator.Emit(typeInfo.IsClass ? OpCodes.Ldloc : OpCodes.Ldloca_S, readValue);
                    readGenerator.Emit(OpCodes.Ldarg_0);
                    readGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Read)));
                    readGenerator.Emit(OpCodes.Stfld, fieldInfo);
                }

                typeInfo = typeInfo.BaseType?.GetTypeInfo();
            }

            writeGenerator.Emit(OpCodes.Ret);

            readGenerator.Emit(OpCodes.Ldloc, readValue);
            readGenerator.Emit(OpCodes.Ret);

            return ((WriteAction<T>)writeMethod.CreateDelegate(typeof(WriteAction<T>)), (ReadAction<T>)readMethod.CreateDelegate(typeof(ReadAction<T>)));
        }
    }
}
