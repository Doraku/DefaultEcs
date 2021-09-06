namespace DefaultEcs.Internal
{
    internal struct EntityInfo
    {
        #region Fields

        public short Version;
        public ComponentEnum Components;

        public readonly bool IsAlive(short version) => Version == version && Components[World.IsAliveFlag];

        #endregion
    }
}
