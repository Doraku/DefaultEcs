#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## IComponentReader Interface
Exposes a method to be called back when getting an [Entity](Entity.md 'DefaultEcs.Entity') components, primarly used for serialization purpose.  
```csharp
public interface IComponentReader
```
### Methods

***
[OnRead&lt;T&gt;(T, Entity)](IComponentReader_OnRead_T_(T_Entity).md 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity)')

Processes the component of type [T](IComponentReader_OnRead_T_(T_Entity).md#DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_T 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity).T').  
