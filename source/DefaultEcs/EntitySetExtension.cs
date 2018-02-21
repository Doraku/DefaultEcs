using System;
using System.Runtime.CompilerServices;

namespace DefaultEcs
{
    /// <summary>
    /// Provides a set of static methods for getting data from an <see cref="EntitySet"/>.
    /// </summary>
    public static class EntitySetExtension
    {
        /// <summary>
        /// Copies <see cref="Entity"/> of an <see cref="EntitySet"/> to a destination <see cref="Span{Entity}"/>.
        /// Passed parameter destination should be created with the correct length.
        /// </summary>
        /// <param name="entitySet">The <see cref="EntitySet"/> from which to get <see cref="Entity"/>.</param>
        /// <param name="destination">The <see cref="Span{Entity}"/> on which to copy <see cref="Entity"/>.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CopyEntitiesTo(this EntitySet entitySet, Span<Entity> destination) => entitySet.GetEntities().CopyTo(destination);

        /// <summary>
        /// Copies <see cref="Entity"/> of an <see cref="EntitySet"/> to an <see cref="Array"/>.
        /// </summary>
        /// <param name="entitySet">The <see cref="EntitySet"/> from which to get <see cref="Entity"/>.</param>
        /// <returns>The <see cref="Array"/> with all the <see cref="Entity"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Entity[] CopyEntities(this EntitySet entitySet) => entitySet.GetEntities().ToArray();

        //public static IEnumerable<(Entity, T)> CopyWithComponents<T>(this EntitySet entitySet)
        //{
        //    (Entity, T)[] items = new(Entity, T)[entitySet.Count];

        //    int i = 0;
        //    foreach (Entity entity in entitySet.GetEntities())
        //    {
        //        items[i++].Item1 = entity;
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T) item = ref items[i];
        //        item.Item2 = item.Item1.Get<T>();
        //    }

        //    return items;
        //}

        //public static IEnumerable<(Entity, T1, T2)> CopyWithComponents<T1, T2>(this EntitySet entitySet)
        //{
        //    (Entity, T1, T2)[] items = new(Entity, T1, T2)[entitySet.Count];

        //    int i = 0;
        //    foreach (Entity entity in entitySet.GetEntities())
        //    {
        //        items[i++].Item1 = entity;
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2) item = ref items[i];
        //        item.Item2 = item.Item1.Get<T1>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2) item = ref items[i];
        //        item.Item3 = item.Item1.Get<T2>();
        //    }

        //    return items;
        //}

        //public static IEnumerable<(Entity, T1, T2, T3)> CopyWithComponents<T1, T2, T3>(this EntitySet entitySet)
        //{
        //    (Entity, T1, T2, T3)[] items = new(Entity, T1, T2, T3)[entitySet.Count];

        //    int i = 0;
        //    foreach (Entity entity in entitySet.GetEntities())
        //    {
        //        items[i++].Item1 = entity;
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3) item = ref items[i];
        //        item.Item2 = item.Item1.Get<T1>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3) item = ref items[i];
        //        item.Item3 = item.Item1.Get<T2>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3) item = ref items[i];
        //        item.Item4 = item.Item1.Get<T3>();
        //    }

        //    return items;
        //}

        //public static IEnumerable<(Entity, T1, T2, T3, T4)> CopyWithComponents<T1, T2, T3, T4>(this EntitySet entitySet)
        //{
        //    (Entity, T1, T2, T3, T4)[] items = new(Entity, T1, T2, T3, T4)[entitySet.Count];

        //    int i = 0;
        //    foreach (Entity entity in entitySet.GetEntities())
        //    {
        //        items[i++].Item1 = entity;
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3, T4) item = ref items[i];
        //        item.Item2 = item.Item1.Get<T1>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3, T4) item = ref items[i];
        //        item.Item3 = item.Item1.Get<T2>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3, T4) item = ref items[i];
        //        item.Item4 = item.Item1.Get<T3>();
        //    }
        //    for (i = 0; i < items.Length; ++i)
        //    {
        //        ref (Entity, T1, T2, T3, T4) item = ref items[i];
        //        item.Item5 = item.Item1.Get<T4>();
        //    }

        //    return items;
        //}
    }
}
