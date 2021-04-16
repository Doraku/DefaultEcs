#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## IComponentTypeReader Interface
Exposes a method to be called back when getting the maximum number of component of a [World](World.md 'DefaultEcs.World'), primarly used for serialization purpose.  
```csharp
public interface IComponentTypeReader
```
### Methods

***
[OnRead&lt;T&gt;(int)](IComponentTypeReader_OnRead_T_(int).md 'DefaultEcs.Serialization.IComponentTypeReader.OnRead&lt;T&gt;(int)')

Processes the maximum number of component of type [T](IComponentTypeReader_OnRead_T_(int).md#DefaultEcs_Serialization_IComponentTypeReader_OnRead_T_(int)_T 'DefaultEcs.Serialization.IComponentTypeReader.OnRead&lt;T&gt;(int).T').  
