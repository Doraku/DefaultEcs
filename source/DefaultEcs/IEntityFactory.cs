namespace DefaultEcs {
    /// <summary>
    /// Represents a interface used to create <see cref="Entity"/> objects.
    /// </summary>
    public interface IEntityFactory {
        /// <summary>
        /// Makes <see cref="Entity"/> Instance
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns><see cref="Entity"/></returns>
        Entity MakeEntity(int entityId);
    }
}