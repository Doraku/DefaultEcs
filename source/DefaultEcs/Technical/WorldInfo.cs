namespace DefaultEcs.Technical
{
    internal class WorldInfo
    {
        public readonly int MaxEntityCount;

        public EntityInfo[] EntityInfos;

        public WorldInfo(int maxEntityCount)
        {
            MaxEntityCount = maxEntityCount;

            EntityInfos = new EntityInfo[0];
        }
    }
}
