#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem<TState,TComponent>.Update(TState) Method

Updates the system once.  
Does nothing if [IsEnabled](AComponentSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.IsEnabled') is false or if there is no component of type [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') in the [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World').

```csharp
public void Update(TState state);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.Update(TState).state'></a>

`state` [TState](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TState 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TState')

The state to use.

Implements [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)')