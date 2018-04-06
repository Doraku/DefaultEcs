namespace DefaultEcs
{
    /// <summary>
    /// Provides a set of static methods for getting data from an <see cref="EntitySet"/>.
    /// </summary>
    public static class EntitySetExtension
    {
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

        //public static void CopyComponentsTo<T>(this EntitySet entitySet, Span<T> destination)
        //    where T : struct
        //{
        //    Span<int> ids = stackalloc int[destination.Length];
        //    ComponentPool<T> pool = ComponentManager<T>.GetOrCreate(entitySet.WorldId);

        //    //ReadOnlySpan<Entity> entities = entitySet.GetEntities();
        //    //for (int i = 0; i < ids.Length; ++i)
        //    //{
        //    //    ids[i] = entities[i].EntityId;
        //    //}
        //    //ReadOnlySpan<int> componentIds = pool.Mapping;
        //    //for (int i = 0; i < ids.Length; ++i)
        //    //{
        //    //    ids[i] = componentIds[ids[i]];
        //    //}
        //    //ReadOnlySpan<T> components = pool.Items.AsReadOnlySpan();
        //    //for (int i = 0; i < ids.Length; ++i)
        //    //{
        //    //    destination[i] = components[ids[i]];
        //    //}
        //    unsafe
        //    {
        //        //fixed (Entity* entityP = entitySet.Entities)
        //        //{
        //        //    Entity* entity = entityP;
        //        //    for (int i = 0; i < ids.Length; ++i)
        //        //    {
        //        //        ids[i] = (*entity).EntityId;
        //        //        ++entity;
        //        //    }
        //        //}
        //        fixed (int* componentIds = pool.Mapping)
        //        {
        //            for (int i = 0; i < ids.Length; ++i)
        //            {
        //                ids[i] = *(componentIds + entitySet.Entities[i].EntityId);
        //            }
        //        }

        //        ReadOnlySpan<T> components = pool.Items.AsReadOnlySpan();
        //        for (int i = 0; i < ids.Length; ++i)
        //        {
        //            destination[i] = components[ids[i]];
        //        }
        //    }
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
