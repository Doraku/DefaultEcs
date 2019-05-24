using DefaultEcs.Technical.Helper;

namespace DefaultEcs.Technical
{
    internal sealed class WorldInfo
    {
        public readonly int MaxEntityCount;

        public EntityInfo[] EntityInfos;

        public WorldInfo(int maxEntityCount)
        {
            MaxEntityCount = maxEntityCount;

            EntityInfos = EmptyArray<EntityInfo>.Value;
        }
    }
}
