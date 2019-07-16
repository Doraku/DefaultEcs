using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace DefaultEcs.Technical
{
    internal static class EntitySetFilterFactory
    {
        #region Fields

        private static readonly MethodInfo _componentsContains;
        private static readonly MethodInfo _componentsDoNotContains;
        private static readonly Dictionary<string, Predicate<ComponentEnum>> _filters;

        #endregion

        #region Initialisation

        static EntitySetFilterFactory()
        {
            _componentsContains = typeof(ComponentEnum).GetTypeInfo().GetDeclaredMethod(nameof(ComponentEnum.Contains));
            _componentsDoNotContains = typeof(ComponentEnum).GetTypeInfo().GetDeclaredMethod(nameof(ComponentEnum.DoNotContains));
            _filters = new Dictionary<string, Predicate<ComponentEnum>>();
        }

        #endregion

        #region Methods

        public static Predicate<ComponentEnum> GetFilter(ComponentEnum withFilter, ComponentEnum withoutFilter, List<ComponentEnum> withEitherFilters)
        {
            string key = $"{withFilter} {withoutFilter} {string.Join(" ", withEitherFilters ?? Enumerable.Empty<ComponentEnum>())}";
            Predicate<ComponentEnum> filter;

            lock (_filters)
            {
                if (!_filters.TryGetValue(key, out filter))
                {
                    ParameterExpression components = Expression.Parameter(typeof(ComponentEnum));
                    Expression filterEx = Expression.Call(components, _componentsContains, Expression.Constant(withFilter));
                    if (!withoutFilter.IsNull)
                    {
                        filterEx = Expression.And(filterEx, Expression.Call(components, _componentsDoNotContains, Expression.Constant(withoutFilter.Copy())));
                    }
                    foreach (ComponentEnum f in withEitherFilters ?? Enumerable.Empty<ComponentEnum>())
                    {
                        filterEx = Expression.And(filterEx, Expression.Not(Expression.Call(components, _componentsDoNotContains, Expression.Constant(f.Copy()))));
                    }
                    filter = Expression.Lambda<Predicate<ComponentEnum>>(filterEx, components).Compile();

                    _filters.Add(key, filter);
                }
            }

            return filter;
        }

        #endregion
    }
}
