namespace DefaultEcs
{
    public static class EntitySetBuilderExtension
    {
        public static EntitySetBuilder WithAnyOf<T1, T2>(this EntitySetBuilder builder) => builder.WithAnyOf(typeof(T1), typeof(T2));

        public static EntitySetBuilder WithAnyOf<T1, T2, T3>(this EntitySetBuilder builder) => builder.WithAnyOf(typeof(T1), typeof(T2), typeof(T3));

        public static EntitySetBuilder WithAnyOf<T1, T2, T3, T4>(this EntitySetBuilder builder) => builder.WithAnyOf(typeof(T1), typeof(T2), typeof(T3), typeof(T4));

        public static EntitySetBuilder WithAnyOf<T1, T2, T3, T4, T5>(this EntitySetBuilder builder) => builder.WithAnyOf(typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5));
    }
}
