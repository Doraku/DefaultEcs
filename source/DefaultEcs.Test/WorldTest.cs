using System;
using System.Collections.Generic;
using DefaultEcs.Message;
using NFluent;
using Xunit;

namespace DefaultEcs.Test
{
    public class WorldTest
    {
        #region Tests

        [Fact]
        public void Subscribe_Should_subscribe()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe((in bool b) => done = b);
                world.Publish(true);

                Check.That(done).IsTrue();
            }
        }

        [Fact]
        public void Subscribe_Dispose_Should_unsubscribe()
        {
            using (World world = new World(0))
            {
                bool done = false;
                using (world.Subscribe((in bool b) => done = b))
                {
                    world.Publish(true);

                    Check.That(done).IsTrue();
                }

                done = false;
                world.Publish(true);
                Check.That(done).IsFalse();
            }
        }

        [Fact]
        public void Publish_Should_publish()
        {
            using (World world = new World(0))
            {
                bool done = false;
                world.Subscribe((in bool b) => done = b);
                world.Publish(true);

                Check.That(done).IsTrue();
            }
        }

        [Fact]
        public void CreateEntity_Should_return_an_Entity()
        {
            using (World world = new World(1))
            {
                Check.ThatCode(() => world.CreateEntity()).DoesNotThrow();
            }
        }

        [Fact]
        public void CreateEntity_Should_return_different_Entity_each_time()
        {
            using (World world = new World(2))
            {
                Check.That(world.CreateEntity()).IsNotEqualTo(world.CreateEntity());
            }
        }

        [Fact]
        public void CreateEntity_Should_throw_When_max_number_of_Entity_is_reached()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.CreateEntity()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void CreateEntity_Should_publish_EntityCreatedMessage()
        {
            using (World world = new World(2))
            {
                world.CreateEntity();

                Entity messageEntity = default;

                world.Subscribe((in EntityCreatedMessage m) => messageEntity = m.Entity);

                Check.That(world.CreateEntity()).IsEqualTo(messageEntity);
            }
        }

        [Fact]
        public void AddComponentType_Should_add()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.AddComponentType<bool>(0)).DoesNotThrow();
            }
        }

        [Fact]
        public void AddComponentType_Should_throw_When_maxComponentCount_is_negative()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.AddComponentType<bool>(-1)).Throws<ArgumentException>();
            }
        }

        [Fact]
        public void AddComponentType_Should_throw_When_already_added()
        {
            using (World world = new World(0))
            {
                world.AddComponentType<bool>(0);
                Check.ThatCode(() => world.AddComponentType<bool>(0)).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void GetAllComponents_Should_throw_When_not_added()
        {
            using (World world = new World(0))
            {
                Check.ThatCode(() => world.GetAllComponents<bool>()).Throws<InvalidOperationException>();
            }
        }

        [Fact]
        public void GetAllComponents_Should_return_component()
        {
            using (World world = new World(2))
            {
                world.AddComponentType<int>(2);
                Entity entity = world.CreateEntity();
                Entity entity2 = world.CreateEntity();

                entity.Set(1);
                entity2.Set(2);

                Span<int> components = world.GetAllComponents<int>();

                Check.That(components[0]).IsEqualTo(entity.Get<int>());
                Check.That(components[1]).IsEqualTo(entity2.Get<int>());

                components[0] = 10;
                components[1] = 20;

                Check.That(components[0]).IsEqualTo(entity.Get<int>());
                Check.That(components[1]).IsEqualTo(entity2.Get<int>());
            }
        }

        [Fact]
        public void GetAllEntities_Should_return_EntitySet_with_all_Entity()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetAllEntities())
            {
                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                entities[2].Dispose();
                entities.RemoveAt(2);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T_Should_return_EntitySet_with_all_Entity_with_component_T()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool>())
            {
                world.AddComponentType<bool>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                entities[2].Remove<bool>();
                entities.RemoveAt(2);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_Should_return_EntitySet_with_all_Entity_with_component_T1_T2()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_T6_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5_T6()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint, short>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);
                world.AddComponentType<short>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<short>(42);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42u);
                temp.Remove<short>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_T6_T7_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5_T6_T7()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint, short, ushort>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);
                world.AddComponentType<short>(4);
                world.AddComponentType<ushort>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<short>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ushort>(42);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42u);
                temp.Remove<short>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<short>(42);
                temp.Remove<ushort>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_T6_T7_T8_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5_T6_T7_T8()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint, short, ushort, long>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);
                world.AddComponentType<short>(4);
                world.AddComponentType<ushort>(4);
                world.AddComponentType<long>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<short>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ushort>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42L);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42u);
                temp.Remove<short>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<short>(42);
                temp.Remove<ushort>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<ushort>(42);
                temp.Remove<long>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_T6_T7_T8_T9_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5_T6_T7_T8_T9()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint, short, ushort, long, ulong>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);
                world.AddComponentType<short>(4);
                world.AddComponentType<ushort>(4);
                world.AddComponentType<long>(4);
                world.AddComponentType<ulong>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<short>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ushort>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42L);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ulong>(42);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42u);
                temp.Remove<short>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<short>(42);
                temp.Remove<ushort>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<ushort>(42);
                temp.Remove<long>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42L);
                temp.Remove<ulong>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        [Fact]
        public void GetEntitiesWith_T1_T2_T3_T4_T5_T6_T7_T8_T9_T10_Should_return_EntitySet_with_all_Entity_with_component_T1_T2_T3_T4_T5_T6_T7_T8_T9_T10()
        {
            using (World world = new World(4))
            using (EntitySet set = world.GetEntitiesWith<bool, int, string, float, uint, short, ushort, long, ulong, decimal>())
            {
                world.AddComponentType<bool>(4);
                world.AddComponentType<int>(4);
                world.AddComponentType<string>(4);
                world.AddComponentType<float>(4);
                world.AddComponentType<uint>(4);
                world.AddComponentType<short>(4);
                world.AddComponentType<ushort>(4);
                world.AddComponentType<long>(4);
                world.AddComponentType<ulong>(4);
                world.AddComponentType<decimal>(4);

                List<Entity> entities = new List<Entity>
                {
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity(),
                    world.CreateEntity()
                };

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(true);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(string.Empty);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42f);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42u);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<short>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ushort>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set(42L);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<ulong>(42);
                }

                Check.That(set.GetEntities().ToArray()).IsEmpty();

                foreach (Entity entity in entities)
                {
                    entity.Set<decimal>(42);
                }

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                Entity temp = entities[2];
                temp.Remove<bool>();
                entities.Remove(temp);

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(true);
                temp.Remove<int>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42);
                temp.Remove<string>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(string.Empty);
                temp.Remove<float>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42f);
                temp.Remove<uint>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42u);
                temp.Remove<short>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<short>(42);
                temp.Remove<ushort>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<ushort>(42);
                temp.Remove<long>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set(42L);
                temp.Remove<ulong>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);

                temp.Set<ulong>(42);
                temp.Remove<decimal>();

                Check.That(set.GetEntities().ToArray()).ContainsExactly(entities);
            }
        }

        #endregion
    }
}
