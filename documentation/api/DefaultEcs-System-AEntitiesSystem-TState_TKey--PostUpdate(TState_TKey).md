#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem&lt;TState,TKey&gt;.PostUpdate(TState, TKey) Method
Performs a post-update per [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey') treatment.  
```csharp
protected virtual void PostUpdate(TState state, TKey key);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--PostUpdate(TState_TKey)-state'></a>
`state` [TState](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--PostUpdate(TState_TKey)-key'></a>
`key` [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')  
The key of the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances which have been updated.  
  
