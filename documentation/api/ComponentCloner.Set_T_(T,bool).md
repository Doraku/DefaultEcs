#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')

## ComponentCloner.Set<T>(T, bool) Method

Sets the given component on the copied entity.

```csharp
protected void Set<T>(in T component, bool isEnabled);
```
#### Type parameters

<a name='DefaultEcs.ComponentCloner.Set_T_(T,bool).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.ComponentCloner.Set_T_(T,bool).component'></a>

`component` [T](ComponentCloner.Set_T_(T,bool).md#DefaultEcs.ComponentCloner.Set_T_(T,bool).T 'DefaultEcs.ComponentCloner.Set<T>(T, bool).T')

The value of the component.

<a name='DefaultEcs.ComponentCloner.Set_T_(T,bool).isEnabled'></a>

`isEnabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the component is enabled or not on the source [Entity](Entity.md 'DefaultEcs.Entity').