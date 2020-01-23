#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[ISerializerExtension](./DefaultEcs-Serialization-ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension')
## ISerializerExtension.Serialize(DefaultEcs.Serialization.ISerializer, System.IO.Stream, DefaultEcs.Entity[]) Method
Serializes the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public static void Serialize(this DefaultEcs.Serialization.ISerializer serializer, System.IO.Stream stream, params DefaultEcs.Entity[] entities);
```
#### Parameters
<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer_System-IO-Stream_DefaultEcs-Entity--)-serializer'></a>
`serializer` [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
The [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer') instance to use.  
  
<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer_System-IO-Stream_DefaultEcs-Entity--)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.  
  
<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer_System-IO-Stream_DefaultEcs-Entity--)-entities'></a>
`entities` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to save.  
  
