namespace DefaultEcs.Technical.Command
{
    internal enum CommandType : byte
    {
        Entity = 0,
        CreateEntity = 1,
        Enable = 2,
        Disable = 3,
        EnableT = 4,
        DisableT = 5,
        Set = 6,
        SetSameAs = 7,
        SetSameAsWorld = 8,
        Remove = 9,
        NotifyChanged = 10,
        Clone = 11,
        Dispose = 12
    }
}
