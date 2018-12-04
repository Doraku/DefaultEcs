### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity')
## RemoveFromChildrenOf(DefaultEcs.Entity) `method`
Remove the given [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') from current [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') parents.
### Parameters

<a name='DefaultEcs-Entity-RemoveFromChildrenOf(DefaultEcs-Entity)-parent'></a>
`parent`

The [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') which acts as parent.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Child and parent [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') come from a different [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').
