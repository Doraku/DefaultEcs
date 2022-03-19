#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentDisabledHandler<T>(Entity, T) Delegate

Represents the method that will called when a component of type [T](ComponentDisabledHandler_T_(Entity,T).md#DefaultEcs.ComponentDisabledHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T).T') is disabled on an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public delegate void ComponentDisabledHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters

<a name='DefaultEcs.ComponentDisabledHandler_T_(DefaultEcs.Entity,T).T'></a>

`T`

The type of the component disabled.
#### Parameters

<a name='DefaultEcs.ComponentDisabledHandler_T_(DefaultEcs.Entity,T).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was disabled.

<a name='DefaultEcs.ComponentDisabledHandler_T_(DefaultEcs.Entity,T).value'></a>

`value` [T](ComponentDisabledHandler_T_(Entity,T).md#DefaultEcs.ComponentDisabledHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T).T')

The value of the component.