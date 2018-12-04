### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## SetAsChildOf(DefaultEcs.Entity) `method`
Makes it so when given [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, current [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.
### Parameters

<a name='DefaultEcs-Entity-SetAsChildOf(DefaultEcs-Entity)-parent'></a>
`parent`
>The [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as parent.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')
>[DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')
>Child and parent [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') come from a different [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
