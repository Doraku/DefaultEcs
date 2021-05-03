#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## ComponentRemovedHandler&lt;T&gt;(Entity, T) Delegate
Represents the method that will called when a component of type [T](ComponentRemovedHandler_T_(Entity_T).md#DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentRemovedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_T'></a>
`T`  
The type of the component removed.
  
#### Parameters
<a name='DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was removed.
  
<a name='DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_value'></a>
`value` [T](ComponentRemovedHandler_T_(Entity_T).md#DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.
  
