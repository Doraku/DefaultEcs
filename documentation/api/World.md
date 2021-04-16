#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## World Class
Represents a item used to create and manage [Entity](Entity.md 'DefaultEcs.Entity') objects.  
```csharp
public sealed class World :
System.Collections.Generic.IEnumerable<DefaultEcs.Entity>,
System.Collections.IEnumerable,
DefaultEcs.IPublisher,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; World  

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [IPublisher](IPublisher.md 'DefaultEcs.IPublisher'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[World()](World_World().md 'DefaultEcs.World.World()')

Initializes a new instance of the [World](World.md 'DefaultEcs.World') class.  

***
[World(int)](World_World(int).md 'DefaultEcs.World.World(int)')

Initializes a new instance of the [World](World.md 'DefaultEcs.World') class.  
### Properties

***
[MaxCapacity](World_MaxCapacity.md 'DefaultEcs.World.MaxCapacity')

Gets the maximum number of [Entity](Entity.md 'DefaultEcs.Entity') this [World](World.md 'DefaultEcs.World') can handle.  
### Methods

***
[CreateEntity()](World_CreateEntity().md 'DefaultEcs.World.CreateEntity()')

Creates a new instance of the [Entity](Entity.md 'DefaultEcs.Entity') struct.  

***
[Dispose()](World_Dispose().md 'DefaultEcs.World.Dispose()')

Cleans up all the components of existing [Entity](Entity.md 'DefaultEcs.Entity').  
The current [World](World.md 'DefaultEcs.World'), all [Entity](Entity.md 'DefaultEcs.Entity') and [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') created from this instance, should not be used again after calling this method.  

***
[Get&lt;T&gt;()](World_Get_T_().md 'DefaultEcs.World.Get&lt;T&gt;()')

Gets all the component of a given type [T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T').  

***
[GetComponents&lt;T&gt;()](World_GetComponents_T_().md 'DefaultEcs.World.GetComponents&lt;T&gt;()')

Gets an [Components&lt;T&gt;](Components_T_.md 'DefaultEcs.Components&lt;T&gt;') to get a fast access to the component of type [T](World_GetComponents_T_().md#DefaultEcs_World_GetComponents_T_()_T 'DefaultEcs.World.GetComponents&lt;T&gt;().T') of this [World](World.md 'DefaultEcs.World') instance [Entity](Entity.md 'DefaultEcs.Entity').  

***
[GetDisabledEntities()](World_GetDisabledEntities().md 'DefaultEcs.World.GetDisabledEntities()')

Gets an [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') to create a subset of disabled [Entity](Entity.md 'DefaultEcs.Entity') of the current [World](World.md 'DefaultEcs.World').  

***
[GetEntities()](World_GetEntities().md 'DefaultEcs.World.GetEntities()')

Gets an [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') to create a subset of [Entity](Entity.md 'DefaultEcs.Entity') of the current [World](World.md 'DefaultEcs.World').  

***
[GetEnumerator()](World_GetEnumerator().md 'DefaultEcs.World.GetEnumerator()')

Returns an enumerator that iterates through the [Entity](Entity.md 'DefaultEcs.Entity') of the current [World](World.md 'DefaultEcs.World') instance.  

***
[GetMaxCapacity&lt;T&gt;()](World_GetMaxCapacity_T_().md 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;()')

Gets the maximum number of [T](World_GetMaxCapacity_T_().md#DefaultEcs_World_GetMaxCapacity_T_()_T 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;().T') components this [World](World.md 'DefaultEcs.World') can create.  

***
[Optimize()](World_Optimize().md 'DefaultEcs.World.Optimize()')

Sorts current instance inner storage so accessing [Entity](Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  

***
[Optimize(IParallelRunner)](World_Optimize(IParallelRunner).md 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner)')

Sorts current instance inner storage so accessing [Entity](Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  

***
[Optimize(IParallelRunner, Action)](World_Optimize(IParallelRunner_Action).md 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action)')

Sorts current instance inner storage so accessing [Entity](Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  
This method will return once [mainAction](World_Optimize(IParallelRunner_Action).md#DefaultEcs_World_Optimize(DefaultEcs_Threading_IParallelRunner_System_Action)_mainAction 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action).mainAction') is executed even if the optimization process has not finished.  

***
[Publish&lt;T&gt;(T)](World_Publish_T_(T).md 'DefaultEcs.World.Publish&lt;T&gt;(T)')

Publishes a [T](World_Publish_T_(T).md#DefaultEcs_World_Publish_T_(T)_T 'DefaultEcs.World.Publish&lt;T&gt;(T).T') object.  

***
[ReadAllComponentTypes(IComponentTypeReader)](World_ReadAllComponentTypes(IComponentTypeReader).md 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader)')

Calls on [reader](World_ReadAllComponentTypes(IComponentTypeReader).md#DefaultEcs_World_ReadAllComponentTypes(DefaultEcs_Serialization_IComponentTypeReader)_reader 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader).reader') with all the maximum number of component of the current [World](World.md 'DefaultEcs.World').  
This method is primiraly used for serialization purpose and should not be called in game logic.  

***
[SetMaxCapacity&lt;T&gt;(int)](World_SetMaxCapacity_T_(int).md 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int)')

Sets up the current [World](World.md 'DefaultEcs.World') to handle component of type [T](World_SetMaxCapacity_T_(int).md#DefaultEcs_World_SetMaxCapacity_T_(int)_T 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int).T') with a different maximum count than [MaxCapacity](World_MaxCapacity.md 'DefaultEcs.World.MaxCapacity').  
If the type of component is already handled by the current [World](World.md 'DefaultEcs.World'), does nothing.  

***
[Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](World_Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)')

Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to be called back when a [T](World_Subscribe_T_(MessageHandler_T_).md#DefaultEcs_World_Subscribe_T_(DefaultEcs_MessageHandler_T_)_T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T') object is published.  

***
[SubscribeComponentAdded&lt;T&gt;(ComponentAddedHandler&lt;T&gt;)](World_SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;)')

Subscribes a [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).T') is added.  

***
[SubscribeComponentChanged&lt;T&gt;(ComponentChangedHandler&lt;T&gt;)](World_SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;)')

Subscribes a [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).T') is changed.  

***
[SubscribeComponentDisabled&lt;T&gt;(ComponentDisabledHandler&lt;T&gt;)](World_SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;)')

Subscribes a [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).T') is disabled.  

***
[SubscribeComponentEnabled&lt;T&gt;(ComponentEnabledHandler&lt;T&gt;)](World_SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;)')

Subscribes a [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).T') is enabled.  

***
[SubscribeComponentRemoved&lt;T&gt;(ComponentRemovedHandler&lt;T&gt;)](World_SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;)')

Subscribes an [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).T') is removed.  

***
[SubscribeEntityCreated(EntityCreatedHandler)](World_SubscribeEntityCreated(EntityCreatedHandler).md 'DefaultEcs.World.SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler)')

Subscribes an [EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is created.  

***
[SubscribeEntityDisabled(EntityDisabledHandler)](World_SubscribeEntityDisabled(EntityDisabledHandler).md 'DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler)')

Subscribes an [EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is disabled.  

***
[SubscribeEntityDisposed(EntityDisposedHandler)](World_SubscribeEntityDisposed(EntityDisposedHandler).md 'DefaultEcs.World.SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler)')

Subscribes an [EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is disposed.  

***
[SubscribeEntityEnabled(EntityEnabledHandler)](World_SubscribeEntityEnabled(EntityEnabledHandler).md 'DefaultEcs.World.SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler)')

Subscribes an [EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is enabled.  

***
[SubscribeWorldDisposed(WorldDisposedHandler)](World_SubscribeWorldDisposed(WorldDisposedHandler).md 'DefaultEcs.World.SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler)')

Subscribes an [WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') on the current [World](World.md 'DefaultEcs.World') to be called when current instance is disposed.  

***
[ToString()](World_ToString().md 'DefaultEcs.World.ToString()')

Returns a string representation of this instance.  

***
[TrimExcess&lt;T&gt;()](World_TrimExcess_T_().md 'DefaultEcs.World.TrimExcess&lt;T&gt;()')

Resizes inner storage to exactly the number of [T](World_TrimExcess_T_().md#DefaultEcs_World_TrimExcess_T_()_T 'DefaultEcs.World.TrimExcess&lt;T&gt;().T') components this [World](World.md 'DefaultEcs.World') contains.  

***
[TrimExcess()](World_TrimExcess().md 'DefaultEcs.World.TrimExcess()')

Resizes all inner storage to exactly the number of [Entity](Entity.md 'DefaultEcs.Entity') and components this [World](World.md 'DefaultEcs.World') contains.  
### Explicit Interface Implementations

***
[System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;.GetEnumerator()](World_System_Collections_Generic_IEnumerable_DefaultEcs_Entity__GetEnumerator().md 'DefaultEcs.World.System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;.GetEnumerator()')

Returns an enumerator that iterates through the [Entity](Entity.md 'DefaultEcs.Entity') of the current [World](World.md 'DefaultEcs.World') instance.  

***
[System.Collections.IEnumerable.GetEnumerator()](World_System_Collections_IEnumerable_GetEnumerator().md 'DefaultEcs.World.System.Collections.IEnumerable.GetEnumerator()')

Returns an enumerator that iterates through the [Entity](Entity.md 'DefaultEcs.Entity') of the current [World](World.md 'DefaultEcs.World') instance.  
