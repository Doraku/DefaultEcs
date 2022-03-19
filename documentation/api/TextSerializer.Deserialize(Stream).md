#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer.Deserialize(Stream) Method

Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').

```csharp
public DefaultEcs.World Deserialize(System.IO.Stream stream);
```
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.

Implements [Deserialize(Stream)](ISerializer.Deserialize(Stream).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream)')

#### Returns
[World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance loaded.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer.Deserialize(Stream).md#DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream).stream 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream).stream') is null.