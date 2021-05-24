using System;
using System.Threading;
using DefaultEcs.Serialization;

namespace DefaultEcs.CustomCopyTo
{
    public class ComponentCloner
    {
        private sealed class ComponentReader : IComponentReader
        {
            private readonly ComponentCloner _cloner;

            public ComponentReader(ComponentCloner cloner)
            {
                _cloner = cloner;
            }

            public void OnRead<T>(in T component, in Entity componentOwner) => _cloner.OnComponent(component, _cloner._from.IsEnabled<T>());
        }

        private readonly ComponentReader _reader;

        private Entity _from;
        private Entity _to;

        public ComponentCloner()
        {
            _reader = new ComponentReader(this);
        }

        public void Clone(in Entity from, in Entity to)
        {
            _from = from;
            _to = to;

            from.ReadAllComponents(_reader);
        }

        protected void Set<T>(in T component, bool isEnabled)
        {
            _to.Set(component);
            if (!isEnabled)
            {
                _to.Disable<T>();
            }
        }

        protected virtual void OnComponent<T>(in T component, bool isEnabled) => Set(component, isEnabled);
    }

    public static class EntityExtension
    {
        public static Entity CopyTo(in this Entity entity, World world, ComponentCloner cloner)
        {
            if (!entity.IsAlive) throw new InvalidOperationException("Entity is not alive");
            if (cloner is null) throw new ArgumentNullException(nameof(cloner));

            Entity copy = world.CreateEntity();

            if (!entity.IsEnabled())
            {
                copy.Disable();
            }

            try
            {
                cloner.Clone(entity, copy);
            }
            catch
            {
                copy.Dispose();

                throw;
            }

            return copy;
        }
    }
}
