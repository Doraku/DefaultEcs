#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Write&lt;T&gt;(System.IO.Stream, T) Method
Writes an object of type [T](#DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.  
```csharp
public static void Write<T>(System.IO.Stream stream, in T obj);
```
#### Type parameters
<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-T'></a>
`T`  
The type of the object serialized.  
  
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.  
  
<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-obj'></a>
`obj` [T](#DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T')  
The object to serialize.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T)-stream 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).stream') is null.  
