//using System;
//using DefaultEcs.Technical;

//namespace DefaultEcs
//{
//    /// <summary>
//    /// Provides a set of static methods for getting data from an <see cref="EntitySet"/>.
//    /// </summary>
//    public static class EntitySetExtension
//    {
//        //public static IEnumerable<(Entity, T)> CopyWithComponents<T>(this EntitySet entitySet)
//        //{
//        //    (Entity, T)[] items = new(Entity, T)[entitySet.Count];

//        //    int i = 0;
//        //    foreach (Entity entity in entitySet.GetEntities())
//        //    {
//        //        items[i++].Item1 = entity;
//        //    }
//        //    for (i = 0; i < items.Length; ++i)
//        //    {
//        //        ref (Entity, T) item = ref items[i];
//        //        item.Item2 = item.Item1.Get<T>();
//        //    }

//        //    return items;
//        //}

//        //public static IEnumerable<(Entity, T1, T2)> CopyWithComponents<T1, T2>(this EntitySet entitySet)
//        //{
//        //    (Entity, T1, T2)[] items = new(Entity, T1, T2)[entitySet.Count];

//        //    int i = 0;
//        //    foreach (Entity entity in entitySet.GetEntities())
//        //    {
//        //        items[i++].Item1 = entity;
//        //    }
//        //    for (i = 0; i < items.Length; ++i)
//        //    {
//        //        ref (Entity, T1, T2) item = ref items[i];
//        //        item.Item2 = item.Item1.Get<T1>();
//        //    }
//        //    for (i = 0; i < items.Length; ++i)
//        //    {
//        //        ref (Entity, T1, T2) item = ref items[i];
//        //        item.Item3 = item.Item1.Get<T2>();
//        //    }

//        //    return items;
//        //}

//        ///// <summary>
//        ///// 
//        ///// </summary>
//        ///// <typeparam name="T"></typeparam>
//        ///// <param name="entities"></param>
//        ///// <param name="destination"></param>
//        //public static unsafe void CopyComponentsTo<T>(this ReadOnlySpan<Entity> entities, Span<T> destination)
//        //    where T : unmanaged
//        //{
//        //    if (entities.Length > 0)
//        //    {
//        //        ComponentPool<T> pool = ComponentManager<T>.GetOrCreate(entities[0].WorldId);
//        //        fixed (int* componentIds = pool._mapping)
//        //        fixed (T* componentSource = pool._components)
//        //        {
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                destination[i] = *(componentSource + *(componentIds + entities[i].EntityId));
//        //            }
//        //        }
//        //    }
//        //}
//        ///// <summary>
//        ///// 
//        ///// </summary>
//        ///// <typeparam name="T1"></typeparam>
//        ///// <typeparam name="T2"></typeparam>
//        ///// <param name="entities"></param>
//        ///// <param name="destination"></param>
//        //public static unsafe void CopyComponentsTo<T1, T2>(this ReadOnlySpan<Entity> entities, Span<(T1, T2)> destination)
//        //    where T1 : unmanaged
//        //    where T2 : unmanaged
//        //{
//        //    if (entities.Length > 0)
//        //    {
//        //        fixed (Entity* e = entities)
//        //        {
//        //            int* id = (int*)e;

//        //            ComponentPool<T1> poolT1 = ComponentManager<T1>.GetOrCreate(*id);
//        //            ComponentPool<T2> poolT2 = ComponentManager<T2>.GetOrCreate(*id);
//        //            fixed (int* componentT1Ids = poolT1._mapping)
//        //            fixed (T1* componentT1Source = poolT1._components)
//        //            fixed (int* componentT2Ids = poolT2._mapping)
//        //            fixed (T2* componentT2Source = poolT2._components)
//        //            {
//        //                ++id;
//        //                for (int i = 0; i < destination.Length; ++i)
//        //                {
//        //                    destination[i].Item1 = *(componentT1Source + *(componentT1Ids + *id));
//        //                    destination[i].Item2 = *(componentT2Source + *(componentT2Ids + *id));
//        //                    id += 2;
//        //                }
//        //            }
//        //        }
//        //    }
//        //}
//        ///// <summary>
//        ///// 
//        ///// </summary>
//        ///// <typeparam name="T1"></typeparam>
//        ///// <typeparam name="T2"></typeparam>
//        ///// <typeparam name="T3"></typeparam>
//        ///// <param name="entities"></param>
//        ///// <param name="destination"></param>
//        //public static unsafe void CopyComponentsTo<T1, T2, T3>(this ReadOnlySpan<Entity> entities, Span<(T1, T2, T3)> destination)
//        //    where T1 : unmanaged
//        //    where T2 : unmanaged
//        //    where T3 : unmanaged
//        //{
//        //    if (entities.Length > 0)
//        //    {
//        //        ComponentPool<T1> poolT1 = ComponentManager<T1>.GetOrCreate(entities[0].WorldId);
//        //        ComponentPool<T2> poolT2 = ComponentManager<T2>.GetOrCreate(entities[0].WorldId);
//        //        ComponentPool<T3> poolT3 = ComponentManager<T3>.GetOrCreate(entities[0].WorldId);
//        //        fixed (int* componentT1Ids = poolT1._mapping)
//        //        fixed (T1* componentT1Source = poolT1._components)
//        //        fixed (int* componentT2Ids = poolT2._mapping)
//        //        fixed (T2* componentT2Source = poolT2._components)
//        //        fixed (int* componentT3Ids = poolT3._mapping)
//        //        fixed (T3* componentT3Source = poolT3._components)
//        //        {
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                int id = entities[i].EntityId;
//        //                destination[i].Item1 = *(componentT1Source + *(componentT1Ids + id));
//        //                destination[i].Item2 = *(componentT2Source + *(componentT2Ids + id));
//        //                destination[i].Item3 = *(componentT3Source + *(componentT3Ids + id));
//        //            }
//        //        }
//        //    }
//        //}

//        ///// <summary>
//        ///// 
//        ///// </summary>
//        //public struct Pouet
//        //{
//        //    /// <summary>
//        //    /// 
//        //    /// </summary>
//        //    public int Item1;
//        //    /// <summary>
//        //    /// 
//        //    /// </summary>
//        //    public uint Item2;
//        //    /// <summary>
//        //    /// 
//        //    /// </summary>
//        //    public long Item3;
//        //}

//        ///// <summary>
//        ///// 
//        ///// </summary>
//        ///// <param name="entities"></param>
//        ///// <param name="destination"></param>
//        //public static unsafe void CopyComponentsTo(this ReadOnlySpan<Entity> entities, Span<Pouet> destination)
//        //{
//        //    if (entities.Length > 0)
//        //    {
//        //        ComponentPool<int> poolT1 = ComponentManager<int>.GetOrCreate(entities[0].WorldId);
//        //        ComponentPool<uint> poolT2 = ComponentManager<uint>.GetOrCreate(entities[0].WorldId);
//        //        ComponentPool<long> poolT3 = ComponentManager<long>.GetOrCreate(entities[0].WorldId);
//        //        fixed (int* componentT1Ids = poolT1._mapping)
//        //        fixed (int* componentT1Source = poolT1._components)
//        //        fixed (int* componentT2Ids = poolT2._mapping)
//        //        fixed (uint* componentT2Source = poolT2._components)
//        //        fixed (int* componentT3Ids = poolT3._mapping)
//        //        fixed (long* componentT3Source = poolT3._components)
//        //        fixed (Pouet* p = destination)
//        //        fixed (Entity* e = entities)
//        //        {
//        //            Pouet* pouet = p;
//        //            int* id = (int*)e;
//        //            ++id;
//        //            for (int i = 0; i < entities.Length; ++i)
//        //            {
//        //                (*pouet).Item1 = *(componentT1Source + *(componentT1Ids + *id));
//        //                (*pouet).Item2 = *(componentT2Source + *(componentT2Ids + *id));
//        //                (*pouet).Item3 = *(componentT3Source + *(componentT3Ids + *id));
//        //                id += 2;
//        //                ++pouet;
//        //            }
//        //        }
//        //    }
//        //}
//        //public static unsafe void CopyComponentsTo<T1, T2>(this ReadOnlySpan<Entity> entities, Span<(T1, T2)> destination)
//        //    where T1 : unmanaged
//        //    where T2 : unmanaged
//        //{
//        //    if (entities.Length > 0)
//        //    {
//        //        int* startIds = stackalloc int[entities.Length];

//        //        int* ids = startIds;
//        //        for (int i = 0; i < entities.Length; ++i)
//        //        {
//        //            *ids = entities[i].EntityId;
//        //            ++ids;
//        //        }

//        //        ComponentPool<T1> poolT1 = ComponentManager<T1>.GetOrCreate(entities[0].WorldId);
//        //        fixed (int* componentIds = poolT1._mapping)
//        //        fixed (T1* componentSource = poolT1._components)
//        //        {
//        //            ids = startIds;
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                destination[i].Item1 = *(componentSource + *(componentIds + *ids));
//        //                ++ids;
//        //            }
//        //        }

//        //        ids = startIds;
//        //        for (int i = 0; i < entities.Length; ++i)
//        //        {
//        //            *ids = entities[i].EntityId;
//        //            ++ids;
//        //        }

//        //        ComponentPool<T2> poolT2 = ComponentManager<T2>.GetOrCreate(entities[0].WorldId);
//        //        fixed (int* componentIds = poolT2._mapping)
//        //        fixed (T2* componentSource = poolT2._components)
//        //        {
//        //            ids = startIds;
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                destination[i].Item2 = *(componentSource + *(componentIds + *ids));
//        //                ++ids;
//        //            }
//        //        }
//        //    }
//        //}

//        //public static unsafe void CopyComponentsToTemp<T>(this ReadOnlySpan<Entity> entities, Span<T> destination)
//        //    where T : unmanaged
//        //{
//        //    fixed (Entity* entity = entities)
//        //    fixed (T* componentDestination = destination)
//        //    {
//        //        int* entityId = (int*)entity;
//        //        T* component = componentDestination;
//        //        ComponentPool<T> pool = ComponentManager<T>.GetOrCreate(*entityId);
//        //        fixed (int* componentIds = pool._mapping)
//        //        fixed (T* componentSource = pool._components)
//        //        {
//        //            --entityId;
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                entityId += 2;
//        //                *component = *(componentSource + *(componentIds + *entityId));
//        //                ++component;
//        //            }
//        //        }
//        //    }
//        //}
//        //public static unsafe void CopyComponentsToTemp<T1, T2>(this ReadOnlySpan<Entity> entities, Span<(T1, T2)> destination)
//        //    where T1 : unmanaged
//        //    where T2 : unmanaged
//        //{
//        //    fixed (Entity* entity = entities)
//        //    {
//        //        int* entityId = (int*)entity;
//        //        ComponentPool<T1> poolT1 = ComponentManager<T1>.GetOrCreate(*entityId);
//        //        fixed (int* componentIds = poolT1._mapping)
//        //        fixed (T1* componentSource = poolT1._components)
//        //        {
//        //            --entityId;
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                entityId += 2;
//        //                destination[i].Item1 = *(componentSource + *(componentIds + *entityId));
//        //            }
//        //        }

//        //        entityId = (int*)entity;
//        //        ComponentPool<T2> poolT2 = ComponentManager<T2>.GetOrCreate(*entityId);
//        //        fixed (int* componentIds = poolT2._mapping)
//        //        fixed (T2* componentSource = poolT2._components)
//        //        {
//        //            --entityId;
//        //            for (int i = 0; i < destination.Length; ++i)
//        //            {
//        //                entityId += 2;
//        //                destination[i].Item2 = *(componentSource + *(componentIds + *entityId));
//        //            }
//        //        }
//        //    }
//        //}
//    }
//}
