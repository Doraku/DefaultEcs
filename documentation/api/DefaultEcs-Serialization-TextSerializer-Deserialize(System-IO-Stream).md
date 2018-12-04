### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization.TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## Deserialize(System.IO.Stream) `method`
Deserializes a [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').
### Parameters

<a name='DefaultEcs-Serialization-TextSerializer-Deserialize(System-IO-Stream)-stream'></a>
`stream`

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.
### Returns
The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance loaded.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')

[stream](#DefaultEcs-Serialization-TextSerializer-Deserialize(System-IO-Stream)-stream 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream).stream') is null.
