#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer.Write<T>(Stream, T, TextSerializationContext) Method

Writes an object of type [T](TextSerializer.Write_T_(Stream,T,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext).T') on the given stream.

```csharp
public static void Write<T>(System.IO.Stream stream, in T value, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Type parameters

<a name='DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).T'></a>

`T`

The type of the object serialized.
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.

<a name='DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).value'></a>

`value` [T](TextSerializer.Write_T_(Stream,T,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext).T')

The object to serialize.

<a name='DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).context'></a>

`context` [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')

The [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during serialization.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer.Write_T_(Stream,T,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Write_T_(System.IO.Stream,T,DefaultEcs.Serialization.TextSerializationContext).stream 'DefaultEcs.Serialization.TextSerializer.Write<T>(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext).stream') is null.