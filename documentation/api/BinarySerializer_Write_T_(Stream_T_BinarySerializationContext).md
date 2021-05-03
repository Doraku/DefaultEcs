#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Write&lt;T&gt;(Stream, T, BinarySerializationContext) Method
Writes an object of type [T](BinarySerializer_Write_T_(Stream_T_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T') on the given stream.  
```csharp
public static void Write<T>(System.IO.Stream stream, in T value, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Type parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_T'></a>
`T`  
The type of the object serialized.
  
#### Parameters
<a name='DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.
  
<a name='DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_value'></a>
`value` [T](BinarySerializer_Write_T_(Stream_T_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T')  
The object to serialize.
  
<a name='DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_context'></a>
`context` [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')  
The [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during serialization.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer_Write_T_(Stream_T_BinarySerializationContext).md#DefaultEcs_Serialization_BinarySerializer_Write_T_(System_IO_Stream_T_DefaultEcs_Serialization_BinarySerializationContext)_stream 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).stream') is null.
