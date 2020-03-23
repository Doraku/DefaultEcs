#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T) Delegate
Represents the method that will called when a component of type [T](#DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T') is removed from an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```csharp
public delegate void ComponentChangedHandler<T>(in DefaultEcs.Entity entity, in T oldValue, in T newValue);
```
#### Type parameters
<a name='DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-T'></a>
`T`  
The type of the component removed.  
  
#### Parameters
<a name='DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') on which the component was changed.  
  
<a name='DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-oldValue'></a>
`oldValue` [T](#DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T')  
The previous value of the component.  
  
<a name='DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-newValue'></a>
`newValue` [T](#DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T)-T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T')  
The new value of the component.  
  
