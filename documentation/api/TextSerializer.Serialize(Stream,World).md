#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer.Serialize(Stream, World) Method

Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').

```csharp
public void Serialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream,DefaultEcs.World).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream,DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') instance to save.

Implements [Serialize(Stream, World)](ISerializer.Serialize(Stream,World).md 'DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream, DefaultEcs.World)')

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer.Serialize(Stream,World).md#DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream,DefaultEcs.World).stream 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World).stream') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](TextSerializer.Serialize(Stream,World).md#DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream,DefaultEcs.World).world 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World).world') is null.