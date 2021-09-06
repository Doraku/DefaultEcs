namespace DefaultEcs.Internal.Message
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
