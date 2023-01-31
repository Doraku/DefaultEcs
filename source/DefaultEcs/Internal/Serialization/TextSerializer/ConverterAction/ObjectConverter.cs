using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace DefaultEcs.Internal.Serialization.TextSerializer.ConverterAction
{
    internal static class ObjectConverter<T>
    {
        #region Types

        private delegate void ReadFieldAction(StreamReaderWrapper reader, ref T value);

        #endregion

        private const string _objectBegin = "{";
        private const string _objectEnd = "}";

        private static readonly bool _isValue;
        private static readonly Dictionary<string, ReadFieldAction> _readFieldActions;
        private static readonly WriteAction<T> _writeAction;

        static ObjectConverter()
        {
            static string GetFriendlyName(string name)
            {
                Match match = Regex.Match(name, "^<(.+)>k__BackingField$");
                if (match.Success)
                {
                    name = match.Groups[1].Value;
                }
                return name.Trim('_');
            }

            TypeInfo typeInfo = typeof(T).GetTypeInfo();

            _isValue = typeInfo.IsValueType;
            _readFieldActions = new Dictionary<string, ReadFieldAction>();

            MethodInfo addIndentation = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.AddIndentation));
            MethodInfo removeIndentation = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.RemoveIndentation));
            MethodInfo writeIndentation = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.WriteIndentation));
            MethodInfo writeSpace = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.WriteSpace));
            MethodInfo writeLine = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.WriteLine));
            MethodInfo write = typeof(StreamWriterWrapper).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWrapper.Write));

            ParameterExpression writer = Expression.Parameter(typeof(StreamWriterWrapper));
            ParameterExpression value = Expression.Parameter(typeof(T).MakeByRefType());

            List<Expression> writeExpressions = new()
            {
                Expression.Call(writer, writeLine, Expression.Constant(_objectBegin)),
                Expression.Call(writer, addIndentation),
            };

            while (typeInfo != null)
            {
                foreach (FieldInfo fieldInfo in typeInfo.DeclaredFields.Where(f => !f.IsStatic))
                {
                    string name = GetFriendlyName(fieldInfo.Name);
                    Expression writeField = Expression.Block(
                        Expression.Call(writer, writeIndentation),
                        Expression.Call(writer, write, Expression.Constant(name)),
                        Expression.Call(writer, writeSpace),
                        Expression.Call(
                            typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<string>.Write)),
                            writer,
                            Expression.Field(value, fieldInfo)));

                    if (!fieldInfo.FieldType.GetTypeInfo().IsValueType)
                    {
                        writeField = Expression.IfThen(
                            Expression.Not(Expression.ReferenceEqual(Expression.Field(value, fieldInfo), Expression.Default(fieldInfo.FieldType))),
                            writeField);
                    }

                    writeExpressions.Add(writeField);

                    DynamicMethod readMethod = new($"Set_{typeof(T)}_{fieldInfo.Name}", typeof(void), new[] { typeof(StreamReaderWrapper), typeof(T).MakeByRefType() }, typeof(ObjectConverter<T>), true);
                    ILGenerator readGenerator = readMethod.GetILGenerator();
                    readGenerator.Emit(OpCodes.Ldarg_1);
                    if (!typeInfo.IsValueType)
                    {
                        readGenerator.Emit(OpCodes.Ldind_Ref);
                    }
                    readGenerator.Emit(OpCodes.Ldarg_0);
                    readGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Read)));
                    readGenerator.Emit(OpCodes.Stfld, fieldInfo);
                    readGenerator.Emit(OpCodes.Ret);

                    _readFieldActions.Add(name, (ReadFieldAction)readMethod.CreateDelegate(typeof(ReadFieldAction)));
                }

                typeInfo = typeInfo.BaseType?.GetTypeInfo();
            }

            writeExpressions.Add(Expression.Call(writer, removeIndentation));
            writeExpressions.Add(Expression.Call(writer, writeIndentation));
            writeExpressions.Add(Expression.Call(writer, writeLine, Expression.Constant(_objectEnd)));

            _writeAction = Expression.Lambda<WriteAction<T>>(Expression.Block(writeExpressions), writer, value).Compile();
        }

        private static T Read(StreamReaderWrapper reader)
        {
            if (!reader.TryReadUntil(_objectBegin))
            {
                StreamReaderWrapper.Throw<T[]>();
            }

            T value = _isValue ? default : ObjectInitializer<T>.Create();

            while (!reader.EndOfStream && !reader.TryPeek(_objectEnd))
            {
                if (_readFieldActions.TryGetValue(
#if NETSTANDARD2_1_OR_GREATER
                    reader.Read().ToString(),
#else
                    reader.Read(),
#endif
                    out ReadFieldAction action))
                {
                    action(reader, ref value);
                }
                else
                {
                    // todo cleanup object/array?
                }
            }

            reader.Read();

            return value;
        }

        public static (WriteAction<T>, ReadAction<T>) GetActions() => (_writeAction, Read);
    }
}
