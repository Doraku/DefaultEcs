using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Message;

namespace DefaultEcs
{
    /// <summary>
    /// Represents an item in the <see cref="World"/>.
    /// Only use <see cref="Entity"/> generated from the <see cref="World.CreateEntity"/> method.
    /// </summary>
    [DebuggerTypeProxy(typeof(EntityDebugView))]
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

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ref ComponentEnum Components => ref World.Infos[WorldId].EntityInfos[EntityId].Components;

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is alive or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is alive; otherwise, false.</returns>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsAlive
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => WorldId == 0 ? false : Components[World.IsAliveFlag];
        }

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void Throw(string message) => throw new InvalidOperationException(message);

        internal void SetDisabled<T>(in T component)
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            ComponentManager<T>.GetOrCreate(WorldId).Set(EntityId, component);
        }

        internal void SetSameAsDisabled<T>(in Entity reference)
        {
            if (WorldId == 0) Throw("Entity was not created from a World");
            if (WorldId != reference.WorldId) Throw("Reference Entity comes from a different World");
            ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
            if (!(pool?.Has(reference.EntityId) ?? false)) Throw($"Reference Entity does not have a component of type {nameof(T)}");

            pool.SetSameAs(EntityId, reference.EntityId);
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is enabled or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled() => WorldId == 0 ? false : Components[World.IsEnabledFlag];

        /// <summary>
        /// Enables the current <see cref="Entity"/> so it can appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        public void Enable()
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            ref ComponentEnum components = ref Components;
            components[World.IsEnabledFlag] = true;
            Publisher.Publish(WorldId, new EntityEnabledMessage(EntityId, components));
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> so it does not appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        public void Disable()
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            Components[World.IsEnabledFlag] = false;
            Publisher.Publish(WorldId, new EntityDisabledMessage(EntityId));
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> component of type <typeparamref name="T"/> is enabled or not.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/> enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled<T>() => WorldId == 0 ? false : Components[ComponentManager<T>.Flag];

        /// <summary>
        /// Enables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it can appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        public void Enable<T>()
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            if (Has<T>())
            {
                ref ComponentEnum components = ref Components;
                if (!components[ComponentManager<T>.Flag])
                {
                    components[ComponentManager<T>.Flag] = true;
                    Publisher.Publish(WorldId, new ComponentAddedMessage<T>(EntityId, components));
                }
            }
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it does not appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        public void Disable<T>()
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            ref ComponentEnum components = ref Components;
            if (components[ComponentManager<T>.Flag])
            {
                components[ComponentManager<T>.Flag] = false;
                Publisher.Publish(WorldId, new ComponentRemovedMessage<T>(EntityId, components));
            }
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>(in T component = default)
        {
            if (WorldId == 0) Throw("Entity was not created from a World");

            if (ComponentManager<T>.GetOrCreate(WorldId).Set(EntityId, component))
            {
                ref ComponentEnum components = ref Components;
                components[ComponentManager<T>.Flag] = true;
                if (components[World.IsEnabledFlag])
                {
                    Publisher.Publish(WorldId, new ComponentAddedMessage<T>(EntityId, components));
                }
            }
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/> to the same instance of an other <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="Entity"/> used as reference.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> comes from a different <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void SetSameAs<T>(in Entity reference)
        {
            if (WorldId == 0) Throw("Entity was not created from a World");
            if (WorldId != reference.WorldId) Throw("Reference Entity comes from a different World");
            ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
            if (!(pool?.Has(reference.EntityId) ?? false)) Throw($"Reference Entity does not have a component of type {nameof(T)}");

            if (pool.SetSameAs(EntityId, reference.EntityId))
            {
                ref ComponentEnum components = ref Components;
                components[ComponentManager<T>.Flag] = true;
                if (components[World.IsEnabledFlag])
                {
                    Publisher.Publish(WorldId, new ComponentAddedMessage<T>(EntityId, components));
                }
            }
        }

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        public void Remove<T>()
        {
            if (ComponentManager<T>.Get(WorldId)?.Remove(EntityId) ?? false)
            {
                ref ComponentEnum components = ref Components;
                components[ComponentManager<T>.Flag] = false;
                if (components[World.IsEnabledFlag])
                {
                    Publisher.Publish(WorldId, new ComponentRemovedMessage<T>(EntityId, components));
                }
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
            if (WorldId != parent.WorldId) Throw("Child and parent Entity come from a different World");
            if (WorldId == 0) Throw("Entity was not created from a World");

            ref HashSet<int> children = ref World.Infos[WorldId].EntityInfos[parent.EntityId].Children;
            if (children == null)
            {
                children = new HashSet<int>();
            }

            if (children.Add(EntityId))
            {
                World.Infos[WorldId].EntityInfos[EntityId].Parents += children.Remove;
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
        public void RemoveFromChildrenOf(in Entity parent)
        {
            if (WorldId != parent.WorldId) Throw("Child and parent Entity come from a different World");
            if (WorldId == 0) Throw("Entity was not created from a World");

            HashSet<int> children = World.Infos[WorldId].EntityInfos[parent.EntityId].Children;
            if (children?.Remove(EntityId) ?? false)
            {
                World.Infos[WorldId].EntityInfos[EntityId].Parents -= children.Remove;
            }
        }

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> children.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="World"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveFromParentsOf(in Entity child) => child.RemoveFromChildrenOf(this);

        /// <summary>
        /// Gets all the <see cref="Entity"/> setted as children of the current <see cref="Entity"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Entity}"/> of all the current <see cref="Entity"/> children.</returns>
        public IEnumerable<Entity> GetChildren()
        {
            foreach (int childId in World.Infos[WorldId]?.EntityInfos[EntityId].Children ?? Enumerable.Empty<int>())
            {
                yield return new Entity(WorldId, childId);
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
            if (WorldId == 0) Throw("Entity was not created from a World");

            Entity copy = world.CreateDisabledEntity();
            try
            {
                Publisher.Publish(WorldId, new EntityCopyMessage(EntityId, copy));
                copy.Components = Components.Copy();
                if (IsEnabled())
                {
                    copy.Enable();
                }
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
        public void ReadAllComponents(IComponentReader reader) => Publisher.Publish(WorldId, new ComponentReadMessage(EntityId, reader ?? throw new ArgumentNullException(nameof(reader))));

        #endregion

        #region IDisposable

        /// <summary>
        /// Clean the current <see cref="Entity"/> of all its components.
        /// The current <see cref="Entity"/> should not be used again after calling this method and <see cref="IsAlive"/> will return false.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose()
        {
            Publisher.Publish(WorldId, new EntityDisposingMessage(EntityId));
            Publisher.Publish(WorldId, new EntityDisposedMessage(EntityId));
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

        /// <summary>
        /// Returns a string representation of this instance.
        /// </summary>
        /// <returns>A string representing this instance.</returns>
        public override string ToString() => $"Entity {WorldId}:{EntityId}";

        #endregion
    }
}
