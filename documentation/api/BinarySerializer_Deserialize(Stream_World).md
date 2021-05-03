#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Deserialize(Stream, World) Method
Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World').  
```csharp
public System.Collections.Generic.ICollection<DefaultEcs.Entity> Deserialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Deserialize(System_IO_Stream_DefaultEcs_World)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.
  
<a name='DefaultEcs_Serialization_BinarySerializer_Deserialize(System_IO_Stream_DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance on which the [Entity](Entity.md 'DefaultEcs.Entity') will be created.
  
#### Returns
[System.Collections.Generic.ICollection&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.ICollection-1 'System.Collections.Generic.ICollection`1')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances loaded.

Implements [Deserialize(Stream, World)](ISerializer_Deserialize(Stream_World).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')  
