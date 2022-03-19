#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## EntityMap<TKey> Class

Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMap_TKey_.md#DefaultEcs.EntityMap_TKey_.TKey 'DefaultEcs.EntityMap<TKey>.TKey') component. Only one [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMap_TKey_.md#DefaultEcs.EntityMap_TKey_.TKey 'DefaultEcs.EntityMap<TKey>.TKey').

```csharp
public sealed class EntityMap<TKey> :
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.EntityMap_TKey_.TKey'></a>

`TKey`

The type of the component used as key.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityMap<TKey>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Keys](EntityMap_TKey_.Keys.md 'DefaultEcs.EntityMap<TKey>.Keys') | Gets the keys contained in the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>'). |
| [this[TKey]](EntityMap_TKey_.this[TKey].md 'DefaultEcs.EntityMap<TKey>.this[TKey]') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key. |
| [World](EntityMap_TKey_.World.md 'DefaultEcs.EntityMap<TKey>.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') originate. |

| Methods | |
| :--- | :--- |
| [Complete()](EntityMap_TKey_.Complete().md 'DefaultEcs.EntityMap<TKey>.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder.WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded<T>()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder.WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged<T>()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder.WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved<T>()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle. |
| [Contains(Entity)](EntityMap_TKey_.Contains(Entity).md 'DefaultEcs.EntityMap<TKey>.Contains(DefaultEcs.Entity)') | Determines whether the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity'). |
| [ContainsKey(TKey)](EntityMap_TKey_.ContainsKey(TKey).md 'DefaultEcs.EntityMap<TKey>.ContainsKey(TKey)') | Determines whether the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>') contains the specified key. |
| [Dispose()](EntityMap_TKey_.Dispose().md 'DefaultEcs.EntityMap<TKey>.Dispose()') | Releases current [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>') of its subscriptions, stopping it to get modifications on the [World](World.md 'DefaultEcs.World')'s [Entity](Entity.md 'DefaultEcs.Entity'). |
| [TrimExcess()](EntityMap_TKey_.TrimExcess().md 'DefaultEcs.EntityMap<TKey>.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains. |
| [TryGetEntity(TKey, Entity)](EntityMap_TKey_.TryGetEntity(TKey,Entity).md 'DefaultEcs.EntityMap<TKey>.TryGetEntity(TKey, DefaultEcs.Entity)') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') associated with the specified key. |

| Events | |
| :--- | :--- |
| [EntityAdded](EntityMap_TKey_.EntityAdded.md 'DefaultEcs.EntityMap<TKey>.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
| [EntityRemoved](EntityMap_TKey_.EntityRemoved.md 'DefaultEcs.EntityMap<TKey>.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer'). |
