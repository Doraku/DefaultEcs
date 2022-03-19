#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem<TState,TKey>.Update(TState) Method

Updates the system once.  
Does nothing if [IsEnabled](AEntityMultiMapSystem_TState,TKey_.IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.IsEnabled') is false or if the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') is empty.

```csharp
public void Update(TState state);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.Update(TState).state'></a>

`state` [TState](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TState')

The state to use.

Implements [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)')