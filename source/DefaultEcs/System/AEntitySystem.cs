using System;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace DefaultEcs.System
{
    /// <summary>
    /// Represents the base attribute to declare how to build the inner <see cref="EntitySet"/> of <see cref="AEntitySystem{T}"/> when giving a <see cref="World"/> instance.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ComponentAttribute : Attribute
    {
        /// <summary>
        /// The type of the component.
        /// </summary>
        public readonly Type ComponentType;
        /// <summary>
        /// Whether the component type should be included or excluded.
        /// </summary>
        public readonly bool Include;

        /// <summary>
        /// Initialize a new instance of the <see cref="ComponentAttribute"/> type.
        /// </summary>
        /// <param name="componentType">The type of the component.</param>
        /// <param name="include">Whether the component type should be included or excluded.</param>
        public ComponentAttribute(Type componentType, bool include)
        {
            ComponentType = componentType ?? throw new ArgumentNullException(nameof(componentType));
            Include = include;
        }
    }

    /// <summary>
    /// Represents a component type to include when building the inner <see cref="EntitySet"/> of <see cref="AEntitySystem{T}"/> when giving a <see cref="World"/> instance.
    /// </summary>
    public sealed class WithAttribute : ComponentAttribute
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="WithAttribute"/> type.
        /// </summary>
        /// <param name="componentType">The type of the component to include.</param>
        public WithAttribute(Type componentType)
            : base(componentType, true)
        { }
    }

    /// <summary>
    /// Represents a component type to exclude when building the inner <see cref="EntitySet"/> of <see cref="AEntitySystem{T}"/> when giving a <see cref="World"/> instance.
    /// </summary>
    public sealed class WithoutAttribute : ComponentAttribute
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="WithoutAttribute"/> type.
        /// </summary>
        /// <param name="componentType">The type of the component to exclude.</param>
        public WithoutAttribute(Type componentType)
            : base(componentType, false)
        { }
    }

    /// <summary>
    /// Represents a base class to process updates on a given <see cref="EntitySet"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the object used as state to update the system.</typeparam>
    public abstract class AEntitySystem<T> : ASystem<T>
    {
        #region Fields

        private static readonly ConcurrentDictionary<Type, Func<World, EntitySet>> _getEntitySet = new ConcurrentDictionary<Type, Func<World, EntitySet>>();

        private readonly EntitySet _set;

        #endregion

        #region Initialisation

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/> and <see cref="SystemRunner{T}"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set, SystemRunner<T> runner)
            : base(runner)
        {
            _set = set ?? throw new ArgumentNullException(nameof(set));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="EntitySet"/>.
        /// </summary>
        /// <param name="set">The <see cref="EntitySet"/> on which to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="set"/> is null.</exception>
        protected AEntitySystem(EntitySet set)
            : this(set, null)
        { }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <param name="runner">The <see cref="SystemRunner{T}"/> used to process the update in parallel if not null.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world, SystemRunner<T> runner)
            : base(runner)
        {
            _set = _getEntitySet.GetOrAdd(GetType(), GetEntitySet)(world ?? throw new ArgumentNullException(nameof(world)));
        }

        /// <summary>
        /// Initialise a new instance of the <see cref="AEntitySystem{T}"/> class with the given <see cref="World"/>.
        /// To create the inner <see cref="EntitySet"/>, <see cref="WithAttribute"/> and <see cref="WithoutAttribute"/> attributes will be used.
        /// </summary>
        /// <param name="world">The <see cref="World"/> from which to get the <see cref="Entity"/> instances to process the update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is null.</exception>
        protected AEntitySystem(World world)
            : this(world, null)
        { }

        #endregion

        #region Methods

        private static Func<World, EntitySet> GetEntitySet(Type type)
        {
            TypeInfo entitySetBuilder = typeof(EntitySetBuilder).GetTypeInfo();
            MethodInfo with = entitySetBuilder.GetDeclaredMethod(nameof(EntitySetBuilder.With));
            MethodInfo without = entitySetBuilder.GetDeclaredMethod(nameof(EntitySetBuilder.Without));

            ParameterExpression world = Expression.Parameter(typeof(World));
            Expression expression = Expression.Call(world, typeof(World).GetTypeInfo().GetDeclaredMethod(nameof(World.GetEntities)));

            foreach (ComponentAttribute attribute in type.GetTypeInfo().GetCustomAttributes<ComponentAttribute>(true))
            {
                expression = Expression.Call(expression, (attribute.Include ? with : without).MakeGenericMethod(attribute.ComponentType));
            }

            expression = Expression.Call(expression, entitySetBuilder.GetDeclaredMethod(nameof(EntitySetBuilder.Build)));

            return Expression.Lambda<Func<World, EntitySet>>(expression, world).Compile();
        }

        /// <summary>
        /// Update the given <see cref="Entity"/> instance once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entity">The <see cref="Entity"/> instance to update.</param>
        protected virtual void Update(T state, in Entity entity) { }

        /// <summary>
        /// Update the given <see cref="Entity"/> instances once.
        /// </summary>
        /// <param name="state">The state to use.</param>
        /// <param name="entities">The <see cref="Entity"/> instances to update.</param>
        protected virtual void Update(T state, ReadOnlySpan<Entity> entities)
        {
            for (int i = 0; i < entities.Length; ++i)
            {
                Update(state, entities[i]);
            }
        }

        #endregion

        #region ASystem

        internal sealed override void Update(int index, int maxIndex)
        {
            ReadOnlySpan<Entity> entities = _set.GetEntities();
            int entitiesToUpdate = entities.Length / (maxIndex + 1);

            if (index == maxIndex)
            {
                Update(CurrentState, index == 0 ? entities : entities.Slice(index * entitiesToUpdate));
            }
            else
            {
                Update(CurrentState, entities.Slice(index * entitiesToUpdate, entitiesToUpdate));
            }
        }

        /// <summary>
        /// Disposes of the inner <see cref="EntitySet"/> instance.
        /// </summary>
        public override void Dispose()
        {
            _set.Dispose();
        }

        #endregion
    }
}
