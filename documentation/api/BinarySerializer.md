#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## BinarySerializer Class
Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a binary format.  
```csharp
public sealed class BinarySerializer :
DefaultEcs.Serialization.ISerializer
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializer  

Implements [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
### Constructors

***
[BinarySerializer()](BinarySerializer_BinarySerializer().md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer()')

Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  

***
[BinarySerializer(BinarySerializationContext)](BinarySerializer_BinarySerializer(BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(DefaultEcs.Serialization.BinarySerializationContext)')

Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  

***
[BinarySerializer(Predicate&lt;Type&gt;)](BinarySerializer_BinarySerializer(Predicate_Type_).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate&lt;System.Type&gt;)')

Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  

***
[BinarySerializer(Predicate&lt;Type&gt;, BinarySerializationContext)](BinarySerializer_BinarySerializer(Predicate_Type__BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.BinarySerializationContext)')

Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  
### Methods

***
[Deserialize(Stream)](BinarySerializer_Deserialize(Stream).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream)')

Deserializes a [World](World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Deserialize(Stream, World)](BinarySerializer_Deserialize(Stream_World).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')

Deserializes [Entity](Entity.md 'DefaultEcs.Entity') instances with their components from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') into the given [World](World.md 'DefaultEcs.World').  

***
[Read&lt;T&gt;(Stream)](BinarySerializer_Read_T_(Stream).md 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream)')

Read an object of type [T](BinarySerializer_Read_T_(Stream).md#DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream)_T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream).T') from the given stream.  

***
[Read&lt;T&gt;(Stream, BinarySerializationContext)](BinarySerializer_Read_T_(Stream_BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext)')

Read an object of type [T](BinarySerializer_Read_T_(Stream_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T') from the given stream.  

***
[Serialize(Stream, World)](BinarySerializer_Serialize(Stream_World).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World)')

Serializes the given [World](World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Serialize(Stream, IEnumerable&lt;Entity&gt;)](BinarySerializer_Serialize(Stream_IEnumerable_Entity_).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')

Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  

***
[Write&lt;T&gt;(Stream, T)](BinarySerializer_Write_T_(Stream_T).md 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T)')

Writes an object of type [T](BinarySerializer_Write_T_(Stream_T).md#DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T)_T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.  

***
[Write&lt;T&gt;(Stream, T, BinarySerializationContext)](BinarySerializer_Write_T_(Stream_T_BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext)')

Writes an object of type [T](BinarySerializer_Write_T_(Stream_T_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T') on the given stream.  
