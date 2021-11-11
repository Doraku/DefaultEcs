#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
This is the full API documentation of DefaultEcs.  
### Namespaces
<a name='DefaultEcs'></a>
## DefaultEcs Namespace
The [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs') namespace contains types to put in place the Entity Component System pattern.  

| Classes | |
| :--- | :--- |
| [AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper') | Provides a set of methods to help the generation of generic code for AoT compilation.<br/> |
| [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') | Exposes a way to clone one [Entity](Entity.md 'DefaultEcs.Entity') components to an other.<br/> |
| [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') | Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMap_TKey_.md#DefaultEcs_EntityMap_TKey__TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey') component. Only one [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMap_TKey_.md#DefaultEcs_EntityMap_TKey__TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey').<br/> |
| [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') | Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey') component. Multiple [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey').<br/> |
| [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') | Represent an helper object to create rules to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [EntityQueryBuilder.EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder') | Represents an helper object to create an either group rule to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [EntityQueryBuilderExtension](EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension') | Provides set of static methods to create more easily rules on a [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') instance.<br/> |
| [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') | Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySet_World.md 'DefaultEcs.EntitySet.World').<br/> |
| [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') | Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySortedSet_TComponent__World.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;.World') sorted by a specific component.<br/> |
| [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension') | Provides set of static methods to automatically subscribe [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') methods marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on a [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.<br/> |
| [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') | Specifies that the method should be automatically subscribed when its parent type or instance is called with [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension').<br/>The decorated method should be of the type [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)').<br/> |
| [World](World.md 'DefaultEcs.World') | Represents a item used to create and manage [Entity](Entity.md 'DefaultEcs.Entity') objects.<br/> |

| Structs | |
| :--- | :--- |
| [Components&lt;T&gt;](Components_T_.md 'DefaultEcs.Components&lt;T&gt;') | Provides a fast access to the components of type [T](Components_T_.md#DefaultEcs_Components_T__T 'DefaultEcs.Components&lt;T&gt;.T').<br/> |
| [Entity](Entity.md 'DefaultEcs.Entity') | Represents an item in the [World](World.md 'DefaultEcs.World').<br/>Only use [Entity](Entity.md 'DefaultEcs.Entity') generated from the [CreateEntity()](World_CreateEntity().md 'DefaultEcs.World.CreateEntity()') method.<br/> |
| [EntityMap&lt;TKey&gt;.KeyEnumerable](EntityMap_TKey__KeyEnumerable.md 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerable') | Allows to enumerate the [TKey](EntityMap_TKey__KeyEnumerable.md#DefaultEcs_EntityMap_TKey__KeyEnumerable_TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerable.TKey') of a [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').<br/> |
| [EntityMap&lt;TKey&gt;.KeyEnumerator](EntityMap_TKey__KeyEnumerator.md 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerator') | Enumerates the [TKey](EntityMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerator.TKey') of a [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').<br/> |
| [EntityMultiMap&lt;TKey&gt;.KeyEnumerable](EntityMultiMap_TKey__KeyEnumerable.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerable') | Allows to enumerate the [TKey](EntityMultiMap_TKey__KeyEnumerable.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerable_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerable.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').<br/> |
| [EntityMultiMap&lt;TKey&gt;.KeyEnumerator](EntityMultiMap_TKey__KeyEnumerator.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator') | Enumerates the [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').<br/> |
| [World.Enumerator](World_Enumerator.md 'DefaultEcs.World.Enumerator') | Enumerates the [Entity](Entity.md 'DefaultEcs.Entity') of a [World](World.md 'DefaultEcs.World').<br/> |

| Interfaces | |
| :--- | :--- |
| [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') |  |
| [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') | Exposes methods to subscribe to [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') and publish message to callback those subscriptions.<br/> |

| Delegates | |
| :--- | :--- |
| [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') | Represents the method that will called when a component of type [T](ComponentAddedHandler_T_(Entity_T).md#DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is added on an [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') | Represents the method that will called when a component of type [T](ComponentChangedHandler_T_(Entity_T_T).md#DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') | Represents the method that will called when a component of type [T](ComponentDisabledHandler_T_(Entity_T).md#DefaultEcs_ComponentDisabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is disabled on an [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') | Represents the method that will called when a component of type [T](ComponentEnabledHandler_T_(Entity_T).md#DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is enabled on an [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)') | Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.<br/> |
| [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') | Represents the method that will called when a component of type [T](ComponentRemovedHandler_T_(Entity_T).md#DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [EntityAddedHandler(Entity)](EntityAddedHandler(Entity).md 'DefaultEcs.EntityAddedHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is added to a container.<br/> |
| [EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is created.<br/> |
| [EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is disabled.<br/> |
| [EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is disposed.<br/> |
| [EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is enabled.<br/> |
| [EntityRemovedHandler(Entity)](EntityRemovedHandler(Entity).md 'DefaultEcs.EntityRemovedHandler(DefaultEcs.Entity)') | Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is removed from a container.<br/> |
| [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') | Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher_Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)') method.<br/> |
| [WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') | Represents the method that will called when a [World](World.md 'DefaultEcs.World') is created.<br/> |
  
<a name='DefaultEcs_Command'></a>
## DefaultEcs.Command Namespace
The [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command') namespace contains types used in the recording and deferred execution of modifications on entities.  

| Classes | |
| :--- | :--- |
| [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') | Represents a buffer of structural modifications to apply on [Entity](Entity.md 'DefaultEcs.Entity') to record as postoned commands.<br/> |

| Structs | |
| :--- | :--- |
| [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') | Represents an [Entity](Entity.md 'DefaultEcs.Entity') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').<br/> |
| [WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord') | Represents a [World](World.md 'DefaultEcs.World') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').<br/> |
  
<a name='DefaultEcs_Resource'></a>
## DefaultEcs.Resource Namespace
The [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource') namespace contains types used in the loading of unmanaged resources needed as components.  

| Classes | |
| :--- | :--- |
| [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') | Base type used to load resources of type [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using info of type [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo').<br/>[TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') is used as key if the same resource is requested on multiple [Entity](Entity.md 'DefaultEcs.Entity') to only load the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource once.<br/>If no [Entity](Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component identifying the resource anymore, the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance is then unloaded automatically.<br/>By default, if [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [Unload(TInfo, TResource)](AResourceManager_TInfo_TResource__Unload(TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource)') will call the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method of the resource.<br/> |
| [ManagedResource&lt;TResource&gt;](ManagedResource_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;') | Provides static methods for creating [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object.<br/> |

| Structs | |
| :--- | :--- |
| [AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerable](AResourceManager_TInfo_TResource__ResourceEnumerable.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerable') | Allows to enumerate the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').<br/> |
| [AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator](AResourceManager_TInfo_TResource__ResourceEnumerator.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator') | Enumerates the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').<br/> |
| [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') | Component type used to load managed resource with a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').<br/> |
  
<a name='DefaultEcs_Serialization'></a>
## DefaultEcs.Serialization Namespace
The [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization') namespace contains types used to save and load DefaultEcs objects.  

| Classes | |
| :--- | :--- |
| [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') | Represents a context used by the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') to convert types during serialization and deserialization operations.<br/>The context marshalling will not be applied on members of unmanaged type as [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') just past their memory location with no transformation.<br/> |
| [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') | Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a binary format.<br/> |
| [ISerializerExtension](ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension') | Provides extension methods to the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') type.<br/> |
| [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') | Represents a context used by the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') to convert types during serialization and deserialization operations.<br/> |
| [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') | Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a text readable format.<br/> |

| Interfaces | |
| :--- | :--- |
| [IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader') | Exposes a method to be called back when getting an [Entity](Entity.md 'DefaultEcs.Entity') components, primarly used for serialization purpose.<br/> |
| [IComponentTypeReader](IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader') | Exposes a method to be called back when getting the maximum number of component of a [World](World.md 'DefaultEcs.World'), primarly used for serialization purpose.<br/> |
| [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') | Provides a set of methods to save and load DefaultEcs objects.<br/> |
  
<a name='DefaultEcs_System'></a>
## DefaultEcs.System Namespace
The [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System') namespace contains types to define workflows of modification on entities and components.  

| Classes | |
| :--- | :--- |
| [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') | Represents a base class to process updates on a given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') instance to all its components of type [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent').<br/> |
| [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;') | Represents a class to set up easily a custom action as a system update.<br/> |
| [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') | Represents a base class to process updates on a given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance.<br/> |
| [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') | Represents a base class to process updates on a given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') instance.<br/>Only [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](Entity_Set_T_(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(Entity)](Entity_SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.<br/> |
| [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') | Represents a base class to process updates on a given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') instance.<br/>Only [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](Entity_Set_T_(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(Entity)](Entity_SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.<br/> |
| [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') | Represents the base attribute to declare how to build the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/>Do not use this attribute, prefer [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') instead.<br/> |
| [DisabledAttribute](DisabledAttribute.md 'DefaultEcs.System.DisabledAttribute') | Makes so when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance, it will only contain disabled entities.<br/> |
| [ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;') | Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update in parallel.<br/> |
| [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') | Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update sequentially.<br/> |
| [WhenAddedAttribute](WhenAddedAttribute.md 'DefaultEcs.System.WhenAddedAttribute') | Represents a component type to react to its addition when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WhenAddedEitherAttribute](WhenAddedEitherAttribute.md 'DefaultEcs.System.WhenAddedEitherAttribute') | Represents a group of component types to react to at least one of their addition when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WhenChangedAttribute](WhenChangedAttribute.md 'DefaultEcs.System.WhenChangedAttribute') | Represents a component type to react to its change when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WhenChangedEitherAttribute](WhenChangedEitherAttribute.md 'DefaultEcs.System.WhenChangedEitherAttribute') | Represents a group of component types to react to at least one of their change when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WhenRemovedAttribute](WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute') | Represents a component type to react to its deletion when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WhenRemovedEitherAttribute](WhenRemovedEitherAttribute.md 'DefaultEcs.System.WhenRemovedEitherAttribute') | Represents a group of component types to react to at least one of their deletion when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') | Represents a component type to include when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WithEitherAttribute](WithEitherAttribute.md 'DefaultEcs.System.WithEitherAttribute') | Represents a group of component types which at least one should be present when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') | Represents a component type to exclude when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WithoutEitherAttribute](WithoutEitherAttribute.md 'DefaultEcs.System.WithoutEitherAttribute') | Represents a group of component types which at least one should not be present when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.<br/> |
| [WithPredicateAttribute](WithPredicateAttribute.md 'DefaultEcs.System.WithPredicateAttribute') | Makes so when building the inner EntitySet of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance, the decorated method will be used as a component predicate.<br/>The decorated method should be of the type [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').<br/> |

| Interfaces | |
| :--- | :--- |
| [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') | Exposes a method to update a system.<br/> |

| Enums | |
| :--- | :--- |
| [ComponentFilterType](ComponentFilterType.md 'DefaultEcs.System.ComponentFilterType') | Specifies which filter rule should be applied when using a [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').<br/> |
  
<a name='DefaultEcs_Threading'></a>
## DefaultEcs.Threading Namespace
The [DefaultEcs.Threading](DefaultEcs.md#DefaultEcs_Threading 'DefaultEcs.Threading') namespace contains types used for multithreading operations.  

| Classes | |
| :--- | :--- |
| [DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner') | Represents an object used to run an [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') by using multiple [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').<br/> |

| Interfaces | |
| :--- | :--- |
| [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') | Exposes a method to run a process in parallel.<br/> |
| [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') | Exposes a method to run in parallel a [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable').<br/> |
  
