#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Read&lt;T&gt;(Stream, TextSerializationContext) Method
Read an object of type [T](TextSerializer_Read_T_(Stream_TextSerializationContext).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T') from the given stream.  
```csharp
public static T Read<T>(System.IO.Stream stream, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Type parameters
<a name='DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_T'></a>
`T`  
The type of the object deserialized.
  
#### Parameters
<a name='DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.
  
<a name='DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_context'></a>
`context` [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
The [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during deserialization.
  
#### Returns
[T](TextSerializer_Read_T_(Stream_TextSerializationContext).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T')  
The object deserialized.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer_Read_T_(Stream_TextSerializationContext).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream_DefaultEcs_Serialization_TextSerializationContext)_stream 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).stream') is null.
