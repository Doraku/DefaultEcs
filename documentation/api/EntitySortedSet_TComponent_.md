#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## EntitySortedSet<TComponent> Class

Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySortedSet_TComponent_.World.md 'DefaultEcs.EntitySortedSet<TComponent>.World') sorted by a specific component.

```csharp
public sealed class EntitySortedSet<TComponent> :
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.EntitySortedSet_TComponent_.TComponent'></a>

`TComponent`

The type of the component to sort [Entity](Entity.md 'DefaultEcs.Entity') by.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntitySortedSet<TComponent>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Count](EntitySortedSet_TComponent_.Count.md 'DefaultEcs.EntitySortedSet<TComponent>.Count') | Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>'). |
| [World](EntitySortedSet_TComponent_.World.md 'DefaultEcs.EntitySortedSet<TComponent>.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') originate. |

| Methods | |
| :--- | :--- |
| [Complete()](EntitySortedSet_TComponent_.Complete().md 'DefaultEcs.EntitySortedSet<TComponent>.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder.WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded<T>()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder.WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged<T>()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder.WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle. |
| [Contains(Entity)](EntitySortedSet_TComponent_.Contains(Entity).md 'DefaultEcs.EntitySortedSet<TComponent>.Contains(DefaultEcs.Entity)') | Determines whether the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity'). |
| [Dispose()](EntitySortedSet_TComponent_.Dispose().md 'DefaultEcs.EntitySortedSet<TComponent>.Dispose()') | Releases current [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') of its subscriptions, stopping it to get modifications on the [World](EntitySortedSet_TComponent_.World.md 'DefaultEcs.EntitySortedSet<TComponent>.World')'s [Entity](Entity.md 'DefaultEcs.Entity'). |
| [GetEntities()](EntitySortedSet_TComponent_.GetEntities().md 'DefaultEcs.EntitySortedSet<TComponent>.GetEntities()') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') contained in the current [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>'). |
| [TrimExcess()](EntitySortedSet_TComponent_.TrimExcess().md 'DefaultEcs.EntitySortedSet<TComponent>.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains. |

| Events | |
| :--- | :--- |
| [EntityAdded](EntitySortedSet_TComponent_.EntityAdded.md 'DefaultEcs.EntitySortedSet<TComponent>.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
| [EntityRemoved](EntitySortedSet_TComponent_.EntityRemoved.md 'DefaultEcs.EntitySortedSet<TComponent>.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
