#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## IEntityContainer Interface
```csharp
internal interface IEntityContainer :
System.IDisposable
```

Derived  
&#8627; [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')  
&#8627; [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
&#8627; [EntitySet](EntitySet.md 'DefaultEcs.EntitySet')  
&#8627; [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Properties | |
| :--- | :--- |
| [World](IEntityContainer_World.md 'DefaultEcs.IEntityContainer.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') originate.<br/> |

| Methods | |
| :--- | :--- |
| [Complete()](IEntityContainer_Complete().md 'DefaultEcs.IEntityContainer.Complete()') | Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;()')).<br/>Does nothing if it was created from a static filter.<br/>This method need to be called after current instance content has been processed in a update cycle.<br/> |
| [Contains(Entity)](IEntityContainer_Contains(Entity).md 'DefaultEcs.IEntityContainer.Contains(DefaultEcs.Entity)') | Determines whether the [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [TrimExcess()](IEntityContainer_TrimExcess().md 'DefaultEcs.IEntityContainer.TrimExcess()') | Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains.<br/> |

| Events | |
| :--- | :--- |
| [EntityAdded](IEntityContainer_EntityAdded.md 'DefaultEcs.IEntityContainer.EntityAdded') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is added in the current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer').<br/> |
| [EntityRemoved](IEntityContainer_EntityRemoved.md 'DefaultEcs.IEntityContainer.EntityRemoved') | Occurs when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from the current [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer').<br/> |
