namespace DefaultEcs.Internal.Command
{
    internal enum CommandType : byte
    {
        Entity = 0,
        CreateEntity = 1,
        WorldSet = 2,
        WorldRemove = 3,
        Enable = 4,
        Disable = 5,
        EnableT = 6,
        DisableT = 7,
        Set = 8,
        SetSameAs = 9,
        SetSameAsWorld = 10,
        Remove = 11,
        NotifyChanged = 12,
        Clone = 13,
        Dispose = 14
    }
}
