using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultEcs.Technical
{
    internal static class EntitySetFilterFactory
    {
        #region Fields

        private static readonly Dictionary<string, Predicate<ComponentEnum>> _filters;

        #endregion

        #region Initialisation

        static EntitySetFilterFactory()
        {
            _filters = new Dictionary<string, Predicate<ComponentEnum>>();
        }

        #endregion

        #region Methods

        private static Predicate<ComponentEnum> GetLambdaFilter(
            ComponentEnum withFilter,
            ComponentEnum withoutFilter,
            List<ComponentEnum> withEitherFilters,
            List<ComponentEnum> withoutEitherFilters)
        {
            if (withoutFilter.IsNull)
            {
                if (withEitherFilters is null)
                {
                    if (withoutEitherFilters is null)
                    {
                        return c => c.Contains(withFilter);
                    }

                    if (withoutEitherFilters.Count == 1)
                    {
                        ComponentEnum withoutEitherFilter = withoutEitherFilters[0];
                        return c => c.Contains(withFilter)
                            && !c.Contains(withoutEitherFilter);
                    }

                    return c => c.Contains(withFilter)
                        && withoutEitherFilters.All(f => !c.Contains(f));
                }
                else if (withoutEitherFilters is null)
                {
                    if (withEitherFilters.Count == 1)
                    {
                        ComponentEnum withEitherFilter = withEitherFilters[0];
                        return c => c.Contains(withFilter)
                            && !c.DoNotContains(withEitherFilter);
                    }

                    return c => c.Contains(withFilter)
                        && withEitherFilters.All(f => !c.DoNotContains(f));
                }

                return c => c.Contains(withFilter)
                    && withEitherFilters.All(f => !c.DoNotContains(f))
                    && withoutEitherFilters.All(f => !c.Contains(f));
            }
            else if (withEitherFilters is null)
            {
                if (withoutEitherFilters is null)
                {
                    return c => c.Contains(withFilter)
                        && c.DoNotContains(withoutFilter);
                }

                if (withoutEitherFilters.Count == 1)
                {
                    ComponentEnum withoutEitherFilter = withoutEitherFilters[0];
                    return c => c.Contains(withFilter)
                        && c.DoNotContains(withoutFilter)
                        && !c.Contains(withoutEitherFilter);
                }

                return c => c.Contains(withFilter)
                    && c.DoNotContains(withoutFilter)
                    && withoutEitherFilters.All(f => !c.Contains(f));
            }
            else if (withoutEitherFilters is null)
            {
                if (withEitherFilters.Count == 1)
                {
                    ComponentEnum withEitherFilter = withEitherFilters[0];
                    return c => c.Contains(withFilter)
                        && c.DoNotContains(withoutFilter)
                        && !c.DoNotContains(withEitherFilter);
                }

                return c => c.Contains(withFilter)
                    && c.DoNotContains(withoutFilter)
                    && withEitherFilters.All(f => !c.DoNotContains(f));
            }

            return c => c.Contains(withFilter)
                && c.DoNotContains(withoutFilter)
                && withEitherFilters.All(f => !c.DoNotContains(f))
                && withoutEitherFilters.All(f => !c.Contains(f));
        }

        public static Predicate<ComponentEnum> GetFilter(ComponentEnum withFilter, ComponentEnum withoutFilter, List<ComponentEnum> withEitherFilters, List<ComponentEnum> withoutEitherFilters)
        {
            string key = $"{withFilter} {withoutFilter} {string.Join(" ", withEitherFilters ?? Enumerable.Empty<ComponentEnum>())} {string.Join(" ", withoutEitherFilters ?? Enumerable.Empty<ComponentEnum>())}";
            Predicate<ComponentEnum> filter;

            lock (_filters)
            {
                if (!_filters.TryGetValue(key, out filter))
                {
                    filter = GetLambdaFilter(withFilter, withoutFilter, withEitherFilters, withoutEitherFilters);

                    _filters.Add(key, filter);
                }
            }

            return filter;
        }

        #endregion
    }
}
