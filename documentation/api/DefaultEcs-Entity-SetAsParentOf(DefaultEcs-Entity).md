#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## SetAsParentOf(DefaultEcs.Entity) `method`
Makes it so when current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.
### Parameters

<a name='DefaultEcs-Entity-SetAsParentOf(DefaultEcs-Entity)-child'></a>
`child`
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as child.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')
Child and parent [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') come from a different [World](./DefaultEcs-World.md 'DefaultEcs.World').
