namespace DefaultEcs.Technical.Message
{
    public readonly struct WorldDisposedMessage
    {
        public readonly int WorldId;

        public WorldDisposedMessage(int worldId)
        {
            WorldId = worldId;
        }
    }
}
