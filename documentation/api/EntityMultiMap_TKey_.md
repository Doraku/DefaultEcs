#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## EntityMultiMap<TKey> Class

Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMultiMap_TKey_.md#DefaultEcs.EntityMultiMap_TKey_.TKey 'DefaultEcs.EntityMultiMap<TKey>.TKey') component. Multiple [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMultiMap_TKey_.md#DefaultEcs.EntityMultiMap_TKey_.TKey 'DefaultEcs.EntityMultiMap<TKey>.TKey').

```csharp
public sealed class EntityMultiMap<TKey> :
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.EntityMultiMap_TKey_.TKey'></a>

`TKey`

The type of the component used as key.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityMultiMap<TKey>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Keys](EntityMultiMap_TKey_.Keys.md 'DefaultEcs.EntityMultiMap<TKey>.Keys') | Gets the keys contained in the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'). |
| [this[TKey]](EntityMultiMap_TKey_.this[TKey].md 'DefaultEcs.EntityMultiMap<TKey>.this[TKey]') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key. |
| [World](EntityMultiMap_TKey_.World.md 'DefaultEcs.EntityMultiMap<TKey>.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') originate. |

| Methods | |
| :--- | :--- |
| [Complete()](EntityMultiMap_TKey_.Complete().md 'DefaultEcs.EntityMultiMap<TKey>.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder.WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded<T>()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder.WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged<T>()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder.WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle. |
| [Contains(Entity)](EntityMultiMap_TKey_.Contains(Entity).md 'DefaultEcs.EntityMultiMap<TKey>.Contains(DefaultEcs.Entity)') | Determines whether the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity'). |
| [ContainsKey(TKey)](EntityMultiMap_TKey_.ContainsKey(TKey).md 'DefaultEcs.EntityMultiMap<TKey>.ContainsKey(TKey)') | Determines whether the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') contains the specified key. |
| [Count(TKey)](EntityMultiMap_TKey_.Count(TKey).md 'DefaultEcs.EntityMultiMap<TKey>.Count(TKey)') | Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') for the given [TKey](EntityMultiMap_TKey_.md#DefaultEcs.EntityMultiMap_TKey_.TKey 'DefaultEcs.EntityMultiMap<TKey>.TKey'). |
| [Dispose()](EntityMultiMap_TKey_.Dispose().md 'DefaultEcs.EntityMultiMap<TKey>.Dispose()') | Releases current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of its subscriptions, stopping it to get modifications on the [World](EntityMultiMap_TKey_.World.md 'DefaultEcs.EntityMultiMap<TKey>.World')'s [Entity](Entity.md 'DefaultEcs.Entity'). |
| [TrimExcess()](EntityMultiMap_TKey_.TrimExcess().md 'DefaultEcs.EntityMultiMap<TKey>.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains. |
| [TryGetEntities(TKey, ReadOnlySpan&lt;Entity&gt;)](EntityMultiMap_TKey_.TryGetEntities(TKey,ReadOnlySpan_Entity_).md 'DefaultEcs.EntityMultiMap<TKey>.TryGetEntities(TKey, System.ReadOnlySpan<DefaultEcs.Entity>)') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key. |

| Events | |
| :--- | :--- |
| [EntityAdded](EntityMultiMap_TKey_.EntityAdded.md 'DefaultEcs.EntityMultiMap<TKey>.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
| [EntityRemoved](EntityMultiMap_TKey_.EntityRemoved.md 'DefaultEcs.EntityMultiMap<TKey>.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
