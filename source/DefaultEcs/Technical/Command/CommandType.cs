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
        Remove = 8,
        NotifyChanged = 9,
        SetAsChildOf = 10,
        RemoveFromChildrenOf = 11,
        Dispose = 12
    }
}
