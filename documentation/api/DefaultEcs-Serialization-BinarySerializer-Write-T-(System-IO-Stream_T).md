#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T) Method
Writes an object of type [T](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.  
```C#
public static void Write<T>(System.IO.Stream stream, in T obj);
```
#### Type parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-T'></a>
`T`  
The type of the object serialized.  
  
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.  
  
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-obj'></a>
`obj` [T](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T).T')  
The object to serialize.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T)-stream 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T).stream') is null.  
