using System;
using System.Collections.Generic;
using System.Diagnostics;
using DefaultEcs.Serialization;

namespace DefaultEcs.Internal.Diagnostics
{
    internal sealed class EntityDebugView
    {
        [DebuggerDisplay("Component {Type}")]
        private sealed class Component<T> : IComponent
        {
            public bool IsEnabled { get; }

            public T Value { get; }

            public Type Type => typeof(T);

            public Component(bool isEnabled, T value)
            {
                Value = value;
                IsEnabled = isEnabled;
            }
        }

        private sealed class DebugComponentReader : IComponentReader
        {
            private readonly Entity _entity;
            private readonly List<IComponent> _components;

            public DebugComponentReader(in Entity entity, List<IComponent> components)
            {
                _components = components;
                _entity = entity;
            }

            public void OnRead<T>(in T component, in Entity componentOwner) => _components.Add(new Component<T>(_entity.IsEnabled<T>(), component));
        }

        private readonly Entity _entity;
        private readonly List<IComponent> _components;

        public World World => _entity.World;
        public bool IsAlive => _entity.IsAlive;
        public bool IsEnabled => _entity.IsEnabled();
        public IComponent[] Components => _components.ToArray();

        public EntityDebugView(Entity entity)
        {
            _entity = entity;
            _components = new List<IComponent>();

            entity.ReadAllComponents(new DebugComponentReader(_entity, _components));

            _components.Sort((o1, o2) => string.CompareOrdinal(o1.Type.FullName, o2.Type.FullName));
        }
    }
}
