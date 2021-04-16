#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## ISerializer Interface
Provides a set of methods to save and load DefaultEcs objects.  
```csharp
public interface ISerializer
```

Derived  
&#8627; [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
&#8627; [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')  
### Methods

***
[Deserialize(Stream)](ISerializer_Deserialize(Stream).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream)')

Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Deserialize(Stream, World)](ISerializer_Deserialize(Stream_World).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')

Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World').  

***
[Serialize(Stream, World)](ISerializer_Serialize(Stream_World).md 'DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream, DefaultEcs.World)')

Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Serialize(Stream, IEnumerable&lt;Entity&gt;)](ISerializer_Serialize(Stream_IEnumerable_Entity_).md 'DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')

Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
