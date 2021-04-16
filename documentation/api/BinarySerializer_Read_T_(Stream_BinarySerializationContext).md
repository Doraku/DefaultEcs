#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Read&lt;T&gt;(Stream, BinarySerializationContext) Method
Read an object of type [T](BinarySerializer_Read_T_(Stream_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T') from the given stream.  
```csharp
public static T Read<T>(System.IO.Stream stream, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Type parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_T'></a>
`T`  
The type of the object deserialized.
  
#### Parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.
  
<a name='DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_context'></a>
`context` [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')  
The [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during deserialization.
  
#### Returns
[T](BinarySerializer_Read_T_(Stream_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T')  
The object deserialized.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer_Read_T_(Stream_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_BinarySerializationContext)_stream 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).stream') is null.
