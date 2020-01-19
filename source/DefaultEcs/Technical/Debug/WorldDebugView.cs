using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Debug
{
    internal sealed class WorldDebugView
    {
        [DebuggerDisplay("Components {Type}")]
        private sealed class WorldComponents<T> : IComponent
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)]
            private readonly World _world;

            public Type Type => typeof(T);

            public int MaxCapacity { get; }

            public T[] Components => _world.Get<T>().ToArray();

            public WorldComponents(World world, int maxCapacity)
            {
                _world = world;
                MaxCapacity = maxCapacity;
            }
        }

        private sealed class ComponentTypeReader : IComponentTypeReader
        {
            private readonly World _world;
            private readonly List<IComponent> _components;

            public ComponentTypeReader(World world, List<IComponent> components)
            {
                _components = components;
                _world = world;
            }

            public void OnRead<T>(int maxCapacity) => _components.Add(new WorldComponents<T>(_world, maxCapacity));
        }

        private readonly World _world;
        private readonly List<IComponent> _components;

        public int MaxCapacity => _world.MaxCapacity;
        public Entity[] Entities => _world.ToArray();
        public IComponent[] Components => _components.ToArray();

        public WorldDebugView(World world)
        {
            _world = world;
            _components = new List<IComponent>();

            _world.ReadAllComponentTypes(new ComponentTypeReader(_world, _components));

            _components.Sort((o1, o2) => string.Compare(o1.Type.FullName, o2.Type.FullName));
        }
    }
}
