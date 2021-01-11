using System;
using System.Collections.Generic;

namespace DefaultEcs.Hierarchy
{
    internal sealed class HierarchyLevelSetter : IDisposable
    {
        private static readonly HashSet<World> _worlds = new HashSet<World>();

        private readonly EntityMultiMap<Parent> _map;
        private readonly IDisposable _addedSubscription;
        private readonly IDisposable _changedSubscription;
        private readonly IDisposable _removedSubscription;

        private HierarchyLevelSetter(World world)
        {
            _map = world.GetEntities().AsMultiMap<Parent>();

            _addedSubscription = world.SubscribeComponentAdded<Parent>(OnAdded);
            _changedSubscription = world.SubscribeComponentChanged<Parent>(OnChanged);
            _removedSubscription = world.SubscribeComponentRemoved<Parent>(OnRemoved);

            using EntitySet entities = world.GetEntities().With<Parent>().AsSet();

            foreach (ref readonly Entity entity in entities.GetEntities())
            {
                OnAdded(entity, entity.Get<Parent>());
            }
        }

        private void OnAdded(in Entity entity, in Parent value)
        {
            int level = 1;
            if (value.Value.Has<HierarchyLevel>())
            {
                level += value.Value.Get<HierarchyLevel>().Value;
            }

            entity.Set(new HierarchyLevel(level));

            SetChildrenLevel(entity, level + 1);
        }

        private void OnChanged(in Entity entity, in Parent oldValue, in Parent newValue) => OnAdded(entity, newValue);

        private void OnRemoved(in Entity entity, in Parent value)
        {
            entity.Remove<HierarchyLevel>();

            SetChildrenLevel(entity, 1);
        }

        private void SetChildrenLevel(in Entity entity, int level)
        {
            if (_map.TryGetEntities(new Parent(entity), out ReadOnlySpan<Entity> children))
            {
                foreach (ref readonly Entity child in children)
                {
                    if (level > 0)
                    {
                        child.Set(new HierarchyLevel(level));
                    }
                    else
                    {
                        child.Remove<HierarchyLevel>();
                    }

                    SetChildrenLevel(child, level + 1);
                }
            }
        }

        internal static void Setup(World world)
        {
            if (_worlds.Add(world))
            {
                HierarchyLevelSetter setter = new HierarchyLevelSetter(world);
                world.SubscribeWorldDisposed(_ => setter.Dispose());
            }
        }

        #region IDisposable

        public void Dispose()
        {
            _worlds.Remove(_map.World);
            _map.Dispose();
            _addedSubscription.Dispose();
            _changedSubscription.Dispose();
            _removedSubscription.Dispose();
        }

        #endregion
    }
}
