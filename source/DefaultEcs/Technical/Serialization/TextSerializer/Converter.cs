using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.RegularExpressions;

namespace DefaultEcs.Technical.Serialization.TextSerializer
{
    internal static class Converter<T>
    {
        #region Types

        private delegate void WriteAction(in T value, StreamWriter writer, int indentation);
        private delegate T ReadAction(string line, StreamReader reader);
        private delegate void ReadFieldAction(string line, StreamReader reader, ref T value);

        #endregion

        #region Fields

        private const string _objectBegin = "{";
        private const string _objectEnd = "}";

        private static readonly char[] _split = new[] { ' ', '\t' };
        private static readonly Dictionary<string, ReadFieldAction> _readFieldActions;
        private static readonly WriteAction _writeAction;
        private static readonly ReadAction _readAction;

        #endregion

        #region Initialisation

        static Converter()
        {
            _readFieldActions = new Dictionary<string, ReadFieldAction>();

            _writeAction = (in T v, StreamWriter w, int i) => w.WriteLine(v.ToString());

            #region clr types
            if (typeof(T) == typeof(bool))
            {
                _readAction = (ReadAction)Converter<bool>.GetReadAction(bool.Parse);
            }
            else if (typeof(T) == typeof(sbyte))
            {
                _readAction = (ReadAction)Converter<sbyte>.GetReadAction(sbyte.Parse);
            }
            else if (typeof(T) == typeof(byte))
            {
                _readAction = (ReadAction)Converter<byte>.GetReadAction(byte.Parse);
            }
            else if (typeof(T) == typeof(short))
            {
                _readAction = (ReadAction)Converter<short>.GetReadAction(short.Parse);
            }
            else if (typeof(T) == typeof(ushort))
            {
                _readAction = (ReadAction)Converter<ushort>.GetReadAction(ushort.Parse);
            }
            else if (typeof(T) == typeof(int))
            {
                _readAction = (ReadAction)Converter<int>.GetReadAction(int.Parse);
            }
            else if (typeof(T) == typeof(uint))
            {
                _readAction = (ReadAction)Converter<uint>.GetReadAction(uint.Parse);
            }
            else if (typeof(T) == typeof(long))
            {
                _readAction = (ReadAction)Converter<long>.GetReadAction(long.Parse);
            }
            else if (typeof(T) == typeof(ulong))
            {
                _readAction = (ReadAction)Converter<ulong>.GetReadAction(ulong.Parse);
            }
            else if (typeof(T) == typeof(char))
            {
                _readAction = (ReadAction)Converter<char>.GetReadAction(CharParse);
            }
            else if (typeof(T) == typeof(decimal))
            {
                _readAction = (ReadAction)Converter<decimal>.GetReadAction(decimal.Parse);
            }
            else if (typeof(T) == typeof(double))
            {
                _readAction = (ReadAction)Converter<double>.GetReadAction(double.Parse);
            }
            else if (typeof(T) == typeof(float))
            {
                _readAction = (ReadAction)Converter<float>.GetReadAction(float.Parse);
            }
            else if (typeof(T) == typeof(string))
            {
                _readAction = (ReadAction)Converter<string>.GetReadAction(s => s);
            }
            else if (typeof(T).GetTypeInfo().IsEnum)
            {
                ParameterExpression line = Expression.Parameter(typeof(string));
                ParameterExpression reader = Expression.Parameter(typeof(StreamReader));

                Expression readIfNull = Expression.Condition(
                    Expression.Equal(line, Expression.Constant(null, typeof(string))),
                    Expression.Call(reader, typeof(StreamReader).GetTypeInfo().GetDeclaredMethod(nameof(StreamReader.ReadLine))),
                    line);

                _readAction = Expression.Lambda<ReadAction>(Expression.Call(typeof(Converter<T>).GetTypeInfo().GetDeclaredMethod(nameof(ReadEnum)).MakeGenericMethod(typeof(T)), readIfNull), line, reader).Compile();
            }
            else
            #endregion
            {
                #region Filters

                bool Parameters_string(MethodInfo methodInfo)
                {
                    ParameterInfo[] parameters = methodInfo.GetParameters();

                    return parameters.Length == 1
                        && parameters[0].ParameterType == typeof(string);
                }

                bool Parameters_string_string(MethodInfo methodInfo)
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

                foreach (FieldInfo fieldInfo in typeof(T).GetTypeInfo().DeclaredFields.Where(f => !f.IsStatic))
                {
                    string name = GetFriendlyName(fieldInfo.Name);
                    writeExpressions.Add(Expression.Call(writer, write, Expression.Call(stringConcat, space, Expression.Constant(name))));
                    writeExpressions.Add(Expression.Call(writer, write, Expression.Constant(" ")));
                    writeExpressions.Add(Expression.Call(
                        typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Write)),
                        Expression.Field(value, fieldInfo),
                        writer,
                        indentation));

                    DynamicMethod dynMethod = new DynamicMethod($"Set_{nameof(T)}_{fieldInfo.Name}", typeof(void), new[] { typeof(string), typeof(StreamReader), typeof(T).MakeByRefType() }, typeof(Converter<T>), true);
                    ILGenerator generator = dynMethod.GetILGenerator();
                    generator.Emit(OpCodes.Ldarg_2);
                    if (!typeof(T).GetTypeInfo().IsValueType)
                    {
                        generator.Emit(OpCodes.Ldind_Ref);
                    }
                    generator.Emit(OpCodes.Ldarg_0);
                    generator.Emit(OpCodes.Ldarg_1);
                    generator.Emit(OpCodes.Call, typeof(Converter<>).MakeGenericType(fieldInfo.FieldType).GetTypeInfo().GetDeclaredMethod(nameof(Converter<T>.Read)));
                    generator.Emit(OpCodes.Stfld, fieldInfo);
                    generator.Emit(OpCodes.Ret);

                    _readFieldActions.Add(name.ToUpperInvariant(), (ReadFieldAction)dynMethod.CreateDelegate(typeof(ReadFieldAction)));
                }

                writeExpressions.Add(Expression.PreDecrementAssign(indentation));
                writeExpressions.Add(assignSpace);
                writeExpressions.Add(Expression.Call(writeLineString, writer, Expression.Call(stringConcat, space, Expression.Constant(_objectEnd))));

                _writeAction = Expression.Lambda<WriteAction>(Expression.Block(new[] { space }, writeExpressions), value, writer, indentation).Compile();
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

        private static ReadAction GetReadAction(Func<string, T> parser) => new ReadAction((l, r) => parser(l ?? r.ReadLine()));

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
            T value = Activator.CreateInstance<T>();

            while ((string.IsNullOrWhiteSpace(line) || line.Split(_split, StringSplitOptions.RemoveEmptyEntries)[0] != _objectBegin) && !reader.EndOfStream)
            {
                line = reader.ReadLine();
            }

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

        public static TEnum ReadEnum<TEnum>(string entry)
            where TEnum : struct
        {
            return Enum.TryParse(entry, out TEnum value) ? value : throw new ArgumentException($"Unable to convert '{entry}' to enum type {typeof(TEnum).AssemblyQualifiedName}");
        }

        public static string CreateIndentation(int indentation) => string.Join(string.Empty, Enumerable.Repeat('\t', indentation));

        public static void StreamWriterWriteLine(StreamWriter writer, string line) => writer.WriteLine(line);

        public static void Write(in T value, StreamWriter writer, int indentation) => _writeAction(value, writer, indentation);

        public static T Read(string line, StreamReader reader) => _readAction(line, reader);

        #endregion
    }
}
