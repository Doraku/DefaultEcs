#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem<TState,TComponent>.Update(TState, TComponent) Method

Update the given [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') once.

```csharp
protected virtual void Update(TState state, ref TComponent component);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.Update(TState,TComponent).state'></a>

`state` [TState](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TState 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TState')

The state to use.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.Update(TState,TComponent).component'></a>

`component` [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent')

The [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') to update.