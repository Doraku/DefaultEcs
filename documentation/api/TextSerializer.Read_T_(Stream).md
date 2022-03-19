#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer.Read<T>(Stream) Method

Read an object of type [T](TextSerializer.Read_T_(Stream).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream).T') from the given stream.

```csharp
public static T Read<T>(System.IO.Stream stream);
```
#### Type parameters

<a name='DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).T'></a>

`T`

The type of the object deserialized.
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.

#### Returns
[T](TextSerializer.Read_T_(Stream).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).T 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream).T')  
The object deserialized.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](TextSerializer.Read_T_(Stream).md#DefaultEcs.Serialization.TextSerializer.Read_T_(System.IO.Stream).stream 'DefaultEcs.Serialization.TextSerializer.Read<T>(System.IO.Stream).stream') is null.