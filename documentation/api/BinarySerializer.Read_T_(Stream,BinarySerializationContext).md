#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')

## BinarySerializer.Read<T>(Stream, BinarySerializationContext) Method

Read an object of type [T](BinarySerializer.Read_T_(Stream,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T') from the given stream.

```csharp
public static T Read<T>(System.IO.Stream stream, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Type parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).T'></a>

`T`

The type of the object deserialized.
#### Parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.

<a name='DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).context'></a>

`context` [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')

The [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during deserialization.

#### Returns
[T](BinarySerializer.Read_T_(Stream,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).T')  
The object deserialized.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer.Read_T_(Stream,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.BinarySerializationContext).stream 'DefaultEcs.Serialization.BinarySerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext).stream') is null.