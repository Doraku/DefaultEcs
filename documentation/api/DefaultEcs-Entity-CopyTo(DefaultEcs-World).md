### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## CopyTo(DefaultEcs.World) `method`
>Creates a copy of current [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with all of its components in the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
### Parameters

<a name='DefaultEcs-Entity-CopyTo(DefaultEcs-World)-world'></a>
`world`
>The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance to which copy current [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') and its components.
### Returns
>The created [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') in the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')
>[DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
