#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[ISerializerExtension](ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension')
## ISerializerExtension.Serialize(ISerializer, Stream, Entity[]) Method
Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public static void Serialize(this DefaultEcs.Serialization.ISerializer serializer, System.IO.Stream stream, params DefaultEcs.Entity[] entities);
```
#### Parameters
<a name='DefaultEcs_Serialization_ISerializerExtension_Serialize(DefaultEcs_Serialization_ISerializer_System_IO_Stream_DefaultEcs_Entity__)_serializer'></a>
`serializer` [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
The [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') instance to use.
  
<a name='DefaultEcs_Serialization_ISerializerExtension_Serialize(DefaultEcs_Serialization_ISerializer_System_IO_Stream_DefaultEcs_Entity__)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.
  
<a name='DefaultEcs_Serialization_ISerializerExtension_Serialize(DefaultEcs_Serialization_ISerializer_System_IO_Stream_DefaultEcs_Entity__)_entities'></a>
`entities` [Entity](Entity.md 'DefaultEcs.Entity')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances to save.
  
