#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer.Read<T>(Stream, TextSerializationContext) Method

Read an object of type [T](TextSerializer.Read_T_(Stream,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T') from the given stream.

```csharp
public static T Read<T>(System.IO.Stream stream, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Type parameters

<a name='DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).T'></a>

`T`

The type of the object deserialized.
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.

<a name='DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).context'></a>

`context` [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')

The [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during deserialization.

#### Returns
[T](TextSerializer.Read_T_(Stream,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).T')  
The object deserialized.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer.Read_T_(Stream,TextSerializationContext).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream,DefaultEcs.Serialization.TextSerializationContext).stream 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext).stream') is null.