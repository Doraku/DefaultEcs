#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem&lt;TState,TKey&gt;.Update(TState, TKey, DefaultEcs.Entity) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instance once.  
```csharp
protected virtual void Update(TState state, in TKey key, in DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_DefaultEcs-Entity)-state'></a>
`state` [TState](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_DefaultEcs-Entity)-key'></a>
`key` [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')  
The key of the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_DefaultEcs-Entity)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instance to update.  
  
