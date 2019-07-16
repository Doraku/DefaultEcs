namespace DefaultEcs
{
    /// <summary>
    /// Provides set of static methods to create more easily rules on a <see cref="EntitySetBuilder"/> instance.
    /// </summary>
    public static class EntitySetBuilderExtension
    {
        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of type <typeparamref name="T1"/> or <typeparamref name="T2"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WithEither<T1, T2>(this EntitySetBuilder builder) => builder.WithEither(typeof(T1), typeof(T2));

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> with at least one component of type <typeparamref name="T1"/>, <typeparamref name="T2"/> or <typeparamref name="T3"/>.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <typeparam name="T3">The third type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WithEither<T1, T2, T3>(this EntitySetBuilder builder) => builder.WithEither(typeof(T1), typeof(T2), typeof(T3));

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when at least one component of type <typeparamref name="T1"/> or <typeparamref name="T2"/> is added.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenAddedEither<T1, T2>(this EntitySetBuilder builder) => builder.WhenAddedEither(typeof(T1), typeof(T2));

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when at least one component of type <typeparamref name="T1"/>, <typeparamref name="T2"/> or <typeparamref name="T3"/> is added.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <typeparam name="T3">The third type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenAddedEither<T1, T2, T3>(this EntitySetBuilder builder) => builder.WhenAddedEither(typeof(T1), typeof(T2), typeof(T3));

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when at least one component of type <typeparamref name="T1"/> or <typeparamref name="T2"/> is changed.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenChangedEither<T1, T2>(this EntitySetBuilder builder) => builder.WhenChangedEither(typeof(T1), typeof(T2));

        /// <summary>
        /// Makes a rule to obsverve <see cref="Entity"/> when at least one component of type <typeparamref name="T1"/>, <typeparamref name="T2"/> or <typeparamref name="T3"/> is changed.
        /// </summary>
        /// <typeparam name="T1">The first type of component.</typeparam>
        /// <typeparam name="T2">The second type of component.</typeparam>
        /// <typeparam name="T3">The third type of component.</typeparam>
        /// <param name="builder">The <see cref="EntitySetBuilder"/> on which to create the rule.</param>
        /// <returns>The given <see cref="EntitySetBuilder"/>.</returns>
        public static EntitySetBuilder WhenChangedEither<T1, T2, T3>(this EntitySetBuilder builder) => builder.WhenChangedEither(typeof(T1), typeof(T2), typeof(T3));
    }
}
