#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')

## ComponentCloner.OnComponent<T>(T, bool) Method

Handles the component of type [T](ComponentCloner.OnComponent_T_(T,bool).md#DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).T 'DefaultEcs.ComponentCloner.OnComponent<T>(T, bool).T') from the source [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
protected virtual void OnComponent<T>(in T component, bool isEnabled);
```
#### Type parameters

<a name='DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).component'></a>

`component` [T](ComponentCloner.OnComponent_T_(T,bool).md#DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).T 'DefaultEcs.ComponentCloner.OnComponent<T>(T, bool).T')

The value of the component.

<a name='DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).isEnabled'></a>

`isEnabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the component is enabled or not on the source [Entity](Entity.md 'DefaultEcs.Entity').