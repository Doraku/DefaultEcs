using System.Threading;
using DefaultEcs.Serialization;
using DefaultEcs.Internal;

namespace DefaultEcs
{
    /// <summary>
    /// Exposes a way to clone one <see cref="Entity"/> components to an other.
    /// </summary>
    public class ComponentCloner
    {
        private sealed class ComponentReader : IComponentReader
        {
            private readonly ComponentCloner _cloner;

            public ComponentReader(ComponentCloner cloner)
            {
                _cloner = cloner;
            }

            public void OnRead<T>(in T component, in Entity componentOwner) => _cloner.OnComponent(component, _cloner._from[ComponentManager<T>.Flag]);
        }

        private static readonly ThreadLocal<ComponentCloner> _local = new(() => new ComponentCloner(), false);

        internal static ComponentCloner Instance => _local.Value;

        private readonly ComponentReader _reader;

        private ComponentEnum _from;
        private Entity _to;

        /// <summary>
        /// Initialize a new instance of the <see cref="ComponentCloner"/> type.
        /// </summary>
        public ComponentCloner()
        {
            _reader = new ComponentReader(this);
        }

        /// <summary>
        /// Sets the given component on the copied entity.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <param name="isEnabled">Whether the component is enabled or not on the source <see cref="Entity"/>.</param>
        protected void Set<T>(in T component, bool isEnabled)
        {
            _to.Set(component);
            if (!isEnabled)
            {
                _to.Disable<T>();
            }
        }

        /// <summary>
        /// Handles the component of type <typeparamref name="T"/> from the source <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <param name="isEnabled">Whether the component is enabled or not on the source <see cref="Entity"/>.</param>
        protected virtual void OnComponent<T>(in T component, bool isEnabled) => Set(component, isEnabled);

        /// <summary>
        /// Clones one <see cref="Entity"/> components to an other.
        /// </summary>
        /// <param name="from">The source <see cref="Entity"/>.</param>
        /// <param name="to">The target <see cref="Entity"/>.</param>
        public void Clone(in Entity from, in Entity to)
        {
            _from = from.Components;
            _to = to;

            from.ReadAllComponents(_reader);
        }
    }
}
