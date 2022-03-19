#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[ISerializerExtension](ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension')

## ISerializerExtension.Serialize(this ISerializer, Stream, Entity[]) Method

Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').

```csharp
public static void Serialize(this DefaultEcs.Serialization.ISerializer serializer, System.IO.Stream stream, params DefaultEcs.Entity[] entities);
```
#### Parameters

<a name='DefaultEcs.Serialization.ISerializerExtension.Serialize(thisDefaultEcs.Serialization.ISerializer,System.IO.Stream,DefaultEcs.Entity[]).serializer'></a>

`serializer` [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

The [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') instance to use.

<a name='DefaultEcs.Serialization.ISerializerExtension.Serialize(thisDefaultEcs.Serialization.ISerializer,System.IO.Stream,DefaultEcs.Entity[]).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs.Serialization.ISerializerExtension.Serialize(thisDefaultEcs.Serialization.ISerializer,System.IO.Stream,DefaultEcs.Entity[]).entities'></a>

`entities` [Entity](Entity.md 'DefaultEcs.Entity')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The [Entity](Entity.md 'DefaultEcs.Entity') instances to save.