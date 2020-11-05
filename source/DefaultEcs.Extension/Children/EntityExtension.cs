using System.Collections.Generic;

namespace DefaultEcs.Children
{
    public static class EntityExtension
    {
        private readonly struct Children
        {
            public readonly HashSet<Entity> Value;

            public Children(HashSet<Entity> value)
            {
                Value = value;
            }
        }

        private static readonly HashSet<World> _worlds = new HashSet<World>();

        private static void OnEntityDisposed(in Entity entity)
        {
            if (entity.Has<Children>())
            {
                HashSet<Entity> children = entity.Get<Children>().Value;
                entity.Remove<Children>();

                foreach (Entity child in children)
                {
                    if (child.IsAlive)
                    {
                        child.Dispose();
                    }
                }
            }
        }

        public static void SetAsParentOf(this Entity parent, Entity child)
        {
            if (_worlds.Add(parent.World))
            {
                parent.World.SubscribeEntityDisposed(OnEntityDisposed);
                parent.World.SubscribeWorldDisposed(w => _worlds.Remove(w));
            }

            HashSet<Entity> children;
            if (!parent.Has<Children>())
            {
                children = new HashSet<Entity>();
                parent.Set(new Children(children));
            }
            else
            {
                children = parent.Get<Children>().Value;
            }

            children.Add(child);
        }

        public static void RemoveFromParentsOf(this Entity parent, Entity child)
        {
            if (parent.Has<Children>())
            {
                parent.Get<Children>().Value.Remove(child);
            }
        }

        public static void SetAsChildOf(this Entity child, Entity parent) => parent.SetAsParentOf(child);

        public static void RemoveFromChildrenOf(this Entity child, Entity parent) => parent.RemoveFromParentsOf(child);
    }
}
