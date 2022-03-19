#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## EntitySet Class

Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySet.World.md 'DefaultEcs.EntitySet.World').

```csharp
public sealed class EntitySet :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntitySet

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Count](EntitySet.Count.md 'DefaultEcs.EntitySet.Count') | Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'). |
| [World](EntitySet.World.md 'DefaultEcs.EntitySet.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') originate. |

| Methods | |
| :--- | :--- |
| [Complete()](EntitySet.Complete().md 'DefaultEcs.EntitySet.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder.WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded<T>()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder.WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged<T>()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder.WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle. |
| [Contains(Entity)](EntitySet.Contains(Entity).md 'DefaultEcs.EntitySet.Contains(DefaultEcs.Entity)') | Determines whether the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity'). |
| [Dispose()](EntitySet.Dispose().md 'DefaultEcs.EntitySet.Dispose()') | Releases current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of its subscriptions, stopping it to get modifications on the [World](EntitySet.World.md 'DefaultEcs.EntitySet.World')'s [Entity](Entity.md 'DefaultEcs.Entity'). |
| [GetEntities()](EntitySet.GetEntities().md 'DefaultEcs.EntitySet.GetEntities()') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') contained in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'). |
| [TrimExcess()](EntitySet.TrimExcess().md 'DefaultEcs.EntitySet.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains. |

| Events | |
| :--- | :--- |
| [EntityAdded](EntitySet.EntityAdded.md 'DefaultEcs.EntitySet.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
| [EntityRemoved](EntitySet.EntityRemoved.md 'DefaultEcs.EntitySet.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
