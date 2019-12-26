namespace DefaultEcs {
    /// <summary>
    /// That's a factory, that should be used to create <see cref="Entity"/> instances.
    /// It can be accessed from <see cref="World"/>'s GetEntityFactory() method
    /// </summary>
    public class EntityFactory : IEntityFactory {
        private World _world;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFactory"/> class.
        /// </summary>
        /// <param name="world">World, that will be linked to created entity</param>
        public EntityFactory(World world) {
            _world = world;
        }


        /// <summary>
        /// Makes entity instance
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        public Entity MakeEntity(int entityId) {
            return new Entity(_world.WorldId, entityId);
        }
    }
}