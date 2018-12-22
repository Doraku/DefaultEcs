#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](./DefaultEcs.md#DefaultEcs-Serialization 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## Serialize(System.IO.Stream, DefaultEcs.World) `method`
Serializes the given [World](./DefaultEcs-World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').
### Parameters

<a name='DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-stream'></a>
`stream`
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-world'></a>
`world`
The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to save.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
[stream](#DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-stream 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World).stream') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
[world](#DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream-_DefaultEcs-World)-world 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World).world') is null.
