#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## TextSerializer Class
Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a text readable format.  
```csharp
public sealed class TextSerializer :
DefaultEcs.Serialization.ISerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextSerializer  

Implements [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
### Constructors

***
[TextSerializer()](TextSerializer_TextSerializer().md 'DefaultEcs.Serialization.TextSerializer.TextSerializer()')

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.  

***
[TextSerializer(TextSerializationContext)](TextSerializer_TextSerializer(TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(DefaultEcs.Serialization.TextSerializationContext)')

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.  

***
[TextSerializer(Predicate&lt;Type&gt;)](TextSerializer_TextSerializer(Predicate_Type_).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate&lt;System.Type&gt;)')

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.  

***
[TextSerializer(Predicate&lt;Type&gt;, TextSerializationContext)](TextSerializer_TextSerializer(Predicate_Type__TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.TextSerializationContext)')

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.  
### Methods

***
[Deserialize(Stream)](TextSerializer_Deserialize(Stream).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream)')

Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Deserialize(Stream, World)](TextSerializer_Deserialize(Stream_World).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')

Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World').  

***
[Read&lt;T&gt;(Stream)](TextSerializer_Read_T_(Stream).md 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream)')

Read an object of type [T](TextSerializer_Read_T_(Stream).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).T') from the given stream.  

***
[Read&lt;T&gt;(Stream, TextSerializationContext)](TextSerializer_Read_T_(Stream_TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext)')

Read an object of type [T](TextSerializer_Read_T_(Stream_TextSerializationContext).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T') from the given stream.  

***
[Serialize(Stream, World)](TextSerializer_Serialize(Stream_World).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World)')

Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Serialize(Stream, IEnumerable&lt;Entity&gt;)](TextSerializer_Serialize(Stream_IEnumerable_Entity_).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')

Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Write&lt;T&gt;(Stream, T)](TextSerializer_Write_T_(Stream_T).md 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T)')

Writes an object of type [T](TextSerializer_Write_T_(Stream_T).md#DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.  

***
[Write&lt;T&gt;(Stream, T, TextSerializationContext)](TextSerializer_Write_T_(Stream_T_TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext)')

Writes an object of type [T](TextSerializer_Write_T_(Stream_T_TextSerializationContext).md#DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_TextSerializationContext)_T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext).T') on the given stream.  
