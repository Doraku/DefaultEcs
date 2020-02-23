#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T) Delegate
Represents the method that will called when a component of type [T](#DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is disabled on an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentDisabledHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T)-T'></a>
`T`  
The type of the component disabled.  
  
#### Parameters
<a name='DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') on which the component was disabled.  
  
<a name='DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T)-value'></a>
`value` [T](#DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.  
  
