#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## ComponentChangedHandler&lt;T&gt;(Entity, T, T) Delegate
Represents the method that will called when a component of type [T](ComponentChangedHandler_T_(Entity_T_T).md#DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentChangedHandler<T>(in DefaultEcs.Entity entity, in T oldValue, in T newValue);
```
#### Type parameters
<a name='DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T'></a>
`T`  
The type of the component removed.
  
#### Parameters
<a name='DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was changed.
  
<a name='DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_oldValue'></a>
`oldValue` [T](ComponentChangedHandler_T_(Entity_T_T).md#DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T')  
The previous value of the component.
  
<a name='DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_newValue'></a>
`newValue` [T](ComponentChangedHandler_T_(Entity_T_T).md#DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T')  
The new value of the component.
  
