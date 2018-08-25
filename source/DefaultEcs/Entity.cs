using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents an item in the <see cref="World"/>.
    /// Only use <see cref="Entity"/> generated from the <see cref="World.CreateEntity"/> method.
    /// </summary>
    public readonly struct Entity : IDisposable, IEquatable<Entity>
    {
        #region Fields

        internal readonly int WorldId;
        internal readonly int EntityId;

        #endregion

        #region Initialisation

        internal Entity(int worldId, int entityId)
        {
            WorldId = worldId;
            EntityId = entityId;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// If current <see cref="Entity"/> did not have a component of type <typeparamref name="T"/>, a <see cref="ComponentAddedMessage{T}"/> message is published.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>(in T component = default)
        {
            if (WorldId == 0)
            {
                throw new InvalidOperationException("Entity was not created from a World");
            }

            if (ComponentManager<T>.GetOrCreate(WorldId).Set(EntityId, component))
            {
                ref ComponentEnum components = ref World.EntityInfos[WorldId][EntityId].Components;
                components[ComponentManager<T>.Flag] = true;

                World.Publish(WorldId, new ComponentAddedMessage<T>(EntityId, components));
            }
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current Entity to the same instance of an other <see cref="Entity"/>.
        /// If current <see cref="Entity"/> did not have a component of type <typeparamref name="T"/>, a <see cref="ComponentAddedMessage{T}"/> message is published.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="Entity"/> used as reference.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> comes from a different <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void SetSameAs<T>(in Entity reference)
        {
            if (WorldId == 0)
            {
                throw new InvalidOperationException("Entity was not created from a World");
            }
            if (WorldId != reference.WorldId)
            {
                throw new InvalidOperationException("Reference Entity comes from a different World");
            }
            ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
            if (!(pool?.Has(reference.EntityId) ?? false))
            {
                throw new InvalidOperationException($"Reference Entity does not have a component of type {nameof(T)}");
            }

            if (pool.SetSameAs(EntityId, reference.EntityId))
            {
                ref ComponentEnum components = ref World.EntityInfos[WorldId][EntityId].Components;
                components[ComponentManager<T>.Flag] = true;

                World.Publish(WorldId, new ComponentAddedMessage<T>(EntityId, components));
            }
        }

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// If current <see cref="Entity"/> had a component of type <typeparamref name="T"/>, a <see cref="ComponentRemovedMessage{T}"/> message is published.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        public void Remove<T>()
        {
            if (ComponentManager<T>.Get(WorldId)?.Remove(EntityId) ?? false)
            {
                ref ComponentEnum components = ref World.EntityInfos[WorldId][EntityId].Components;
                components[ComponentManager<T>.Flag] = false;
                World.Publish(WorldId, new ComponentRemovedMessage<T>(EntityId, components));
            }
        }

        /// <summary>
        /// Returns whether the current <see cref="Entity"/> has a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has<T>() => WorldId < ComponentManager<T>.Pools.Length && (ComponentManager<T>.Pools[WorldId]?.Has(EntityId) ?? false);

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception"><see cref="Entity"/> was not created from a <see cref="World"/> or does not have a component of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get<T>() => ref ComponentManager<T>.Pools[WorldId].Get(EntityId);

        /// <summary>
        /// Makes it so when given <see cref="Entity"/> is disposed, current <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="World"/>.</exception>
        public void SetAsChildOf(in Entity parent)
        {
            if (WorldId != parent.WorldId)
            {
                throw new InvalidOperationException("Child and parent Entity come from a different World");
            }
            if (WorldId == 0)
            {
                throw new InvalidOperationException("Entity was not created from a World");
            }

            ref HashSet<int> children = ref World.EntityInfos[WorldId][parent.EntityId].Children;
            if (children == null)
            {
                children = new HashSet<int>();
            }

            if (children.Add(EntityId))
            {
                World.EntityInfos[WorldId][EntityId].Parents += children.Remove;
            }
        }

        /// <summary>
        /// Makes it so when current <see cref="Entity"/> is disposed, given <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="World"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAsParentOf(in Entity child) => child.SetAsChildOf(this);

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> parents.
        /// </summary>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="World"/>.</exception>
        public void RemoveFromParents(in Entity parent)
        {
            if (WorldId != parent.WorldId)
            {
                throw new InvalidOperationException("Child and parent Entity come from a different World");
            }
            if (WorldId == 0)
            {
                throw new InvalidOperationException("Entity was not created from a World");
            }

            HashSet<int> children = World.EntityInfos[WorldId][parent.EntityId].Children;
            if (children?.Remove(EntityId) ?? false)
            {
                World.EntityInfos[WorldId][EntityId].Parents -= children.Remove;
            }
        }

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> children.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="World"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveFromChildren(in Entity child) => child.RemoveFromParents(this);

        /// <summary>
        /// Gets all the <see cref="Entity"/> setted as children of the current <see cref="Entity"/>.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entity> GetChildren()
        {
            HashSet<int> children = World.EntityInfos[WorldId][EntityId].Children;

            if (children != null)
            {
                foreach (int childId in children)
                {
                    yield return new Entity(WorldId, childId);
                }
            }
        }

        /// <summary>
        /// Creates a copy of current <see cref="Entity"/> with all of its components in the given <see cref="World"/>.
        /// </summary>
        /// <param name="world">The <see cref="World"/> instance to which copy current <see cref="Entity"/> and its components.</param>
        /// <returns>The created <see cref="Entity"/> in the given <see cref="World"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        public Entity CopyTo(World world)
        {
            if (WorldId == 0)
            {
                throw new InvalidOperationException("Entity was not created from a World");
            }

            Entity copy = world.CreateEntity();
            try
            {
                World.Publish(WorldId, new EntityCopyMessage(EntityId, copy));
            }
            catch
            {
                copy.Dispose();

                throw;
            }

            return copy;
        }

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the component of the current <see cref="Entity"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentReader"/> instance to be used as callback with the current <see cref="Entity"/> components.</param>
        public void ReadAllComponents(IComponentReader reader) => World.Publish(WorldId, new ComponentReadMessage(EntityId, reader ?? throw new ArgumentNullException(nameof(reader))));

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public bool IsEnable<T>()
        //{
        //    ThrowIfNull();

        //    return World.EntityComponents[WorldId][EntityId][ComponentManager<T>.Flag];
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public void Disable<T>()
        //{
        //    ThrowIfNull();

        //    ref ComponentEnum components = ref World.EntityComponents[WorldId][EntityId];
        //    if (components[ComponentManager<T>.Flag])
        //    {
        //        components[ComponentManager<T>.Flag] = false;
        //        World.Publish(WorldId, new ComponentRemovedMessage<T>(this, components));
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public void Enable<T>()
        //{
        //    ThrowIfNull();

        //    if (Has<T>())
        //    {
        //        ref ComponentEnum components = ref World.EntityComponents[WorldId][EntityId];
        //        if (!components[ComponentManager<T>.Flag])
        //        {
        //            components[ComponentManager<T>.Flag] = true;
        //            World.Publish(WorldId, new ComponentAddedMessage<T>(this, components));
        //        }
        //    }
        //}

        #endregion

        #region IDisposable

        /// <summary>
        /// Clean the current <see cref="Entity"/> of all its components and a <see cref="EntityDisposedMessage"/> message is published.
        /// The current <see cref="Entity"/> should not be used again after calling this method.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            World.Publish(WorldId, new EntityDisposedMessage(EntityId));
        }

        #endregion

        #region IEquatable

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Entity other) => EntityId == other.EntityId && WorldId == other.WorldId;

        #endregion

        #region Object

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value;
        /// otherwise, false.
        /// </returns>
        public override bool Equals(object obj) => obj is Entity entity && Equals(entity);

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode() => EntityId;

        #endregion
    }
}
