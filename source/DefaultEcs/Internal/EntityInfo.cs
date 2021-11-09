using DefaultEcs.Internal.Component;

namespace DefaultEcs.Internal
{
    internal struct EntityInfo
    {
        #region Fields

        public short Version;
        public ComponentEnum Components;
        public Archetype Archetype;

        public readonly bool IsAlive(short version) => Version == version && Components[ComponentFlag.IsAlive];

        #endregion
    }
}
