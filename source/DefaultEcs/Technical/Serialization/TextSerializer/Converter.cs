using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace DefaultEcs.Technical.Serialization.TextSerializer
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

                return (l, r) => (T)(object)_readAction(l, r);
            }
        }

        public delegate void WriteAction<T>(in T value, StreamWriter writer, int indentation);
        public delegate T ReadAction<out T>(string line, StreamReader reader);

        #endregion

        #region Fields

        private static readonly ConcurrentDictionary<Type, WriteAction<object>> _writeActions = new ConcurrentDictionary<Type, WriteAction<object>>();
        private static readonly ConcurrentDictionary<Type, IReadActionWrapper> _readActions = new ConcurrentDictionary<Type, IReadActionWrapper>();

        #endregion

        #region Methods

        public static ReadAction<T> ConvertRead<T>(Delegate readAction) => (ReadAction<T>)readAction;

        public static WriteAction<object> GetWriteAction(Type type)
        {
            if (!_writeActions.TryGetValue(type, out WriteAction<object> writeAction))
            {
                lock (_writeActions)
                {
                    if (!_writeActions.ContainsKey(type))
                    {
                        writeAction = (WriteAction<object>)typeof(Converter<>).MakeGenericType(type).GetTypeInfo()
                            .GetDeclaredMethod(nameof(Converter<string>.WrapperWrite))
                            .CreateDelegate(typeof(WriteAction<object>));

                        _writeActions.AddOrUpdate(type, writeAction, (_, d) => d);
                    }
                }
            }

            return writeAction;
        }

        public static ReadAction<T> GetReadAction<T>(Type type)
        {
            if (!_readActions.TryGetValue(type, out IReadActionWrapper readAction))
            {
                lock (_readActions)
                {
                    if (!_readActions.ContainsKey(type))
                    {
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

                        _readActions.AddOrUpdate(type, readAction, (_, d) => d);
                    }
                }
            }

            return readAction.Get<T>();
        }

        #endregion
    }

    internal static class Converter<T>
    {
        #region Types

        private delegate void ReadFieldAction(string line, StreamReader reader, ref T value);

        #endregion

        #region Fields

        private const string _objectBegin = "{";
        private const string _objectEnd = "}";
        private const string _arrayBegin = "[";
        private const string _arrayEnd = "]";

        private static readonly bool _isValue;
        private static readonly bool _isSealed;
        private static readonly char[] _split = new[] { ' ', '\t' };
        private static readonly Dictionary<string, ReadFieldAction> _readFieldActions;
        private static readonly Converter.WriteAction<T> _writeAction;
        private static readonly Converter.ReadAction<T> _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            TypeInfo typeInfo = typeof(T).GetTypeInfo();

            _isValue = typeInfo.IsValueType;
            _isSealed = typeInfo.IsSealed || typeof(T) == typeof(Type);

            _readFieldActions = new Dictionary<string, ReadFieldAction>();

            _writeAction = (in T v, StreamWriter w, int _) => w.WriteLine(v.ToString());

            #region clr types
            if (typeof(T) == typeof(bool))
            {
                _readAction = Converter.ConvertRead<T>(Converter<bool>.GetReadAction(bool.Parse));
            }
            else if (typeof(T) == typeof(sbyte))
            {
                _readAction = Converter.ConvertRead<T>(Converter<sbyte>.GetReadAction(sbyte.Parse));
            }
            else if (typeof(T) == typeof(byte))
            {
                _readAction = Converter.ConvertRead<T>(Converter<byte>.GetReadAction(byte.Parse));
            }
            else if (typeof(T) == typeof(short))
            {
                _readAction = Converter.ConvertRead<T>(Converter<short>.GetReadAction(short.Parse));
            }
            else if (typeof(T) == typeof(ushort))
            {
                _readAction = Converter.ConvertRead<T>(Converter<ushort>.GetReadAction(ushort.Parse));
            }
            else if (typeof(T) == typeof(int))
            {
                _readAction = Converter.ConvertRead<T>(Converter<int>.GetReadAction(int.Parse));
            }
            else if (typeof(T) == typeof(uint))
            {
                _readAction = Converter.ConvertRead<T>(Converter<uint>.GetReadAction(uint.Parse));
            }
            else if (typeof(T) == typeof(long))
            {
                _readAction = Converter.ConvertRead<T>(Converter<long>.GetReadAction(long.Parse));
            }
            else if (typeof(T) == typeof(ulong))
            {
                _readAction = Converter.ConvertRead<T>(Converter<ulong>.GetReadAction(ulong.Parse));
            }
            else if (typeof(T) == typeof(char))
            {
                _readAction = Converter.ConvertRead<T>(Converter<char>.GetReadAction(CharParse));
            }
            else if (typeof(T) == typeof(decimal))
            {
                _readAction = Converter.ConvertRead<T>(Converter<decimal>.GetReadAction(decimal.Parse));
            }
            else if (typeof(T) == typeof(double))
            {
                _readAction = Converter.ConvertRead<T>(Converter<double>.GetReadAction(double.Parse));
            }
            else if (typeof(T) == typeof(float))
            {
                _readAction = Converter.ConvertRead<T>(Converter<float>.GetReadAction(float.Parse));
            }
            else if (typeof(T) == typeof(string))
            {
                _readAction = Converter.ConvertRead<T>(Converter<string>.GetReadAction(s => s));
            }
            else if (typeof(T) == typeof(Type))
            {
                _writeAction = (Converter.WriteAction<T>)(Delegate)Converter<Type>.GetWriteAction(TypeNames.Get);
                _readAction = Converter.ConvertRead<T>(Converter<Type>.GetReadAction(s => Type.GetType(s, true)));
            }
            else if (typeInfo.IsEnum)
            {
                ParameterExpression line = Expression.Parameter(typeof(string));
                ParameterExpression reader = Expression.Parameter(typeof(StreamReader));

                Expression readIfNull = Expression.Condition(
                    Expression.Equal(line, Expression.Constant(null, typeof(string))),
                    Expression.Call(reader, typeof(StreamReader).GetTypeInfo().GetDeclaredMethod(nameof(StreamReader.ReadLine))),
                    line);

                _readAction = Expression.Lambda<Converter.ReadAction<T>>(Expression.Call(typeof(Converter<T>).GetTypeInfo().GetDeclaredMethod(nameof(ReadEnum)).MakeGenericMethod(typeof(T)), readIfNull), line, reader).Compile();
            }
            else if (typeInfo.IsArray)
            {
                Type elementType = typeInfo.GetElementType();

                _writeAction = (Converter.WriteAction<T>)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(WriteArray)).CreateDelegate(typeof(Converter.WriteAction<T>));
                _readAction = (Converter.ReadAction<T>)typeof(Converter<>).MakeGenericType(elementType).GetTypeInfo().GetDeclaredMethod(nameof(ReadArray)).CreateDelegate(typeof(Converter.ReadAction<T>));
            }
            else
            #endregion
            {
                #region Filters

                static bool Parameters_string(MethodInfo methodInfo)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();

                    return parameters.Length == 1
                        && parameters[0].ParameterType == typeof(string);
                }

                static bool Parameters_string_string(MethodInfo methodInfo)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();

                    return parameters.Length == 2
                        && parameters[0].ParameterType == typeof(string)
                        && parameters[1].ParameterType == typeof(string);
                }

                #endregion

                MethodInfo write = typeof(StreamWriter).GetTypeInfo().GetDeclaredMethods(nameof(StreamWriter.Write)).First(Parameters_string);
                MethodInfo writeLineString = typeof(Converter<T>).GetTypeInfo().GetDeclaredMethod(nameof(StreamWriterWriteLine));
                MethodInfo stringConcat = typeof(string).GetTypeInfo().GetDeclaredMethods(nameof(string.Concat)).First(Parameters_string_string);

                ParameterExpression value = Expression.Parameter(typeof(T).MakeByRefType());
                ParameterExpression writer = Expression.Parameter(typeof(StreamWriter));
                ParameterExpression indentation = Expression.Parameter(typeof(int));

                ParameterExpression space = Expression.Variable(typeof(string));
                Expression assignSpace = Expression.Assign(space, Expression.Call(typeof(Converter<T>).GetTypeInfo().GetDeclaredMethod(nameof(CreateIndentation)), indentation));

                List<Expression> writeExpressions = new List<Expression>
                {
                    Expression.Call(writeLineString, writer,Expression.Constant(_objectBegin)),
                    Expression.PreIncrementAssign(indentation),
                    assignSpace
                };

                while (typeInfo != null)
                {
                    foreach (FieldInfo fieldInfo in typeInfo.DeclaredFields.Where(f => !f.IsStatic))
                    {
                        string name = GetFriendlyName(fieldInfo.Name);
                        Expression writeField = Expression.Block(
                            Expression.Call(writer, write, Expression.Call(stringConcat, space, Expression.Constant(name))),
                            Expression.Call(writer, write, Expression.Constant(" ")),
                            Expression.Call(
                                typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Write)),
                                Expression.Field(value, fieldInfo),
                                writer,
                                indentation));

                        writeExpressions.Add(writeField);

                        DynamicMethod readMethod = new DynamicMethod($"Set_{nameof(T)}_{fieldInfo.Name}", typeof(void), new[] { typeof(string), typeof(StreamReader), typeof(T).MakeByRefType() }, typeof(Converter<T>), true);
                        ILGenerator readGenerator = readMethod.GetILGenerator();
                        readGenerator.Emit(OpCodes.Ldarg_2);
                        if (!typeInfo.IsValueType)
                        {
                            readGenerator.Emit(OpCodes.Ldind_Ref);
                        }
                        readGenerator.Emit(OpCodes.Ldarg_0);
                        readGenerator.Emit(OpCodes.Ldarg_1);
                        readGenerator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Read)));
                        readGenerator.Emit(OpCodes.Stfld, fieldInfo);
                        readGenerator.Emit(OpCodes.Ret);

                        _readFieldActions.Add(name.ToUpperInvariant(), (ReadFieldAction)readMethod.CreateDelegate(typeof(ReadFieldAction)));
                    }

                    typeInfo = typeInfo.BaseType?.GetTypeInfo();
                }

                writeExpressions.Add(Expression.PreDecrementAssign(indentation));
                writeExpressions.Add(assignSpace);
                writeExpressions.Add(Expression.Call(writeLineString, writer, Expression.Call(stringConcat, space, Expression.Constant(_objectEnd))));

                _writeAction = Expression.Lambda<Converter.WriteAction<T>>(Expression.Block(new[] { space }, writeExpressions), value, writer, indentation).Compile();

                _readAction = ReadAnyType;
            }
        }

        #endregion

        #region Methods

        private static string GetFriendlyName(string name)
        {
            Match match = Regex.Match(name, "^<(.+)>k__BackingField$");
            if (match.Success)
            {
                name = match.Groups[1].Value;
            }
            return name.Trim('_');
        }

        private static Converter.ReadAction<T> GetReadAction(Func<string, T> parser) => new Converter.ReadAction<T>((l, r) => parser(l ?? r.ReadLine()));

        private static Converter.WriteAction<T> GetWriteAction(Func<T, string> formatter) => new Converter.WriteAction<T>((in T v, StreamWriter w, int _) => w.WriteLine(formatter(v)));

        private static char CharParse(string entry)
        {
            if (!char.TryParse(entry, out char result))
            {
                throw new ArgumentException($"Could not convert '{entry}' to a char");
            }

            return result;
        }

        private static T ReadAnyType(string line, StreamReader reader)
        {
            while ((string.IsNullOrWhiteSpace(line) || line.Split(_split, StringSplitOptions.RemoveEmptyEntries)[0] != _objectBegin) && !reader.EndOfStream)
            {
                line = reader.ReadLine();
            }

            T value = _isValue ? default : ObjectInitializer<T>.Create();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                string[] parts = line.Split(_split, 2, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    if (parts[0] == _objectEnd)
                    {
                        break;
                    }
                    else if (_readFieldActions.TryGetValue(parts[0].ToUpperInvariant(), out ReadFieldAction action))
                    {
                        action(parts.Length > 1 ? parts[1] : null, reader, ref value);
                    }
                }
            }

            return value;
        }

        private static T[] ReadArray(string line, StreamReader reader)
        {
            while ((string.IsNullOrWhiteSpace(line) || !line.StartsWith(_arrayBegin)) && !reader.EndOfStream)
            {
                line = reader.ReadLine().TrimStart(_split);
            }

            List<T> values = new List<T>();

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine().TrimStart(_split);
                if (line.StartsWith(_arrayEnd))
                {
                    break;
                }
                else
                {
                    values.Add(Read(line, reader));
                }
            }

            return values.ToArray();
        }

        private static TEnum ReadEnum<TEnum>(string entry)
            where TEnum : struct
        {
            return Enum.TryParse(entry, out TEnum value) ? value : throw new ArgumentException($"Unable to convert '{entry}' to enum type {typeof(TEnum).AssemblyQualifiedName}");
        }

        private static string CreateIndentation(int indentation) => string.Join(string.Empty, Enumerable.Repeat('\t', indentation));

        private static void StreamWriterWriteLine(StreamWriter writer, string line) => writer.WriteLine(line);

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        private static void WriteArray(in T[] values, StreamWriter writer, int indentation)
        {
            writer.WriteLine(_arrayBegin);
            string indentationString = CreateIndentation(indentation + 1);

            foreach (T value in values)
            {
                writer.Write(indentationString);
                Write(value, writer, indentation + 1);
            }

            writer.Write(CreateIndentation(indentation));
            writer.WriteLine(_arrayEnd);
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void Write(in T value, StreamWriter writer, int indentation)
        {
            if (value is null)
            {
                writer.WriteLine("null");
            }
            else if (_isSealed || typeof(T) == value.GetType())
            {
                _writeAction(value, writer, indentation);
            }
            else
            {
                Type type = value.GetType();
                writer.WriteLine($"$type {TypeNames.Get(type)}");
                Converter.GetWriteAction(type)(value, writer, indentation);
            }
        }

        public static T Read(string line, StreamReader reader)
        {
            while (string.IsNullOrWhiteSpace(line) && !reader.EndOfStream)
            {
                line = reader.ReadLine();
            }

            if (line?.StartsWith("null") ?? true)
            {
                return default;
            }
            else if (line.StartsWith("$type"))
            {
                return Converter.GetReadAction<T>(Type.GetType(line.Split(_split, 2)[1], true))(string.Empty, reader);
            }
            else
            {
                return _readAction(line, reader);
            }
        }

        [SuppressMessage("Performance", "RCS1242:Do not pass non-read-only struct by read-only reference.")]
        public static void WrapperWrite(in object value, StreamWriter writer, int indentation) => Write((T)value, writer, indentation);

        #endregion
    }
}
