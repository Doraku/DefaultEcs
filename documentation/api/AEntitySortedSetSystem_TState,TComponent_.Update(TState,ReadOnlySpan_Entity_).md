#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')

## AEntitySortedSetSystem<TState,TComponent>.Update(TState, ReadOnlySpan<Entity>) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.

```csharp
protected virtual void Update(TState state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.Update(TState,System.ReadOnlySpan_DefaultEcs.Entity_).state'></a>

`state` [TState](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TState 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TState')

The state to use.

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.Update(TState,System.ReadOnlySpan_DefaultEcs.Entity_).entities'></a>

`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')

The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.