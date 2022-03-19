#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')

## IComponentReader.OnRead<T>(T, Entity) Method

Processes the component of type [T](IComponentReader.OnRead_T_(T,Entity).md#DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).T 'DefaultEcs.Serialization.IComponentReader.OnRead<T>(T, DefaultEcs.Entity).T').

```csharp
void OnRead<T>(in T component, in DefaultEcs.Entity componentOwner);
```
#### Type parameters

<a name='DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).T'></a>

`T`

The type of component.
#### Parameters

<a name='DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).component'></a>

`component` [T](IComponentReader.OnRead_T_(T,Entity).md#DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).T 'DefaultEcs.Serialization.IComponentReader.OnRead<T>(T, DefaultEcs.Entity).T')

The component.

<a name='DefaultEcs.Serialization.IComponentReader.OnRead_T_(T,DefaultEcs.Entity).componentOwner'></a>

`componentOwner` [Entity](Entity.md 'DefaultEcs.Entity')

The owner of the component instance, in case it is used by multiple [Entity](Entity.md 'DefaultEcs.Entity').