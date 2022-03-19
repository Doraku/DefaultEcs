#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[IComponentTypeReader](IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader')

## IComponentTypeReader.OnRead<T>(int) Method

Processes the maximum number of component of type [T](IComponentTypeReader.OnRead_T_(int).md#DefaultEcs.Serialization.IComponentTypeReader.OnRead_T_(int).T 'DefaultEcs.Serialization.IComponentTypeReader.OnRead<T>(int).T').

```csharp
void OnRead<T>(int maxCapacity);
```
#### Type parameters

<a name='DefaultEcs.Serialization.IComponentTypeReader.OnRead_T_(int).T'></a>

`T`

The type of component.
#### Parameters

<a name='DefaultEcs.Serialization.IComponentTypeReader.OnRead_T_(int).maxCapacity'></a>

`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of component of type [T](IComponentTypeReader.OnRead_T_(int).md#DefaultEcs.Serialization.IComponentTypeReader.OnRead_T_(int).T 'DefaultEcs.Serialization.IComponentTypeReader.OnRead<T>(int).T').