### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity')
## RemoveFromParentsOf(DefaultEcs.Entity) `method`
Remove the given [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') from current [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') children.
### Parameters

<a name='DefaultEcs-Entity-RemoveFromParentsOf(DefaultEcs-Entity)-child'></a>
`child`

The [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') which acts as child.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Child and parent [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') come from a different [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').
