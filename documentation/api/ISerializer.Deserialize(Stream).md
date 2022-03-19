#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

## ISerializer.Deserialize(Stream) Method

Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').

```csharp
DefaultEcs.World Deserialize(System.IO.Stream stream);
```
#### Parameters

<a name='DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.

#### Returns
[World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance loaded.