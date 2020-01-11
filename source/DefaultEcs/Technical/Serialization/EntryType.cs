namespace DefaultEcs.Technical.Serialization
{
    internal enum EntryType : byte
    {
        WorldMaxCapacity = 0,
        ComponentType = 1,
        ComponentMaxCapacity = 2,
        Entity = 3,
        Component = 4,
        ComponentSameAs = 5,
        ParentChild = 6,
        DisabledEntity = 7,
        DisabledComponent = 8,
        DisabledComponentSameAs = 9
    }
}
