#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## EntitySet Class
Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySet_World.md 'DefaultEcs.EntitySet.World').  
```csharp
public sealed class EntitySet :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntitySet  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Properties | |
| :--- | :--- |
| [Count](EntitySet_Count.md 'DefaultEcs.EntitySet.Count') | Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/> |
| [World](EntitySet_World.md 'DefaultEcs.EntitySet.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') originate.<br/> |

| Methods | |
| :--- | :--- |
| [Complete()](EntitySet_Complete().md 'DefaultEcs.EntitySet.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle.<br/> |
| [Contains(Entity)](EntitySet_Contains(Entity).md 'DefaultEcs.EntitySet.Contains(DefaultEcs.Entity)') | Determines whether the [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [Dispose()](EntitySet_Dispose().md 'DefaultEcs.EntitySet.Dispose()') | Releases current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of its subscriptions, stopping it to get modifications on the [World](EntitySet_World.md 'DefaultEcs.EntitySet.World')'s [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [GetEntities()](EntitySet_GetEntities().md 'DefaultEcs.EntitySet.GetEntities()') | Gets the [Entity](Entity.md 'DefaultEcs.Entity') contained in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/> |
| [TrimExcess()](EntitySet_TrimExcess().md 'DefaultEcs.EntitySet.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains.<br/> |

| Events | |
| :--- | :--- |
| [EntityAdded](EntitySet_EntityAdded.md 'DefaultEcs.EntitySet.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer').<br/> |
| [EntityRemoved](EntitySet_EntityRemoved.md 'DefaultEcs.EntitySet.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer').<br/> |
