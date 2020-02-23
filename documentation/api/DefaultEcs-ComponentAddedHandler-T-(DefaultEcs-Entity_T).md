#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T) Delegate
Represents the method that will called when a component of type [T](#DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is added on an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentAddedHandler<T>(in DefaultEcs.Entity entity, in T value);
```
#### Type parameters
<a name='DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T)-T'></a>
`T`  
The type of the component added.  
  
#### Parameters
<a name='DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') on which the component was added.  
  
<a name='DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T)-value'></a>
`value` [T](#DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T)-T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T')  
The value of the component.  
  
