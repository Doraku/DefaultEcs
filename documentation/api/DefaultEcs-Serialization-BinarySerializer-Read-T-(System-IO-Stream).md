#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Read&lt;T&gt;(System.IO.Stream) Method
Read an object of type [T](#DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream)-T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream).T') from the given stream.  
```C#
public static T Read<T>(System.IO.Stream stream);
```
#### Type parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream)-T'></a>
`T`  
The type of the object deserialized.  
  
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.  
  
#### Returns
[T](#DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream)-T 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream).T')  
The object deserialized.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream)-stream 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream).stream') is null.  
