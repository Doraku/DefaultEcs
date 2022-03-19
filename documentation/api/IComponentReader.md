#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## IComponentReader Interface

Exposes a method to be called back when getting an [Entity](Entity.md 'DefaultEcs.Entity') components, primarly used for serialization purpose.

```csharp
public interface IComponentReader
```

| Methods | |
| :--- | :--- |
| [OnRead&lt;T&gt;(T, Entity)](IComponentReader.OnRead_T_(T,Entity).md 'DefaultEcs.Serialization.IComponentReader.OnRead<T>(T, DefaultEcs.Entity)') | Processes the component of type [T](IComponentReader.OnRead_T_(T,Entity).md#DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).T 'DefaultEcs.Serialization.IComponentReader.OnRead<T>(T, DefaultEcs.Entity).T'). |
