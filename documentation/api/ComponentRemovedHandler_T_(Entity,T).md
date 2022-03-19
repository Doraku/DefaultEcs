#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentRemovedHandler<T>(Entity, T) Delegate

Represents the method that will called when a component of type [T](ComponentRemovedHandler_T_(Entity,T).md#DefaultEcs.ComponentRemovedHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public delegate void ComponentRemovedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters

<a name='DefaultEcs.ComponentRemovedHandler_T_(DefaultEcs.Entity,T).T'></a>

`T`

The type of the component removed.
#### Parameters

<a name='DefaultEcs.ComponentRemovedHandler_T_(DefaultEcs.Entity,T).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was removed.

<a name='DefaultEcs.ComponentRemovedHandler_T_(DefaultEcs.Entity,T).value'></a>

`value` [T](ComponentRemovedHandler_T_(Entity,T).md#DefaultEcs.ComponentRemovedHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T).T')

The value of the component.