#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Deserialize(Stream) Method
Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public DefaultEcs.World Deserialize(System.IO.Stream stream);
```
#### Parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Deserialize(System_IO_Stream)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.
  
#### Returns
[World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance loaded.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer_Deserialize(Stream).md#DefaultEcs_Serialization_BinarySerializer_Deserialize(System_IO_Stream)_stream 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream).stream') is null.
