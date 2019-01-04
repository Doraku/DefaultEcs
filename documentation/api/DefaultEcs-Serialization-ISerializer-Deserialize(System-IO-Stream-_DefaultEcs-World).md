#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](./DefaultEcs.md#DefaultEcs-Serialization 'DefaultEcs.Serialization').[ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')
## Deserialize(System.IO.Stream, DefaultEcs.World) `method`
Deserializes [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](./DefaultEcs-World.md 'DefaultEcs.World').
### Parameters

<a name='DefaultEcs-Serialization-ISerializer-Deserialize(System-IO-Stream-_DefaultEcs-World)-stream'></a>
`stream`

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.

<a name='DefaultEcs-Serialization-ISerializer-Deserialize(System-IO-Stream-_DefaultEcs-World)-world'></a>
`world`

The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance on which the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will be created.
### Returns
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances loaded.
