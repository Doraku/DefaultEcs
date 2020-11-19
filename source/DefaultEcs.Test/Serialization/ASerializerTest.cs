using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Serialization
{
    public abstract class ASerializerTest
    {
        #region Types

        private struct SimpleStruct
        {
            public int _1;
            public readonly int _2;
            public int P3 { get; }

            public SimpleStruct(int i)
            {
                _1 = i + 1;
                _2 = i + 2;
                P3 = i + 3;
            }
        }

        private class SimpleClass
        {
            [SuppressMessage("Design", "RCS1169:Make field read-only.")]
            [SuppressMessage("Style", "IDE0044:Add readonly modifier")]
            private int _1;
            private readonly int _2;
            private int P3 { get; }

            public SimpleClass()
            { }

            public SimpleClass(int i)
            {
                _1 = i + 1;
                _2 = i + 2;
                P3 = i + 3;
            }

            public override bool Equals(object obj)
            {
                return obj is SimpleClass other
                    && _1 == other._1
                    && _2 == other._2
                    && P3 == other.P3;
            }

            public override int GetHashCode() => _1;
        }

        private struct StructWithClass
        {
            public SimpleStruct _1;
            public SimpleClass _2;
            public string _3;
        }

        private class DerivedClass : SimpleClass
        {
            public int _4;

            public DerivedClass()
            { }

            public DerivedClass(int i)
                : base(i)
            {
                _4 = i + 4;
            }

            public override bool Equals(object obj)
            {
                return base.Equals(obj)
                    && obj is DerivedClass other
                    && _4 == other._4;
            }

            public override int GetHashCode() => _4;
        }

        private unsafe struct BigStruct
        {
            public fixed int _1[10000];

            public BigStruct(int value)
            {
                fixed (int* iP = _1)
                {
                    for (int i = 0; i < 10000; ++i)
                    {
                        *(iP + i) = ++value;
                    }
                }
            }
        }

        private class NoConstructorClass
        {
            public int _1;

            public NoConstructorClass(int value)
            {
                _1 = value;
            }

            public override bool Equals(object obj)
            {
                return obj is NoConstructorClass other
                    && _1 == other._1;
            }

            public override int GetHashCode() => _1;
        }

        #endregion

        #region Methods

        private void Test<T>(T obj)
        {
            using Stream stream = new MemoryStream();

            Write(stream, obj);

            stream.Position = 0;

            T copy = Read<T>(stream);

            Check.That(copy).IsEqualTo(obj);
        }

        private void TestArray<T>(T[] array)
        {
            using Stream stream = new MemoryStream();

            Write(stream, array);

            stream.Position = 0;

            T[] copy = Read<T[]>(stream);

            Check.That(copy).ContainsExactly(array);
        }

        private void TestList<T>(List<T> list)
        {
            using Stream stream = new MemoryStream();

            Write(stream, list);

            stream.Position = 0;

            List<T> copy = Read<List<T>>(stream);

            Check.That(copy).ContainsExactly(list);
        }

        private void TestDctionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            using Stream stream = new MemoryStream();

            Write(stream, dictionary);

            stream.Position = 0;

            Dictionary<TKey, TValue> copy = Read<Dictionary<TKey, TValue>>(stream);

            Check.That(copy).ContainsExactly(dictionary);
        }

        protected abstract void Write<T>(Stream stream, T obj);

        protected abstract T Read<T>(Stream stream);

        #endregion

        #region Tests

        [Fact]
        public void Write_Should_throw_When_stream_is_null() => Check.ThatCode(() => Write(null, true)).Throws<ArgumentNullException>();

        [Fact]
        public void Read_Should_throw_When_stream_is_null() => Check.ThatCode(() => Read<bool>(null)).Throws<ArgumentNullException>();

        [Fact]
        public void Should_handle_bool() => Test(true);

        [Fact]
        public void Should_handle_int() => Test(42);

        [Fact]
        public void Should_handle_char() => Test('@');

        [Fact]
        public void Should_handle_null_string() => Test(default(string));

        [Fact]
        public void Should_handle_string() => Test("kikoolol");

        [Fact]
        public void Should_handle_string_with_double_quote() => Test(@"kikoo""lol""");

        [Fact]
        public void Should_handle_simple_struct() => Test(new SimpleStruct(0));

        [Fact]
        public void Should_handle_simple_class() => Test(new SimpleClass(0));

        [Fact]
        public void Should_handle_Guid() => Test(Guid.NewGuid());

        [Fact]
        public void Should_handle_null_class() => Test(default(SimpleClass));

        [Fact]
        public void Should_handle_struct_with_null_class() => Test(new StructWithClass { _1 = new SimpleStruct(0) });

        [Fact]
        public void Should_handle_struct_with_class() => Test(new StructWithClass { _1 = new SimpleStruct(0), _2 = new SimpleClass(0), _3 = "kikoolol" });

        [Fact]
#if NET5_0
        [SuppressMessage("Performance", "CA1825")]
#endif
        public void Should_handle_empty_array() => TestArray(new object[0]);

        [Fact]
        public void Should_handle_struct_array() => TestArray(Enumerable.Range(0, 42).ToArray());

        [Fact]
        public void Should_handle_class_array() => TestArray(Enumerable.Range(0, 42).Select(i => new SimpleClass(i)).ToArray());

        [Fact]
        public void Should_handle_struct_list() => TestList(Enumerable.Range(0, 42).ToList());

        [Fact]
        public void Should_handle_class_list() => TestList(Enumerable.Range(0, 42).Select(i => new SimpleClass(i)).ToList());

        [Fact]
        public void Should_handle_struct_dictionary() => TestDctionary(Enumerable.Range(0, 42).ToDictionary(i => i));

        [Fact]
        public void Should_handle_class_dictionary() => TestDctionary(Enumerable.Range(0, 42).ToDictionary(i => i, i => new SimpleClass(i)));

        [Fact]
        public void Should_handle_derived_class() => Test<SimpleClass>(new DerivedClass(0));

        [Fact]
        public void Should_handle_bigger_than_buffer_string() => Test(new string(Enumerable.Repeat('-', 2000).ToArray()));

        [Fact]
        public void Should_handle_bigger_than_buffer_struct() => Test(new BigStruct(0));

        [Fact]
        public void Should_handle_struct_as_object() => Test<object>(42);

        [Fact]
#if NET5_0
        [SuppressMessage("Performance", "CA1825")]
#endif
        public void Should_handle_complex_generic_type_as_object() => Test<object>(new Dictionary<string, DerivedClass[,,]>[0]);

        [Fact]
        public void Should_handle_Type() => Test(typeof(Dictionary<string, DerivedClass[,,]>[]));

#if !NET452 // unsuported
        [Fact]
        public void Should_handle_class_with_no_default_constructor() => Test(new NoConstructorClass(42));
#endif

        #endregion
    }
}
