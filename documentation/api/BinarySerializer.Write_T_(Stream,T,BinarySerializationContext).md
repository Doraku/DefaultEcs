#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')

## BinarySerializer.Write<T>(Stream, T, BinarySerializationContext) Method

Writes an object of type [T](BinarySerializer.Write_T_(Stream,T,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T') on the given stream.

```csharp
public static void Write<T>(System.IO.Stream stream, in T value, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Type parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).T'></a>

`T`

The type of the object serialized.
#### Parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).value'></a>

`value` [T](BinarySerializer.Write_T_(Stream,T,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).T')

The object to serialize.

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).context'></a>

`context` [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')

The [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during serialization.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer.Write_T_(Stream,T,BinarySerializationContext).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.BinarySerializationContext).stream 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext).stream') is null.