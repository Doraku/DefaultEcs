using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DefaultEcs.Serialization;

namespace DefaultEcs.Technical.Debug
{
    internal sealed class EntityDebugView
    {
        [DebuggerDisplay("Component {Type}")]
        private sealed class Component<T>
        {
            public readonly bool IsEnabled;
            public readonly T Value;

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
            private readonly List<object> _components;

            public DebugComponentReader(in Entity entity, List<object> components)
            {
                _components = components;
                _entity = entity;
            }

            public void OnRead<T>(ref T component, in Entity componentOwner) => _components.Add(new Component<T>(_entity.IsEnabled<T>(), component));
        }

        private readonly Entity _entity;
        private readonly List<object> _components;

        public bool IsAlive => _entity.IsAlive;
        public bool IsEnabled => _entity.IsEnabled();
        public IEnumerable<Entity> Children => _entity.GetChildren().ToArray();
        public IEnumerable<object> Components => _components;

        public EntityDebugView(Entity entity)
        {
            _entity = entity;
            _components = new List<object>();

            entity.ReadAllComponents(new DebugComponentReader(_entity, _components));
        }
    }
}
