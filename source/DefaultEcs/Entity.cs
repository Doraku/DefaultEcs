using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using DefaultEcs.Serialization;
using DefaultEcs.Technical;
using DefaultEcs.Technical.Debug;
using DefaultEcs.Technical.Message;

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

        internal Entity(short worldId, int entityId)
        {
            WorldId = worldId;
            EntityId = entityId;
            Version = World.Worlds[WorldId].EntityInfos[EntityId].Version;
        }

        #endregion

        #region Properties

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ref ComponentEnum Components => ref World.EntityInfos[EntityId].Components;

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

        internal void SetDisabled<T>(in T component) { 
            CheckEntity();
            World.GetEntityMutator().SetDisabled(this, component);
        }

        internal void SetSameAsDisabled<T>(in Entity reference) { 
            CheckEntity();
            World.GetEntityMutator().SetSameAsDisabled<T>(this, reference);
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> is enabled or not.
        /// </summary>
        /// <returns>true if the <see cref="Entity"/> is enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled() { 
            CheckEntity();
            return World.GetEntityAccessor().IsEnabled(this);
        }

        /// <summary>
        /// Enables the current <see cref="Entity"/> so it can appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Enable()
        {
            CheckEntity();
            World.GetEntityMutator().Enable(this);
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> so it does not appear in <see cref="EntitySet"/>.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Disable()
        {
            CheckEntity();
            World.GetEntityMutator().Disable(this);
        }

        /// <summary>
        /// Gets whether the current <see cref="Entity"/> component of type <typeparamref name="T"/> is enabled or not.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/> enabled; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsEnabled<T>() { 
            CheckEntity();
            return World.GetEntityAccessor().IsEnabled<T>(this);
        }

        /// <summary>
        /// Enables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it can appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Enable<T>() { 
            CheckEntity();
            World.GetEntityMutator().Enable<T>(this);
        }

        /// <summary>
        /// Disables the current <see cref="Entity"/> component of type <typeparamref name="T"/> so it does not appear in <see cref="EntitySet"/>.
        /// Does nothing if current <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public void Disable<T>() { 
            CheckEntity();
            World.GetEntityMutator().Disable<T>(this);
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="component">The value of the component.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Max number of component of type <typeparamref name="T"/> reached.</exception>
        public void Set<T>(in T component = default) { 
            CheckEntity();
            World.GetEntityMutator().Set(this, component);
        }

        /// <summary>
        /// Sets the value of the component of type <typeparamref name="T"/> on the current <see cref="Entity"/> to the same instance of an other <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <param name="reference">The other <see cref="Entity"/> used as reference.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> comes from a different <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Reference <see cref="Entity"/> does not have a component of type <typeparamref name="T"/>.</exception>
        public void SetSameAs<T>(in Entity reference) {
            CheckEntity();
            World.GetEntityMutator().SetSameAs<T>(this, reference);
        }

        /// <summary>
        /// Removes the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        public void Remove<T>() {
            CheckEntity();
            World.GetEntityMutator().Remove<T>(this);
        }

        /// <summary>
        /// Returns whether the current <see cref="Entity"/> has a component of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>true if the <see cref="Entity"/> has a component of type <typeparamref name="T"/>; otherwise, false.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Has<T>() {
            CheckEntity();
            return World.GetEntityAccessor().Has<T>(this);
        }

        /// <summary>
        /// Gets the component of type <typeparamref name="T"/> on the current <see cref="Entity"/>.
        /// </summary>
        /// <typeparam name="T">The type of the component.</typeparam>
        /// <returns>A reference to the component.</returns>
        /// <exception cref="Exception"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/> or does not have a component of type <typeparamref name="T"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T Get<T>() {
            CheckEntity();
            return ref World.GetEntityAccessor().Get<T>(this);
        }

        /// <summary>
        /// Makes it so when given <see cref="Entity"/> is disposed, current <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        public void SetAsChildOf(in Entity parent) {
            CheckEntity();
            World.GetEntityMutator().SetAsChildOf(this, parent);
        }

        /// <summary>
        /// Makes it so when current <see cref="Entity"/> is disposed, given <see cref="Entity"/> will also be disposed.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAsParentOf(in Entity child) {
            CheckEntity();
            World.GetEntityMutator().SetAsParentOf(this, child);
        }

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> parents.
        /// </summary>
        /// <param name="parent">The <see cref="Entity"/> which acts as parent.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        public void RemoveFromChildrenOf(in Entity parent) {
            CheckEntity();
            World.GetEntityMutator().RemoveFromChildrenOf(this, parent);
        }

        /// <summary>
        /// Remove the given <see cref="Entity"/> from current <see cref="Entity"/> children.
        /// </summary>
        /// <param name="child">The <see cref="Entity"/> which acts as child.</param>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        /// <exception cref="InvalidOperationException">Child and parent <see cref="Entity"/> come from a different <see cref="DefaultEcs.World"/>.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RemoveFromParentsOf(in Entity child) {
            CheckEntity();
            World.GetEntityMutator().RemoveFromParentsOf(this, child);
        }

        /// <summary>
        /// Gets all the <see cref="Entity"/> setted as children of the current <see cref="Entity"/>.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Entity}"/> of all the current <see cref="Entity"/> children.</returns>
        public IEnumerable<Entity> GetChildren() {
            CheckEntity();
            return World.GetEntityAccessor().GetChildren(this);
        }

        /// <summary>
        /// Creates a copy of current <see cref="Entity"/> with all of its components in the given <see cref="DefaultEcs.World"/>.
        /// </summary>
        /// <param name="world">The <see cref="DefaultEcs.World"/> instance to which copy current <see cref="Entity"/> and its components.</param>
        /// <returns>The created <see cref="Entity"/> in the given <see cref="DefaultEcs.World"/>.</returns>
        /// <exception cref="InvalidOperationException"><see cref="Entity"/> was not created from a <see cref="DefaultEcs.World"/>.</exception>
        public Entity CopyTo(World world) {
            CheckEntity();
            return World.GetEntityMutator().CopyTo(this, world);
        }

        /// <summary>
        /// Calls on <paramref name="reader"/> with all the component of the current <see cref="Entity"/>.
        /// This method is primiraly used for serialization purpose and should not be called in game logic.
        /// </summary>
        /// <param name="reader">The <see cref="IComponentReader"/> instance to be used as callback with the current <see cref="Entity"/> components.</param>
        public void ReadAllComponents(IComponentReader reader) {
            CheckEntity();
            World.GetEntityAccessor().ReadAllComponents(this, reader);                
        } 

        private void CheckEntity() {
            if (WorldId == 0) throw new InvalidOperationException("Entity was not created from a World");
        }
        
        #endregion

        #region IDisposable

        /// <summary>
        /// Clean the current <see cref="Entity"/> of all its components.
        /// The current <see cref="Entity"/> should not be used again after calling this method and <see cref="IsAlive"/> will return false.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Dispose() => World.GetEntityMutator().Dispose(this);

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
