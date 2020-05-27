#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext) Method
Writes an object of type [T](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T') on the given stream.  
```csharp
public static void Write<T>(System.IO.Stream stream, in T value, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Type parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-T'></a>
`T`  
The type of the object serialized.  
  
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.  
  
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-value'></a>
`value` [T](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-T 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T')  
The object to serialize.  
  
<a name='DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-context'></a>
`context` [BinarySerializationContext](./DefaultEcs-Serialization-BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')  
The [BinarySerializationContext](./DefaultEcs-Serialization-BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during serialization.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext)-stream 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).stream') is null.  
