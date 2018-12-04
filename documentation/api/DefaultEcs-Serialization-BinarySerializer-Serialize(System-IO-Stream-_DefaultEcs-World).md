### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization.BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## Serialize(System.IO.Stream, DefaultEcs.World) `method`
Serializes the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').
### Parameters

<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-stream'></a>
`stream`
>The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-world'></a>
`world`
>The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance to save.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[stream](#DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-stream 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).stream') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[world](#DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-world 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).world') is null.
