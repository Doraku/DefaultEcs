### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity')
## SetAsParentOf(DefaultEcs.Entity) `method`
Makes it so when current [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') is disposed, given [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') will also be disposed.
### Parameters

<a name='DefaultEcs-Entity-SetAsParentOf(DefaultEcs-Entity)-child'></a>
`child`

The [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') which acts as child.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Child and parent [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') come from a different [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').
