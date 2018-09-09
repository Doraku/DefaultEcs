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
            public int _3 { get; }

            public SimpleStruct(int i)
            {
                _1 = i + 1;
                _2 = i + 2;
                _3 = i + 3;
            }
        }

        private class SimpleClass
        {
            private int _1;
            private readonly int _2;
            private int _3 { get; }

            public SimpleClass()
            { }

            public SimpleClass(int i)
            {
                _1 = i + 1;
                _2 = i + 2;
                _3 = i + 3;
            }

            public override bool Equals(object obj)
            {
                return obj is SimpleClass other
                    && _1 == other._1
                    && _2 == other._2
                    && _3 == other._3;
            }
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
        }

        private unsafe struct BigStruct
        {
            public fixed int _1[1000];

            public BigStruct(int value)
            {
                fixed (int* iP = _1)
                {
                    for (int i = 0; i < 1000; ++i)
                    {
                        *(iP + i) = ++value;
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void Test<T>(T obj)
        {
            using (Stream stream = new MemoryStream())
            {
                Write(stream, obj);

                stream.Position = 0;

                T copy = Read<T>(stream);

                Check.That(copy).IsEqualTo(obj);
            }
        }

        private void TestArray<T>(T[] array)
        {
            using (Stream stream = new MemoryStream())
            {
                Write(stream, array);

                stream.Position = 0;

                T[] copy = Read<T[]>(stream);

                Check.That(copy).ContainsExactly(array);
            }
        }

        protected abstract void Write<T>(Stream stream, T obj);

        protected abstract T Read<T>(Stream stream);

        #endregion

        #region Tests

        [Fact]
        public void Should_handle_bool() => Test(true);

        [Fact]
        public void Should_handle_int() => Test(42);

        [Fact]
        public void Should_handle_null_string() => Test(default(string));

        [Fact]
        public void Should_handle_string() => Test("kikoolol");

        [Fact]
        public void Should_handle_simple_struct() => Test(new SimpleStruct(0));

        [Fact]
        public void Should_handle_simple_class() => Test(new SimpleClass(0));

        [Fact]
        public void Should_handle_null_class() => Test(default(SimpleClass));

        [Fact]
        public void Should_handle_struct_with_null_class() => Test(new StructWithClass { _1 = new SimpleStruct(0) });

        [Fact]
        public void Should_handle_struct_with_class() => Test(new StructWithClass { _1 = new SimpleStruct(0), _2 = new SimpleClass(0), _3 = "kikoolol" });

        [Fact]
        public void Should_handle_struct_array() => TestArray(Enumerable.Range(0, 42).ToArray());

        [Fact]
        public void Should_handle_class_array() => TestArray(Enumerable.Range(0, 42).Select(i => new SimpleClass(i)).ToArray());

        [Fact]
        public void Should_handle_derived_class() => Test<SimpleClass>(new DerivedClass(0));

        [Fact]
        public void Should_handle_bigger_than_buffer_string() => Test(new string(Enumerable.Repeat(' ', 2000).ToArray()));

        [Fact]
        public void Should_handle_bigger_than_buffer_struct() => Test(new BigStruct(0));

        #endregion
    }
}
