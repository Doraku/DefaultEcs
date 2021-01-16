#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState) Method
Updates the system once.  
Does nothing if [IsEnabled](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.IsEnabled') is false or if the inner [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') is empty.  
```csharp
public void Update(TState state);
```
#### Parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--Update(TState)-state'></a>
`state` [TState](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')  
The state to use.  
  
