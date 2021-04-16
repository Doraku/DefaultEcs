#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## ComponentEnabledHandler&lt;T&gt;(Entity, T) Delegate
Represents the method that will called when a component of type [T](ComponentEnabledHandler_T_(Entity_T).md#DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is enabled on an [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentEnabledHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_T'></a>
`T`  
The type of the component enabled.
  
#### Parameters
<a name='DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was enabled.
  
<a name='DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_value'></a>
`value` [T](ComponentEnabledHandler_T_(Entity_T).md#DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.
  
