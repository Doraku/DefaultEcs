#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Read&lt;T&gt;(Stream) Method
Read an object of type [T](TextSerializer_Read_T_(Stream).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).T') from the given stream.  
```csharp
public static T Read<T>(System.IO.Stream stream);
```
#### Type parameters
<a name='DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_T'></a>
`T`  
The type of the object deserialized.
  
#### Parameters
<a name='DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.
  
#### Returns
[T](TextSerializer_Read_T_(Stream).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).T')  
The object deserialized.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer_Read_T_(Stream).md#DefaultEcs_Serialization_TextSerializer_Read_T_(System_IO_Stream)_stream 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).stream') is null.
