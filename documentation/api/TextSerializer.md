#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## TextSerializer Class

Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a text readable format.

```csharp
public sealed class TextSerializer :
DefaultEcs.Serialization.ISerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextSerializer

Implements [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

| Constructors | |
| :--- | :--- |
| [TextSerializer()](TextSerializer.TextSerializer().md 'DefaultEcs.Serialization.TextSerializer.TextSerializer()') | Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class. |
| [TextSerializer(TextSerializationContext)](TextSerializer.TextSerializer(TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(DefaultEcs.Serialization.TextSerializationContext)') | Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class. |
| [TextSerializer(Predicate&lt;Type&gt;)](TextSerializer.TextSerializer(Predicate_Type_).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate<System.Type>)') | Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class. |
| [TextSerializer(Predicate&lt;Type&gt;, TextSerializationContext)](TextSerializer.TextSerializer(Predicate_Type_,TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate<System.Type>, DefaultEcs.Serialization.TextSerializationContext)') | Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class. |

| Methods | |
| :--- | :--- |
| [Deserialize(Stream)](TextSerializer.Deserialize(Stream).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream)') | Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Deserialize(Stream, World)](TextSerializer.Deserialize(Stream,World).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream, DefaultEcs.World)') | Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World'). |
| [Read&lt;T&gt;(Stream)](TextSerializer.Read_T_(Stream).md 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream)') | Read an object of type [T](TextSerializer.Read_T_(Stream).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream).T') from the given stream. |
| [Read&lt;T&gt;(Stream, TextSerializationContext)](TextSerializer.Read_T_(Stream,TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext)') | Read an object of type [T](TextSerializer.Read_T_(Stream,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T') from the given stream. |
| [Serialize(Stream, World)](TextSerializer.Serialize(Stream,World).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World)') | Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Serialize(Stream, IEnumerable&lt;Entity&gt;)](TextSerializer.Serialize(Stream,IEnumerable_Entity_).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable<DefaultEcs.Entity>)') | Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'). |
| [Write&lt;T&gt;(Stream, T)](TextSerializer.Write_T_(Stream,T).md 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T)') | Writes an object of type [T](TextSerializer.Write_T_(Stream,T).md#DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T).T 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T).T') on the given stream. |
| [Write&lt;T&gt;(Stream, T, TextSerializationContext)](TextSerializer.Write_T_(Stream,T,TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext)') | Writes an object of type [T](TextSerializer.Write_T_(Stream,T,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext).T') on the given stream. |
