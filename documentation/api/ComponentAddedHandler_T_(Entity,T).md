#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentAddedHandler<T>(Entity, T) Delegate

Represents the method that will called when a component of type [T](ComponentAddedHandler_T_(Entity,T).md#DefaultEcs.ComponentAddedHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T).T') is added on an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public delegate void ComponentAddedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters

<a name='DefaultEcs.ComponentAddedHandler_T_(DefaultEcs.Entity,T).T'></a>

`T`

The type of the component added.
#### Parameters

<a name='DefaultEcs.ComponentAddedHandler_T_(DefaultEcs.Entity,T).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was added.

<a name='DefaultEcs.ComponentAddedHandler_T_(DefaultEcs.Entity,T).value'></a>

`value` [T](ComponentAddedHandler_T_(Entity,T).md#DefaultEcs.ComponentAddedHandler_T_(DefaultEcs.Entity,T).T 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T).T')

The value of the component.