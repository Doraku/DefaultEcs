#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Write&lt;T&gt;(Stream, T) Method
Writes an object of type [T](TextSerializer_Write_T_(Stream_T).md#DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.  
```csharp
public static void Write<T>(System.IO.Stream stream, in T value);
```
#### Type parameters
<a name='DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_T'></a>
`T`  
The type of the object serialized.
  
#### Parameters
<a name='DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.
  
<a name='DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_value'></a>
`value` [T](TextSerializer_Write_T_(Stream_T).md#DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T')  
The object to serialize.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer_Write_T_(Stream_T).md#DefaultEcs_Serialization_TextSerializer_Write_T_(System_IO_Stream_T)_stream 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).stream') is null.
