#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## ComponentAddedHandler&lt;T&gt;(Entity, T) Delegate
Represents the method that will called when a component of type [T](ComponentAddedHandler_T_(Entity_T).md#DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is added on an [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentAddedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_T'></a>
`T`  
The type of the component added.
  
#### Parameters
<a name='DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') on which the component was added.
  
<a name='DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_value'></a>
`value` [T](ComponentAddedHandler_T_(Entity_T).md#DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.
  
