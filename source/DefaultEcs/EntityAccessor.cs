using System;
using System.Collections.Generic;
using System.Linq;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs {
    /// <inheritdoc />
    public class EntityAccessor : IEntityAccessor {
        /// <inheritdoc />
        public bool IsEnabled(Entity entity) =>
            entity.WorldId != 0 && GetComponentsReference(entity)[World.IsEnabledFlag];

        /// <inheritdoc />
        public bool IsEnabled<T>(Entity entity) =>
            entity.WorldId != 0 && GetComponentsReference(entity)[ComponentManager<T>.Flag];

        /// <inheritdoc />
        public bool Has<T>(Entity entity) => entity.WorldId < ComponentManager<T>.Pools.Length &&
                                             (ComponentManager<T>.Pools[entity.WorldId]?.Has(entity.EntityId) ?? false);

        /// <inheritdoc />
        public ref T Get<T>(Entity entity) => ref ComponentManager<T>.Pools[entity.WorldId].Get(entity.EntityId);

        /// <inheritdoc />
        public IEnumerable<Entity> GetChildren(Entity entity) {
            foreach (int childId in entity.World?.EntityInfos[entity.EntityId].Children ?? Enumerable.Empty<int>()) {
                yield return new Entity(entity.WorldId, childId);
            }
        }

        /// <inheritdoc />
        public void ReadAllComponents(Entity entity, IComponentReader reader) {
            Publisher.Publish(
                entity.WorldId,
                new ComponentReadMessage(entity.EntityId, reader ?? throw new ArgumentNullException(nameof(reader)))
            );
        }

        private ref ComponentEnum GetComponentsReference(Entity entity) {
            return ref entity.World.EntityInfos[entity.EntityId].Components;
        }
    }
}