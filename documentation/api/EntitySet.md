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
### Properties

***
[Count](EntitySet_Count.md 'DefaultEcs.EntitySet.Count')

Gets the number of [Entity](Entity.md 'DefaultEcs.Entity') in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  

***
[World](EntitySet_World.md 'DefaultEcs.EntitySet.World')

Gets the [World](World.md 'DefaultEcs.World') instance from which current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') originate.  
### Methods

***
[Complete()](EntitySet_Complete().md 'DefaultEcs.EntitySet.Complete()')

Clears current instance of its entities if it was created with some reactive filter ([WhenAdded&lt;T&gt;()](EntityQueryBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;()'), [WhenChanged&lt;T&gt;()](EntityQueryBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;()') or [WhenRemoved&lt;T&gt;()](EntityQueryBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;()')).  
Does nothing if it was created from a static filter.  
This method need to be called after current instance content has been processed in a update cycle.  

***
[Contains(Entity)](EntitySet_Contains(Entity).md 'DefaultEcs.EntitySet.Contains(DefaultEcs.Entity)')

Determines whether an [Entity](Entity.md 'DefaultEcs.Entity') is in the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  

***
[Dispose()](EntitySet_Dispose().md 'DefaultEcs.EntitySet.Dispose()')

Releases current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of its subscriptions, stopping it to get modifications on the [World](EntitySet_World.md 'DefaultEcs.EntitySet.World')'s [Entity](Entity.md 'DefaultEcs.Entity').  

***
[GetEntities()](EntitySet_GetEntities().md 'DefaultEcs.EntitySet.GetEntities()')

Gets the [Entity](Entity.md 'DefaultEcs.Entity') contained in the current [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  

***
[TrimExcess()](EntitySet_TrimExcess().md 'DefaultEcs.EntitySet.TrimExcess()')

Resizes inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') this [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') contains.  
