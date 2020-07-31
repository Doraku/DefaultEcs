#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem&lt;TState,TKey&gt;.PreUpdate(TState, TKey) Method
Performs a pre-update per [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey') treatment.  
```csharp
protected virtual void PreUpdate(TState state, TKey key);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--PreUpdate(TState_TKey)-state'></a>
`state` [TState](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--PreUpdate(TState_TKey)-key'></a>
`key` [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')  
The key of the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances about to be updated.  
  
