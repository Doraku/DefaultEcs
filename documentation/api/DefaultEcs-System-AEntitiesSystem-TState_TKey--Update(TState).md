#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem&lt;TState,TKey&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AEntitiesSystem-TState_TKey--IsEnabled.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.IsEnabled') is false or if the inner [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') is empty.  
```csharp
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--Update(TState)-state'></a>
`state` [TState](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TState 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
