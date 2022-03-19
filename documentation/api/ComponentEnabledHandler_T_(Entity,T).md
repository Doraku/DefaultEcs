#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentEnabledHandler<T>(Entity, T) Delegate

Represents the method that will called when a component of type [T](ComponentEnabledHandler_T_(Entity,T).md#DefaultEcs.ComponentEnabledHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T).T') is enabled on an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public delegate void ComponentEnabledHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters

<a name='DefaultEcs.ComponentEnabledHandler_T_(DefaultEcs.Entity,T).T'></a>

`T`

The type of the component enabled.
#### Parameters

<a name='DefaultEcs.ComponentEnabledHandler_T_(DefaultEcs.Entity,T).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was enabled.

<a name='DefaultEcs.ComponentEnabledHandler_T_(DefaultEcs.Entity,T).value'></a>

`value` [T](ComponentEnabledHandler_T_(Entity,T).md#DefaultEcs.ComponentEnabledHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T).T')

The value of the component.