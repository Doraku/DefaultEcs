using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <inheritdoc />
    public class EntityMutator : IEntityMutator
    {
        /// <inheritdoc />
        public virtual void SetDisabled<T>(Entity entity, in T component) =>
            ComponentManager<T>.GetOrCreate(entity.WorldId).Set(entity.EntityId, component);

        /// <inheritdoc />
        public virtual void SetSameAsDisabled<T>(Entity entity, in Entity reference)
        {
            ComponentPool<T> pool = ComponentManager<T>.Get(entity.WorldId);
            if (!(pool?.Has(reference.EntityId) ?? false))
                Throw($"Reference Entity does not have a component of type {nameof(T)}");

            pool?.SetSameAs(entity.EntityId, reference.EntityId);
        }

        /// <inheritdoc />
        public virtual void Enable(Entity entity)
        {
            ref ComponentEnum components = ref GetComponentsReference(entity);
            if (!components[World.IsEnabledFlag]) {
                components[World.IsEnabledFlag] = true;
                Publisher.Publish(entity.WorldId, new EntityEnabledMessage(entity.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void Disable(Entity entity)
        {
            ref ComponentEnum components = ref GetComponentsReference(entity);
            if (components[World.IsEnabledFlag]) {
                components[World.IsEnabledFlag] = false;
                Publisher.Publish(entity.WorldId, new EntityDisabledMessage(entity.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void Enable<T>(Entity entity)
        {
            if (entity.Has<T>()) {
                ref ComponentEnum components = ref GetComponentsReference(entity);
                if (!components[ComponentManager<T>.Flag]) {
                    components[ComponentManager<T>.Flag] = true;
                    Publisher.Publish(entity.WorldId, new ComponentAddedMessage<T>(entity.EntityId, components));
                }
            }
        }

        /// <inheritdoc />
        public virtual void Disable<T>(Entity entity)
        {
            ref ComponentEnum components = ref GetComponentsReference(entity);
            if (components[ComponentManager<T>.Flag]) {
                components[ComponentManager<T>.Flag] = false;
                Publisher.Publish(entity.WorldId, new ComponentRemovedMessage<T>(entity.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void Set<T>(Entity entity, in T component)
        {
            ref ComponentEnum components = ref GetComponentsReference(entity);
            if (ComponentManager<T>.GetOrCreate(entity.WorldId).Set(entity.EntityId, component)) {
                components[ComponentManager<T>.Flag] = true;
                Publisher.Publish(entity.WorldId, new ComponentAddedMessage<T>(entity.EntityId, components));
            } else if (components[ComponentManager<T>.Flag]) {
                Publisher.Publish(entity.WorldId, new ComponentChangedMessage<T>(entity.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void SetSameAs<T>(Entity target, in Entity reference)
        {
            if (target.WorldId != reference.WorldId) Throw("Reference Entity comes from a different World");
            ComponentPool<T> pool = ComponentManager<T>.Get(target.WorldId);
            if (!(pool?.Has(reference.EntityId) ?? false))
                Throw($"Reference Entity does not have a component of type {nameof(T)}");

            ref ComponentEnum components = ref GetComponentsReference(target);
            if (pool.SetSameAs(target.EntityId, reference.EntityId)) {
                components[ComponentManager<T>.Flag] = true;
                Publisher.Publish(target.WorldId, new ComponentAddedMessage<T>(target.EntityId, components));
            } else if (components[ComponentManager<T>.Flag]) {
                Publisher.Publish(target.WorldId, new ComponentChangedMessage<T>(target.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void Remove<T>(Entity entity)
        {
            if (ComponentManager<T>.Get(entity.WorldId)?.Remove(entity.EntityId) ?? false) {
                ref ComponentEnum components = ref GetComponentsReference(entity);
                components[ComponentManager<T>.Flag] = false;
                Publisher.Publish(entity.WorldId, new ComponentRemovedMessage<T>(entity.EntityId, components));
            }
        }

        /// <inheritdoc />
        public virtual void SetAsChildOf(Entity entity, in Entity parent)
        {
            if (entity.WorldId != parent.WorldId) Throw("Child and parent Entity come from a different World");

            ref HashSet<int> children = ref entity.World.EntityInfos[parent.EntityId].Children;
            children ??= new HashSet<int>();

            if (children.Add(entity.EntityId)) {
                entity.World.EntityInfos[entity.EntityId].Parents += children.Remove;
            }
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void SetAsParentOf(Entity parent, in Entity child) => child.SetAsChildOf(parent);

        /// <inheritdoc />
        public virtual void RemoveFromChildrenOf(Entity entity, in Entity parent)
        {
            if (entity.WorldId != parent.WorldId) Throw("Child and parent Entity come from a different World");

            HashSet<int> children = entity.World.EntityInfos[parent.EntityId].Children;
            if (children?.Remove(entity.EntityId) ?? false) {
                entity.World.EntityInfos[entity.EntityId].Parents -= children.Remove;
            }
        }

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void RemoveFromParentsOf(Entity parent, in Entity child) => child.RemoveFromChildrenOf(parent);

        /// <inheritdoc />
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public virtual void Dispose(Entity entity)
        {
            Publisher.Publish(entity.WorldId, new EntityDisposingMessage(entity.EntityId));
            Publisher.Publish(entity.WorldId, new EntityDisposedMessage(entity.EntityId));
        }

        /// <inheritdoc />
        public virtual Entity CopyTo(Entity entity, World world)
        {
            Entity copy = entity.IsEnabled() ? world.CreateEntity() : world.CreateDisabledEntity();
            try {
                Publisher.Publish(entity.WorldId, new EntityCopyMessage(entity.EntityId, copy));

                copy.World.EntityInfos[copy.EntityId].Components = GetComponentsReference(entity);
                ref ComponentEnum copyComponents = ref GetComponentsReference(copy);

                if (entity.IsEnabled()) {
                    Publisher.Publish(entity.WorldId, new EntityEnabledMessage(copy.EntityId, copyComponents));
                } else {
                    Publisher.Publish(entity.WorldId, new EntityDisabledMessage(copy.EntityId, copyComponents));
                }
            } catch {
                Dispose(copy);

                throw;
            }

            return copy;
        }
        
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Throw(string message) => throw new InvalidOperationException(message);

        private ref ComponentEnum GetComponentsReference(Entity entity)
        {
            return ref entity.World.EntityInfos[entity.EntityId].Components;
        }
    }
}