using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultEcs.Internal;
using DefaultEcs.Internal.Diagnostics;
using DefaultEcs.Internal.Messages;
using DefaultEcs.Serialization;

namespace DefaultEcs
{
    /// <summary>
    /// Represents an item in the <see cref="DefaultEcs.World"/>.
    /// Only use <see cref="Entity"/> generated from the <see cref="World.CreateEntity"/> method.
    /// </summary>
    [DebuggerTypeProxy(typeof(EntityDebugView))]
    [StructLayout(LayoutKind.Explicit)]
    public readonly struct Entity : IDisposable, IEquatable<Entity>
    {
        #region Fields

        [FieldOffset(0)]
        internal readonly short Version;

        [FieldOffset(2)]
        internal readonly short WorldId;

        [FieldOffset(4)]
        internal readonly int EntityId;

        #endregion

        #region Initialisation

        internal Entity(short worldId)
        {
            WorldId = worldId;
            EntityId = -1;
            Version = -1;
        }

        internal Entity(short worldId, int entityId)
        {
            WorldId = worldId;
            EntityId = entityId;
            Version = World.Worlds[WorldId].EntityInfos[EntityId].Version;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        internal ref ComponentEnum Components => ref World.EntityInfos[EntityId].Components;

        /// <summary>
        /// Gets the <see cref="DefaultEcs.World"/> instance from which current <see cref="Entity"/> originate.
        /// </summary>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public World World => World.Worlds[WorldId];

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is alive or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is alive; otherwise, false.</returns>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public bool IsAlive => WorldId != 0 && World.EntityInfos[EntityId].IsAlive(Version);

        #endregion

        #region Methods

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void ThrowIf(bool actuallyThrow, string message)
        {
            if (actuallyThrow)
            {
                throw new InvalidOperationException(message);
            }
        }

        private void InnerSet<T>(bool isNew)
        {
            ref ComponentEnum components = ref Components;

            if (isNew)
            {
                components[ComponentManager<T>.Flag] = true;
                Publisher.Publish(WorldId, new EntityComponentAddedMessage<T>(EntityId, components));
            }
            else
            {
                Publisher.Publish(WorldId, new EntityComponentChangedMessage<T>(EntityId, components));

                Enable<T>();
            }

            if (ComponentManager<T>.GetPrevious(WorldId) is ComponentPool<T> previousPool && Has<T>())
            {
                previousPool.Set(EntityId, Get<T>());
            }
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is enabled or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled() => WorldId != 0 && Components[World.IsEnabledFlag];

        /// <summary>
        /// Enables the current <see cref="Entity"/> so it can appear in <see cref="EntitySet"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Enable()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            ref ComponentEnum components = ref Components;
            if (!components[World.IsEnabledFlag])
            {
                components[World.IsEnabledFlag] = true;
                Publisher.Publish(WorldId, new EntityEnabledMessage(EntityId, components));
            }
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> so it does not appear in <see cref="EntitySet"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Disable()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            ref ComponentEnum components = ref Components;
            if (components[World.IsEnabledFlag])
            {
                components[World.IsEnabledFlag] = false;
                Publisher.Publish(WorldId, new EntityDisabledMessage(EntityId, components));
            }
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> component of type <typeparamref name="T"/> is enabled or not.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/> enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled<T>() => WorldId != 0 && Components[ComponentManager<T>.Flag];

        /// <summary>
        /// Enables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it can appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Enable<T>()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            if (Has<T>())
            {
                ref ComponentEnum components = ref Components;
                if (!components[ComponentManager<T>.Flag])
                {
                    components[ComponentManager<T>.Flag] = true;
                    Publisher.Publish(WorldId, new EntityComponentEnabledMessage<T>(EntityId, components));
                }
            }
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it does not appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Disable<T>()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            ref ComponentEnum components = ref Components;
            if (components[ComponentManager<T>.Flag])
            {
                components[ComponentManager<T>.Flag] = false;
                Publisher.Publish(WorldId, new EntityComponentDisabledMessage<T>(EntityId, components));
            }
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>(in T component)
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            InnerSet<T>(ComponentManager<T>.GetOrCreate(WorldId).Set(EntityId, component));
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> to its default value on the current <see cref="Entity"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>() => Set<T>(default);

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/> to the same instance of an other <see cref="Entity"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="Entity"/> used as reference.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> comes from a different <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void SetSameAs<T>(in Entity reference)
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");
            ThrowIf(WorldId != reference.WorldId, "Reference Entity comes from a different World");

            ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
            ThrowIf(!(pool?.Has(reference.EntityId) ?? false), $"Reference Entity does not have a component of type {typeof(T)}");

            InnerSet<T>(pool.SetSameAs(EntityId, reference.EntityId));
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/> to the same instance of an other <see cref="Entity"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException"><see cref="World"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void SetSameAsWorld<T>()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");

            ComponentPool<T> pool = ComponentManager<T>.Get(WorldId);
            ThrowIf(!(pool?.Has(0) ?? false), $"World does not have a component of type {typeof(T)}");

            InnerSet<T>(pool.SetSameAs(EntityId, 0));
        }

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        public void Remove<T>()
        {
            if (ComponentManager<T>.Get(WorldId)?.Remove(EntityId) == true)
            {
                ref ComponentEnum components = ref Components;
                components[ComponentManager<T>.Flag] = false;
                Publisher.Publish(WorldId, new EntityComponentRemovedMessage<T>(EntityId, components));
                ComponentManager<T>.GetPrevious(WorldId)?.Remove(EntityId);
            }
        }

        /// <summary>
        /// Notifies the value of the component of type <typeparamref name="T"/> has changed.
        /// This method is not thread safe.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void NotifyChanged<T>()
        {
            ThrowIf(WorldId == 0, "Entity was not created from a World");
            ThrowIf(!Has<T>(), $"Entity does not have a component of type {typeof(T)}");

            Publisher.Publish(WorldId, new EntityComponentChangedMessage<T>(EntityId, Components));

            if (ComponentManager<T>.GetPrevious(WorldId) is ComponentPool<T> previousPool && Has<T>())
            {
                previousPool.Set(EntityId, Get<T>());
            }
        }

        /// <summary>
        /// Returns whether the current <see cref="Entity"/> has a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has<T>() => ComponentManager<T>.Get(WorldId)?.Has(EntityId) ?? false;

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/> or does not have a component of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get<T>() => ref ComponentManager<T>.Pools[WorldId].Get(EntityId);

        /// <summary>
        /// Creates a copy of current <see cref="Entity"/> with all of its components in the given <see cref="DefaultEcs.World"/> using the given <see cref="ComponentCloner"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> instance to which copy current <see cref="Entity"/> and its components.</param>
        /// <param name="cloner">The <see cref="ComponentCloner"/> to use to copy the components.</param>
        /// <returns>The created <see cref="Entity"/> in the given <see cref="DefaultEcs.World"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> or <paramref name="cloner"/> was null.</exception>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public Entity CopyTo(World world, ComponentCloner cloner)
        {
            world.ThrowIfNull();
            cloner.ThrowIfNull();

            ThrowIf(WorldId == 0, "Entity was not created from a World");

            Entity copy = world.CreateEntity();

            if (!IsEnabled())
            {
                copy.Disable();
            }

            try
            {
                cloner.Clone(this, copy);
            }
            catch
            {
                copy.Dispose();

                throw;
            }

            return copy;
        }

        /// <summary>
        /// Creates a copy of current <see cref="Entity"/> with all of its components in the given <see cref="DefaultEcs.World"/>.
        /// This method is not thread safe.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> instance to which copy current <see cref="Entity"/> and its components.</param>
        /// <returns>The created <see cref="Entity"/> in the given <see cref="DefaultEcs.World"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public Entity CopyTo(World world) => CopyTo(world, ComponentCloner.Instance);

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the component of the current <see cref="Entity"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentReader"/> instance to be used as callback with the current <see cref="Entity"/> components.</param>
        /// <exception cref="ArgumentNullException"><paramref name="reader"/> is null.</exception>
        public void ReadAllComponents(IComponentReader reader) => Publisher.Publish(WorldId, new ComponentReadMessage(EntityId, reader.ThrowIfNull()));

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
        public bool Equals(Entity other)
            => EntityId == other.EntityId
            && WorldId == other.WorldId
            && Version == other.Version;

        #endregion

        #region Operator

        /// <summary>Determines whether two specified entities are the same.</summary>
        /// <param name="a">The first <see cref="Entity"/> to compare.</param>
        /// <param name="b">The second <see cref="Entity"/> to compare.</param>
        /// <returns>
        /// true if the value of <paramref name="a" /> is the same as the value of <paramref name="b" />;
        /// otherwise, false.
        /// </returns>
        public static bool operator ==(Entity a, Entity b) => a.Equals(b);

        /// <summary>Determines whether two specified entities are not the same.</summary>
        /// <param name="a">The first <see cref="Entity"/> to compare.</param>
        /// <param name="b">The second <see cref="Entity"/> to compare.</param>
        /// <returns>
        /// true if the value of <paramref name="a" /> is not the same as the value of <paramref name="b" />;
        /// otherwise, false.
        /// </returns>
        public static bool operator !=(Entity a, Entity b) => !a.Equals(b);

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
        public override string ToString() => $"Entity {WorldId}:{EntityId}.{Version}";

        #endregion
    }
}
