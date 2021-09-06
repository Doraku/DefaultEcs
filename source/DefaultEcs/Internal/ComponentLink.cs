namespace DefaultEcs.Internal
{
    internal struct ComponentLink
    {
        #region Fields

        public int EntityId;
        public int ReferenceCount;

        #endregion

        #region Initialisation

        public ComponentLink(int entityId)
        {
            EntityId = entityId;
            ReferenceCount = 1;
        }

        #endregion
    }
}
