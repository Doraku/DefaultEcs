#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## BinarySerializer Class

Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a binary format.

```csharp
public sealed class BinarySerializer :
DefaultEcs.Serialization.ISerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializer

Implements [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

| Constructors | |
| :--- | :--- |
| [BinarySerializer()](BinarySerializer.BinarySerializer().md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer()') | Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class. |
| [BinarySerializer(BinarySerializationContext)](BinarySerializer.BinarySerializer(BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(DefaultEcs.Serialization.BinarySerializationContext)') | Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class. |
| [BinarySerializer(Predicate&lt;Type&gt;)](BinarySerializer.BinarySerializer(Predicate_Type_).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate<System.Type>)') | Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class. |
| [BinarySerializer(Predicate&lt;Type&gt;, BinarySerializationContext)](BinarySerializer.BinarySerializer(Predicate_Type_,BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate<System.Type>, DefaultEcs.Serialization.BinarySerializationContext)') | Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class. |

| Methods | |
| :--- | :--- |
| [Deserialize(Stream)](BinarySerializer.Deserialize(Stream).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream)') | Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Deserialize(Stream, World)](BinarySerializer.Deserialize(Stream,World).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream, DefaultEcs.World)') | Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World'). |
| [Read&lt;T&gt;(Stream)](BinarySerializer.Read_T_(Stream).md 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream)') | Read an object of type [T](BinarySerializer.Read_T_(Stream).md#DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream).T 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream).T') from the given stream. |
| [Read&lt;T&gt;(Stream, BinarySerializationContext)](BinarySerializer.Read_T_(Stream,BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext)') | Read an object of type [T](BinarySerializer.Read_T_(Stream,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T') from the given stream. |
| [Serialize(Stream, World)](BinarySerializer.Serialize(Stream,World).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World)') | Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Serialize(Stream, IEnumerable&lt;Entity&gt;)](BinarySerializer.Serialize(Stream,IEnumerable_Entity_).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable<DefaultEcs.Entity>)') | Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Write&lt;T&gt;(Stream, T)](BinarySerializer.Write_T_(Stream,T).md 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T)') | Writes an object of type [T](BinarySerializer.Write_T_(Stream,T).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T).T') on the given stream. |
| [Write&lt;T&gt;(Stream, T, BinarySerializationContext)](BinarySerializer.Write_T_(Stream,T,BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext)') | Writes an object of type [T](BinarySerializer.Write_T_(Stream,T,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T') on the given stream. |
