#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem<T>.Update(T, ReadOnlySpan<Entity>) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.

```csharp
protected virtual void Update(T state, System.ReadOnlySpan<DefaultEcs.Entity> entities);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.Update(T,System.ReadOnlySpan_DefaultEcs.Entity_).state'></a>

`state` [T](AEntitySetSystem_T_.md#DefaultEcs.System.AEntitySetSystem_T_.T 'DefaultEcs.System.AEntitySetSystem<T>.T')

The state to use.

<a name='DefaultEcs.System.AEntitySetSystem_T_.Update(T,System.ReadOnlySpan_DefaultEcs.Entity_).entities'></a>

`entities` [System.ReadOnlySpan&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.ReadOnlySpan-1 'System.ReadOnlySpan`1')

The [Entity](Entity.md 'DefaultEcs.Entity') instances to update.