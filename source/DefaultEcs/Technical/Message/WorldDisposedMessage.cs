namespace DefaultEcs.Technical.Message
{
    internal readonly struct WorldDisposedMessage
    {
        public readonly int WorldId;

        public WorldDisposedMessage(int worldId)
        {
            WorldId = worldId;
        }
    }
}
