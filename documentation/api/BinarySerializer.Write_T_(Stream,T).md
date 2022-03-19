#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')

## BinarySerializer.Write<T>(Stream, T) Method

Writes an object of type [T](BinarySerializer.Write_T_(Stream,T).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T).T') on the given stream.

```csharp
public static void Write<T>(System.IO.Stream stream, in T value);
```
#### Type parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).T'></a>

`T`

The type of the object serialized.
#### Parameters

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.

<a name='DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).value'></a>

`value` [T](BinarySerializer.Write_T_(Stream,T).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).T 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T).T')

The object to serialize.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](BinarySerializer.Write_T_(Stream,T).md#DefaultEcs.Serialization.BinarySerializer.Write_T_(System.IO.Stream,T).stream 'DefaultEcs.Serialization.BinarySerializer.Write<T>(System.IO.Stream, T).stream') is null.