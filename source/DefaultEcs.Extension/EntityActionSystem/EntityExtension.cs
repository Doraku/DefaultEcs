using DefaultEcs.System;

namespace DefaultEcs.EntityActionSystem
{
	public static class EntityExtension
	{
		public static ISystem<T> AsSystem<T>(this EntityQueryBuilder builder, EntityAction<T> action)
			=> new EntityActionSystem<T>(builder.AsSet(), action);

		public static ISystem<T> AsSystem<T, C>(this EntityQueryBuilder builder, EntityAction<T, C> action)
			=> new EntityActionSystem<T, C>(builder.With<C>().AsSet(), action);

		public static ISystem<T> AsSystem<T, C1, C2>(this EntityQueryBuilder builder, EntityAction<T, C1, C2> action)
			=> new EntityActionSystem<T, C1, C2>(builder.With<C1>().With<C2>().AsSet(), action);

		public static ISystem<T> AsSystem<T, C1, C2, C3>(this EntityQueryBuilder builder, EntityAction<T, C1, C2, C3> action)
			=> new EntityActionSystem<T, C1, C2, C3>(builder.With<C1>().With<C2>().With<C3>().AsSet(), action);

		public static ISystem<T> AsSystem<T, C>(this EntityQueryBuilder builder, ComponentAction<T, C> action)
			=> new ComponentActionSystem<T, C>(builder.With<C>().AsSet(), action);

		public static ISystem<T> AsSystem<T, C1, C2>(this EntityQueryBuilder builder, ComponentAction<T, C1, C2> action)
			=> new ComponentActionSystem<T, C1, C2>(builder.With<C1>().With<C2>().AsSet(), action);

		public static ISystem<T> AsSystem<T, C1, C2, C3>(this EntityQueryBuilder builder, ComponentAction<T, C1, C2, C3> action)
			=> new ComponentActionSystem<T, C1, C2, C3>(builder.With<C1>().With<C2>().With<C3>().AsSet(), action);
	}

	public delegate void EntityAction<in T>(T context, Entity entity);
	public delegate void EntityAction<in T, C>(T context, Entity entity, ref C component);
	public delegate void EntityAction<in T, C1, C2>(T context, Entity entity, ref C1 component1, ref C2 component2);
	public delegate void EntityAction<in T, C1, C2, C3>(T context, Entity entity, ref C1 component1, ref C2 component2, ref C3 component3);
	public delegate void ComponentAction<in T, C>(T context, ref C component);
	public delegate void ComponentAction<in T, C1, C2>(T context, ref C1 component1, ref C2 component2);
	public delegate void ComponentAction<in T, C1, C2, C3>(T context, ref C1 component1, ref C2 component2, ref C3 component3);
}
