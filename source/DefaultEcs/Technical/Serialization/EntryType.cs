namespace DefaultEcs.Technical.Serialization
{
    internal enum EntryType : byte
    {
        MaxEntityCount = 0,
        ComponentType = 1,
        MaxComponentCount = 2,
        Entity = 3,
        Component = 4,
        ComponentSameAs = 5,
        ParentChild = 6
    }
}
