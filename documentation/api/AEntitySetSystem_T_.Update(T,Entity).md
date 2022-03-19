#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem<T>.Update(T, Entity) Method

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.

```csharp
protected virtual void Update(T state, in DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.Update(T,DefaultEcs.Entity).state'></a>

`state` [T](AEntitySetSystem_T_.md#DefaultEcs.System.AEntitySetSystem_T_.T 'DefaultEcs.System.AEntitySetSystem<T>.T')

The state to use.

<a name='DefaultEcs.System.AEntitySetSystem_T_.Update(T,DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') instance to update.