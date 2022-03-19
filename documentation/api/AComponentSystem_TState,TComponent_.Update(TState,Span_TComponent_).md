#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem<TState,TComponent>.Update(TState, Span<TComponent>) Method

Update the given [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') once.

```csharp
protected virtual void Update(TState state, System.Span<TComponent> components);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.Update(TState,System.Span_TComponent_).state'></a>

`state` [TState](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TState 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TState')

The state to use.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.Update(TState,System.Span_TComponent_).components'></a>

`components` [System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')

The [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') to update.