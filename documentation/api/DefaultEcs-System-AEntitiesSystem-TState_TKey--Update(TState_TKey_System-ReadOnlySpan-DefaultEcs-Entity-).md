#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem&lt;TState,TKey&gt;.Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;) Method
Update the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances once.  
```csharp
protected virtual void Update(TState state, in TKey key, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_System-ReadOnlySpan-DefaultEcs-Entity-)-state'></a>
`state` [TState](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_System-ReadOnlySpan-DefaultEcs-Entity-)-key'></a>
`key` [TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')  
The key of the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState_TKey_System-ReadOnlySpan-DefaultEcs-Entity-)-entities'></a>
`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to update.  
  
