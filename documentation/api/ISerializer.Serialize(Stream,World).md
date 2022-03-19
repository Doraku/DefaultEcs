#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

## ISerializer.Serialize(Stream, World) Method

Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').

```csharp
void Serialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream,DefaultEcs.World).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream,DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') instance to save.