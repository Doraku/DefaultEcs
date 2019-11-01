#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Read&lt;T&gt;(System.IO.Stream) Method
Read an object of type [T](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).T') from the given stream.  
```C#
public static T Read<T>(System.IO.Stream stream);
```
#### Type parameters
<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-T'></a>
`T`  
The type of the object deserialized.  
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-stream'></a>
stream [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.  
#### Returns
[T](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).T')  
The object deserialized.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-stream 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).stream') is null.  
