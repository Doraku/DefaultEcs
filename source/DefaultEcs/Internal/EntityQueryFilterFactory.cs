using System;
using System.Collections.Generic;
using System.Linq;

namespace DefaultEcs.Internal
{
    internal static class EntityQueryFilterFactory
    {
        #region Fields

        private static readonly Dictionary<string, Predicate<ComponentEnum>> _filters;

        #endregion

        #region Initialisation

        static EntityQueryFilterFactory()
        {
            _filters = new Dictionary<string, Predicate<ComponentEnum>>();
        }

        #endregion

        #region Methods

        public static Predicate<ComponentEnum> GetFilter(
            ComponentEnum withFilter,
            ComponentEnum withoutFilter,
            List<ComponentEnum> withEitherFilters,
            List<ComponentEnum> withoutEitherFilters)
        {
            withFilter = withFilter.Copy();
            withoutFilter = withoutFilter.Copy();
            withEitherFilters = withEitherFilters?.ToList();
            withoutEitherFilters = withoutEitherFilters?.ToList();

            string key = $"{withFilter} {withoutFilter} {string.Join(" ", withEitherFilters ?? Enumerable.Empty<ComponentEnum>())} {string.Join(" ", withoutEitherFilters ?? Enumerable.Empty<ComponentEnum>())}";
            Predicate<ComponentEnum> filter;

            lock (_filters)
            {
                if (!_filters.TryGetValue(key, out filter))
                {
                    ComponentEnum singleWithEitherFilter = withEitherFilters?.FirstOrDefault() ?? default;
                    ComponentEnum singleWithoutEitherFilter = withoutEitherFilters?.FirstOrDefault() ?? default;

                    filter = (withoutFilter.IsNull, withEitherFilters?.Count, withoutEitherFilters?.Count) switch
                    {
                        (true, null, null) => c => c.Contains(withFilter),
                        (true, 1, null) => c => c.Contains(withFilter) && !c.DoNotContains(singleWithEitherFilter),
                        (true, _, null) => c => c.Contains(withFilter) && withEitherFilters.All(f => !c.DoNotContains(f)),
                        (true, null, 1) => c => c.Contains(withFilter) && !c.Contains(singleWithoutEitherFilter),
                        (true, null, _) => c => c.Contains(withFilter) && withoutEitherFilters.All(f => !c.Contains(f)),
                        (true, 1, 1) => c => c.Contains(withFilter) && !c.DoNotContains(singleWithEitherFilter) && !c.Contains(singleWithoutEitherFilter),
                        (true, 1, _) => c => c.Contains(withFilter) && !c.DoNotContains(singleWithEitherFilter) && withoutEitherFilters.All(f => !c.Contains(f)),
                        (true, _, 1) => c => c.Contains(withFilter) && withEitherFilters.All(f => !c.DoNotContains(f)) && !c.Contains(singleWithoutEitherFilter),
                        (true, _, _) => c => c.Contains(withFilter) && withEitherFilters.All(f => !c.DoNotContains(f)) && withoutEitherFilters.All(f => !c.Contains(f)),
                        (false, null, null) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter),
                        (false, 1, null) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && !c.DoNotContains(singleWithEitherFilter),
                        (false, _, null) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && withEitherFilters.All(f => !c.DoNotContains(f)),
                        (false, null, 1) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && !c.Contains(singleWithoutEitherFilter),
                        (false, null, _) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && withoutEitherFilters.All(f => !c.Contains(f)),
                        (false, 1, 1) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && !c.DoNotContains(singleWithEitherFilter) && !c.Contains(singleWithoutEitherFilter),
                        (false, 1, _) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && !c.DoNotContains(singleWithEitherFilter) && withoutEitherFilters.All(f => !c.Contains(f)),
                        (false, _, 1) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && withEitherFilters.All(f => !c.DoNotContains(f)) && !c.Contains(singleWithoutEitherFilter),
                        (false, _, _) => c => c.Contains(withFilter) && c.DoNotContains(withoutFilter) && withEitherFilters.All(f => !c.DoNotContains(f)) && withoutEitherFilters.All(f => !c.Contains(f)),
                    };

                    _filters.Add(key, filter);
                }
            }

            return filter;
        }

        #endregion
    }
}
