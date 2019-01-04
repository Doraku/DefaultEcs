#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## CopyTo(DefaultEcs.World) `method`
Creates a copy of current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](./DefaultEcs-World.md 'DefaultEcs.World').
### Parameters

<a name='DefaultEcs-Entity-CopyTo(DefaultEcs-World)-world'></a>
`world`

The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to which copy current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') and its components.
### Returns
The created [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') in the given [World](./DefaultEcs-World.md 'DefaultEcs.World').
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').
