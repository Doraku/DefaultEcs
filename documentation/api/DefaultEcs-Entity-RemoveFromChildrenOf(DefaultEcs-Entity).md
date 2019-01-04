#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## RemoveFromChildrenOf(DefaultEcs.Entity) `method`
Remove the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') from current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') parents.
### Parameters

<a name='DefaultEcs-Entity-RemoveFromChildrenOf(DefaultEcs-Entity)-parent'></a>
`parent`

The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as parent.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Child and parent [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') come from a different [World](./DefaultEcs-World.md 'DefaultEcs.World').
