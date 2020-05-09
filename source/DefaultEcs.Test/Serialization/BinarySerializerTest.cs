using System;
using System.IO;
using DefaultEcs.Serialization;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Serialization
{
    public sealed class BinarySerializerTest : ASerializerTest
    {
        private class Point : IEquatable<Point>
        {
            public readonly int X;
            public readonly int Y;

            public Point()
            { }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public bool Equals(Point other) =>
                other != null
                && X == other.X
                && Y == other.Y;

            public override bool Equals(object obj) => Equals(obj as Point);

            public override int GetHashCode() => X + Y;
        }

        protected override void Write<T>(Stream stream, T obj) => BinarySerializer.Write(stream, obj);

        protected override T Read<T>(Stream stream) => BinarySerializer.Read<T>(stream);

        [Fact]
        public void Write_Should_use_context_marshalling()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Marshal<int, string>(i => $"value {i}");

            BinarySerializer.Write(stream, 42, context);

            stream.Position = 0;

            string copy = Read<string>(stream);

            Check.That(copy).IsEqualTo("value 42");
        }

        [Fact]
        public void Write_Should_use_context_marshalling_When_same_type()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Marshal<int, int>(_ => 1337);

            BinarySerializer.Write(stream, 42, context);

            stream.Position = 0;

            int copy = Read<int>(stream);

            Check.That(copy).IsEqualTo(1337);
        }

        [Fact]
        public void Write_Should_use_context_marshalling_for_object()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Marshal<int, string>(i => $"value {i}");

            BinarySerializer.Write<object>(stream, 42, context);

            stream.Position = 0;

            object copy = Read<object>(stream);

            Check.That(copy).IsInstanceOf<string>().And.IsEqualTo("value 42");
        }

        [Fact]
        public void Write_Should_use_context_marshalling_When_sub_field()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Marshal<int, int>(i => i * 2);

            BinarySerializer.Write(stream, new Point(1, 2), context);

            stream.Position = 0;

            Point copy = Read<Point>(stream);

            Check.That(copy).IsEqualTo(new Point(2, 4));
        }

        [Fact]
        public void Write_Should_use_context_unmarshalling_When_same_type()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Unmarshal<int, int>(_ => 1337);

            Write(stream, 42);

            stream.Position = 0;

            int copy = BinarySerializer.Read<int>(stream, context);

            Check.That(copy).IsEqualTo(1337);
        }

        [Fact]
        public void Write_Should_use_context_unmarshalling_When_sub_field()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Unmarshal<int, int>(i => i * 2);

            Write(stream, new Point(1, 2));

            stream.Position = 0;

            Point copy = BinarySerializer.Read<Point>(stream, context);

            Check.That(copy).IsEqualTo(new Point(2, 4));
        }

        [Fact]
        public void Write_Should_use_context_unmarshalling_for_object()
        {
            using Stream stream = new MemoryStream();

            using BinarySerializationContext context = new BinarySerializationContext()
                .Unmarshal<int, string>(i => $"value {i}");

            Write<object>(stream, 42);

            stream.Position = 0;

            object copy = BinarySerializer.Read<object>(stream, context);

            Check.That(copy).IsInstanceOf<string>().And.IsEqualTo("value 42");
        }
    }
}
