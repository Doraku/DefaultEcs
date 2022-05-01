using DefaultEcs.System;

namespace DefaultEcs.EntityActionSystem
{
	internal sealed partial class EntityActionSystem<T> : AEntitySetSystem<T>
	{
		private readonly EntityAction<T> _action;

		public EntityActionSystem(EntitySet set, EntityAction<T> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, Entity entity)
		{
			_action(state, entity);
		}
	}

	internal sealed partial class EntityActionSystem<T, C> : AEntitySetSystem<T>
	{
		private readonly EntityAction<T, C> _action;

		public EntityActionSystem(EntitySet set, EntityAction<T, C> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, Entity entity, ref C component)
		{
			_action(state, entity, ref component);
		}
	}

	internal sealed partial class EntityActionSystem<T, C1, C2> : AEntitySetSystem<T>
	{
		private readonly EntityAction<T, C1, C2> _action;

		public EntityActionSystem(EntitySet set, EntityAction<T, C1, C2> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, Entity entity, ref C1 component1, ref C2 component2)
		{
			_action(state, entity, ref component1, ref component2);
		}
	}

	internal sealed partial class EntityActionSystem<T, C1, C2, C3> : AEntitySetSystem<T>
	{
		private readonly EntityAction<T, C1, C2, C3> _action;

		public EntityActionSystem(EntitySet set, EntityAction<T, C1, C2, C3> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, Entity entity, ref C1 component1, ref C2 component2, ref C3 component3)
		{
			_action(state, entity, ref component1, ref component2, ref component3);
		}
	}

	internal sealed partial class ComponentActionSystem<T, C> : AEntitySetSystem<T>
	{
		private readonly ComponentAction<T, C> _action;

		public ComponentActionSystem(EntitySet set, ComponentAction<T, C> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, ref C component)
		{
			_action(state, ref component);
		}
	}

	internal sealed partial class ComponentActionSystem<T, C1, C2> : AEntitySetSystem<T>
	{
		private readonly ComponentAction<T, C1, C2> _action;

		public ComponentActionSystem(EntitySet set, ComponentAction<T, C1, C2> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, ref C1 component1, ref C2 component2)
		{
			_action(state, ref component1, ref component2);
		}
	}

	internal sealed partial class ComponentActionSystem<T, C1, C2, C3> : AEntitySetSystem<T>
	{
		private readonly ComponentAction<T, C1, C2, C3> _action;

		public ComponentActionSystem(EntitySet set, ComponentAction<T, C1, C2, C3> action) : base(set, true)
		{
			_action = action;
		}

		[Update]
		private void Update(T state, ref C1 component1, ref C2 component2, ref C3 component3)
		{
			_action(state, ref component1, ref component2, ref component3);
		}
	}
}
