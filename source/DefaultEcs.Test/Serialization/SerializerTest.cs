using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DefaultEcs.Serialization;
using NFluent;
using Xunit;

namespace DefaultEcs.Test.Serialization
{
    public class SerializerTest
    {
        #region Types

        private struct Test
        {
            private int _privateField;
            private readonly int _privateReadOnlyField;

            private int PrivateProperty { get; set; }
            private int PrivateReadOnlyProperty { get; }

            public int PublicField;
            public readonly int PublicReadOnlyField;

            public int PublicProperty { get; set; }
            public int PublicReadOnlyProperty { get; }

            public InnerTest Kikoo;

            public Test(int value)
            {
                _privateField = value;
                _privateReadOnlyField = value + 1;
                PrivateProperty = value + 2;
                PrivateReadOnlyProperty = value + 3;
                PublicField = value + 4;
                PublicReadOnlyField = value + 5;
                PublicProperty = value + 6;
                PublicReadOnlyProperty = value + 7;
                Kikoo = new InnerTest { Lol = value + 8, Enum = EnumTest.Lol };
            }
        }

        private struct InnerTest
        {
            public int Lol;
            public EnumTest Enum;
        }

        private enum EnumTest : short
        {
            Kikoo,
            Lol
        }

        private class ClassTest
        {
            public int Id;
            public Test Inner;
            public InnerTest2 Test;

            public override bool Equals(object obj)
            {
                return obj is ClassTest t
                    && Id == t.Id
                    && Inner.Equals(t.Inner)
                    && Test.Equals(t.Test);
            }

            public override int GetHashCode() => Id;
        }

        private struct InnerTest2
        {
            public InnerClass C;

            public override bool Equals(object obj)
            {
                return obj is InnerTest2 t
                    && C?.I == t.C?.I;
            }

            public override int GetHashCode() => C?.I ?? 0;
        }

        private class InnerClass
        {
            public int I;
        }

        #endregion

        #region Tests

        [Theory]
        [InlineData(typeof(BinarySerializer))]
        [InlineData(typeof(TextSerializer))]
        public void Serialize_Should_serialize_World(Type serializerType)
        {
            using (World world = new World(42))
            {
                world.SetMaximumComponentCount<int>(13);
                world.SetMaximumComponentCount<float>(60);

                Entity[] entities = new[]
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };
                entities[0].Set<bool>(true);
                entities[0].Set<sbyte>(13);
                entities[0].Set<byte>(7);
                entities[0].Set<short>(13);
                entities[0].Set<ushort>(7);
                entities[0].Set<int>(13);
                entities[0].Set<uint>(7);
                entities[0].Set<long>(13);
                entities[0].Set<ulong>(7);
                entities[0].Set<char>('c');
                entities[0].Set<decimal>(3.14m);
                entities[0].Set<double>(1337);
                entities[0].Set<float>(-1);
                entities[0].Set<string>("kikoo");
                entities[0].Set(new Test(666));
                entities[0].Set(new ClassTest { Id = 12345, Inner = new Test(66), Test = new InnerTest2() });
                entities[2].Set(new InnerTest { Lol = 313 });
                entities[1].SetSameAs<InnerTest>(entities[2]);
                entities[1].Set(new Test(42));
                entities[2].SetSameAs<Test>(entities[1]);

                entities[0].Set<InnerClass>();
                entities[0].Set(new List<int> { 1, 2, 3 });

                entities[0].SetAsParentOf(entities[1]);

                ISerializer serializer = (ISerializer)Activator.CreateInstance(serializerType);

                string filePath = Path.GetRandomFileName();
                try
                {
                    using (Stream stream = File.Create(filePath))
                    {
                        serializer.Serialize(stream, world);
                    }

                    World copyWorld;
                    using (Stream stream = File.OpenRead(filePath))
                    {
                        copyWorld = serializer.Deserialize(stream);
                    }

                    using (copyWorld)
                    {
                        Check.That(copyWorld.MaxEntityCount).IsEqualTo(world.MaxEntityCount);

                        Entity[] entitiesCopy = copyWorld.GetAllEntities().ToArray();

                        Check.That(entitiesCopy[0].Get<bool>()).IsEqualTo(entities[0].Get<bool>());
                        Check.That(entitiesCopy[0].Get<sbyte>()).IsEqualTo(entities[0].Get<sbyte>());
                        Check.That(entitiesCopy[0].Get<byte>()).IsEqualTo(entities[0].Get<byte>());
                        Check.That(entitiesCopy[0].Get<short>()).IsEqualTo(entities[0].Get<short>());
                        Check.That(entitiesCopy[0].Get<ushort>()).IsEqualTo(entities[0].Get<ushort>());
                        Check.That(entitiesCopy[0].Get<int>()).IsEqualTo(entities[0].Get<int>());
                        Check.That(entitiesCopy[0].Get<uint>()).IsEqualTo(entities[0].Get<uint>());
                        Check.That(entitiesCopy[0].Get<long>()).IsEqualTo(entities[0].Get<long>());
                        Check.That(entitiesCopy[0].Get<ulong>()).IsEqualTo(entities[0].Get<ulong>());
                        Check.That(entitiesCopy[0].Get<char>()).IsEqualTo(entities[0].Get<char>());
                        Check.That(entitiesCopy[0].Get<decimal>()).IsEqualTo(entities[0].Get<decimal>());
                        Check.That(entitiesCopy[0].Get<double>()).IsEqualTo(entities[0].Get<double>());
                        Check.That(entitiesCopy[0].Get<float>()).IsEqualTo(entities[0].Get<float>());
                        Check.That(entitiesCopy[0].Get<string>()).IsEqualTo(entities[0].Get<string>());
                        Check.That(entitiesCopy[0].Get<ClassTest>()).IsEqualTo(entities[0].Get<ClassTest>());

                        Check.That(entities[0].Get<Test>()).IsEqualTo(entitiesCopy[0].Get<Test>());

                        Check.That(entitiesCopy[1].Get<Test>()).IsEqualTo(entities[1].Get<Test>());
                        Check.That(entitiesCopy[1].Get<InnerTest>()).IsEqualTo(entities[1].Get<InnerTest>());

                        Check.That(entitiesCopy[1].Get<Test>()).IsEqualTo(entitiesCopy[2].Get<Test>());
                        Check.That(entitiesCopy[1].Get<InnerTest>()).IsEqualTo(entitiesCopy[2].Get<InnerTest>());

                        Check.That(entitiesCopy[0].Get<InnerClass>()).IsEqualTo(entities[0].Get<InnerClass>());
                        Check.That(entitiesCopy[0].Get<List<int>>()).ContainsExactly(entities[0].Get<List<int>>());

                        entitiesCopy[0].Dispose();

                        Check.That(copyWorld.GetAllEntities().Count()).IsEqualTo(1);
                    }
                }
                finally
                {
                    File.Delete(filePath);
                }
            }
        }

        #endregion
    }
}
