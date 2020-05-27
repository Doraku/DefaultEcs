#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext) Method
Read an object of type [T](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T') from the given stream.  
```csharp
public static T Read<T>(System.IO.Stream stream, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Type parameters
<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-T'></a>
`T`  
The type of the object deserialized.  
  
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.  
  
<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-context'></a>
`context` [TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
The [TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during deserialization.  
  
#### Returns
[T](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-T 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T')  
The object deserialized.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext)-stream 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).stream') is null.  
