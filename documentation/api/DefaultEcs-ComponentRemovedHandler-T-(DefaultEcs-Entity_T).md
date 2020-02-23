#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T) Delegate
Represents the method that will called when a component of type [T](#DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is removed from an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentRemovedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T)-T'></a>
`T`  
The type of the component removed.  
  
#### Parameters
<a name='DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') on which the component was removed.  
  
<a name='DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T)-value'></a>
`value` [T](#DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.  
  
