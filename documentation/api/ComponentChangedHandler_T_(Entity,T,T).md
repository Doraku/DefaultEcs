#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentChangedHandler<T>(Entity, T, T) Delegate

Represents the method that will called when a component of type [T](ComponentChangedHandler_T_(Entity,T,T).md#DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).T 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public delegate void ComponentChangedHandler<T>(in DefaultEcs.Entity entity, in T oldValue, in T newValue);
```
#### Type parameters

<a name='DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).T'></a>

`T`

The type of the component removed.
#### Parameters

<a name='DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was changed.

<a name='DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).oldValue'></a>

`oldValue` [T](ComponentChangedHandler_T_(Entity,T,T).md#DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).T 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T).T')

The previous value of the component.

<a name='DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).newValue'></a>

`newValue` [T](ComponentChangedHandler_T_(Entity,T,T).md#DefaultEcs.ComponentChangedHandler_T_(DefaultEcs.Entity,T,T).T 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T).T')

The new value of the component.