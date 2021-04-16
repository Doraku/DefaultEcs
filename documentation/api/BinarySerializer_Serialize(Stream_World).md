#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Serialize(Stream, World) Method
Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public void Serialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Serialize(System_IO_Stream_DefaultEcs_World)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.
  
<a name='DefaultEcs_Serialization_BinarySerializer_Serialize(System_IO_Stream_DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance to save.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer_Serialize(Stream_World).md#DefaultEcs_Serialization_BinarySerializer_Serialize(System_IO_Stream_DefaultEcs_World)_stream 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).stream') is null.
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](BinarySerializer_Serialize(Stream_World).md#DefaultEcs_Serialization_BinarySerializer_Serialize(System_IO_Stream_DefaultEcs_World)_world 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).world') is null.
