#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## IComponentTypeReader Interface

Exposes a method to be called back when getting the maximum number of component of a [World](World.md 'DefaultEcs.World'), primarly used for serialization purpose.

```csharp
public interface IComponentTypeReader
```

| Methods | |
| :--- | :--- |
| [OnRead&lt;T&gt;(int)](IComponentTypeReader.OnRead_T_(int).md 'DefaultEcs.Serialization.IComponentTypeReader.OnRead<T>(int)') | Processes the maximum number of component of type [T](IComponentTypeReader.OnRead_T_(int).md#DefaultEcs.Serialization.IComponentTypeReader.OnRead_T_(int).T 'DefaultEcs.Serialization.IComponentTypeReader.OnRead<T>(int).T'). |
