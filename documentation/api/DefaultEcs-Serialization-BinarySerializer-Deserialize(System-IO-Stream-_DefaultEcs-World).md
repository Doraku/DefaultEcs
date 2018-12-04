### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization.BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## Deserialize(System.IO.Stream, DefaultEcs.World) `method`
Deserializes [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
### Parameters

<a name='DefaultEcs-Serialization-BinarySerializer-Deserialize(System-IO-Stream-_DefaultEcs-World)-stream'></a>
`stream`

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.

<a name='DefaultEcs-Serialization-BinarySerializer-Deserialize(System-IO-Stream-_DefaultEcs-World)-world'></a>
`world`

The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance on which the [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will be created.
### Returns
The [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances loaded.
