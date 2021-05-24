#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## EntityMultiMap&lt;TKey&gt; Class
Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey') component. Multiple [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey').  
```csharp
public sealed class EntityMultiMap<TKey> :
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_EntityMultiMap_TKey__TKey'></a>
`TKey`  
The type of the component used as key.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityMultiMap&lt;TKey&gt;  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Properties | |
| :--- | :--- |
| [Keys](EntityMultiMap_TKey__Keys.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Keys') | Gets the keys contained in the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').<br/> |
| [this[TKey]](EntityMultiMap_TKey__this_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.this[TKey]') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key.<br/> |
| [World](EntityMultiMap_TKey__World.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') originate.<br/> |

| Methods | |
| :--- | :--- |
| [Complete()](EntityMultiMap_TKey__Complete().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle.<br/> |
| [ContainsEntity(Entity)](EntityMultiMap_TKey__ContainsEntity(Entity).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.ContainsEntity(DefaultEcs.Entity)') | Determines whether the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') contains a specific [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ContainsKey(TKey)](EntityMultiMap_TKey__ContainsKey(TKey).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.ContainsKey(TKey)') | Determines whether the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') contains the specified key.<br/> |
| [Count(TKey)](EntityMultiMap_TKey__Count(TKey).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Count(TKey)') | Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') for the given [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey').<br/> |
| [Dispose()](EntityMultiMap_TKey__Dispose().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Dispose()') | Releases current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of its subscriptions, stopping it to get modifications on the [World](EntityMultiMap_TKey__World.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.World')'s [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [TrimExcess()](EntityMultiMap_TKey__TrimExcess().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') contains.<br/> |
| [TryGetEntities(TKey, ReadOnlySpan&lt;Entity&gt;)](EntityMultiMap_TKey__TryGetEntities(TKey_ReadOnlySpan_Entity_).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') instances associated with the specified key.<br/> |
