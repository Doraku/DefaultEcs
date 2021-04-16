#### [DefaultEcs](index.md 'index')
This is the full API documentation of DefaultEcs.  
### Namespaces
<a name='DefaultEcs'></a>
## DefaultEcs Namespace
The [DefaultEcs](index.md#DefaultEcs 'DefaultEcs') namespace contains types to put in place the Entity Component System pattern.  
### Classes

***
[AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper')

Provides a set of methods to help the generation of generic code for AoT compilation.  

***
[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')

Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMap_TKey_.md#DefaultEcs_EntityMap_TKey__TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey') component. Only one [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMap_TKey_.md#DefaultEcs_EntityMap_TKey__TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey').  

***
[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')

Represents a collection of [Entity](Entity.md 'DefaultEcs.Entity') mapped to a [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey') component. Multiple [Entity](Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](EntityMultiMap_TKey_.md#DefaultEcs_EntityMultiMap_TKey__TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey').  

***
[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')

Represent an helper object to create rules to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').  

***
[EntityQueryBuilder.EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

Represents an helper object to create an either group rule to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').  

***
[EntityQueryBuilderExtension](EntityQueryBuilderExtension.md 'DefaultEcs.EntityQueryBuilderExtension')

Provides set of static methods to create more easily rules on a [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') instance.  

***
[EntitySet](EntitySet.md 'DefaultEcs.EntitySet')

Represents a sub-selection of [Entity](Entity.md 'DefaultEcs.Entity') instances from a [World](EntitySet_World.md 'DefaultEcs.EntitySet.World').  

***
[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')

Provides set of static methods to automatically subscribe [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') methods marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on a [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  

***
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute')

Specifies that the method should be automatically subscribed when its parent type or instance is called with [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension').  
The decorated method should be of the type [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)').  

***
[World](World.md 'DefaultEcs.World')

Represents a item used to create and manage [Entity](Entity.md 'DefaultEcs.Entity') objects.  
### Structs

***
[Components&lt;T&gt;](Components_T_.md 'DefaultEcs.Components&lt;T&gt;')

Provides a fast access to the components of type [T](Components_T_.md#DefaultEcs_Components_T__T 'DefaultEcs.Components&lt;T&gt;.T').  

***
[Entity](Entity.md 'DefaultEcs.Entity')

Represents an item in the [World](World.md 'DefaultEcs.World').  
Only use [Entity](Entity.md 'DefaultEcs.Entity') generated from the [CreateEntity()](World_CreateEntity().md 'DefaultEcs.World.CreateEntity()') method.  

***
[EntityMap&lt;TKey&gt;.KeyEnumerable](EntityMap_TKey__KeyEnumerable.md 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerable')

Allows to enumerate the [TKey](EntityMap_TKey__KeyEnumerable.md#DefaultEcs_EntityMap_TKey__KeyEnumerable_TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerable.TKey') of a [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').  

***
[EntityMap&lt;TKey&gt;.KeyEnumerator](EntityMap_TKey__KeyEnumerator.md 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerator')

Enumerates the [TKey](EntityMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.KeyEnumerator.TKey') of a [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').  

***
[EntityMultiMap&lt;TKey&gt;.KeyEnumerable](EntityMultiMap_TKey__KeyEnumerable.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerable')

Allows to enumerate the [TKey](EntityMultiMap_TKey__KeyEnumerable.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerable_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerable.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  

***
[EntityMultiMap&lt;TKey&gt;.KeyEnumerator](EntityMultiMap_TKey__KeyEnumerator.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator')

Enumerates the [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  

***
[World.Enumerator](World_Enumerator.md 'DefaultEcs.World.Enumerator')

Enumerates the [Entity](Entity.md 'DefaultEcs.Entity') of a [World](World.md 'DefaultEcs.World').  
### Interfaces

***
[IPublisher](IPublisher.md 'DefaultEcs.IPublisher')

Exposes methods to subscribe to [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') and publish message to callback those subscriptions.  
### Delegates

***
[ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)')

Represents the method that will called when a component of type [T](ComponentAddedHandler_T_(Entity_T).md#DefaultEcs_ComponentAddedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is added on an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)')

Represents the method that will called when a component of type [T](ComponentChangedHandler_T_(Entity_T_T).md#DefaultEcs_ComponentChangedHandler_T_(DefaultEcs_Entity_T_T)_T 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')

Represents the method that will called when a component of type [T](ComponentDisabledHandler_T_(Entity_T).md#DefaultEcs_ComponentDisabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is disabled on an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')

Represents the method that will called when a component of type [T](ComponentEnabledHandler_T_(Entity_T).md#DefaultEcs_ComponentEnabledHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is enabled on an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)')

Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.  

***
[ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)')

Represents the method that will called when a component of type [T](ComponentRemovedHandler_T_(Entity_T).md#DefaultEcs_ComponentRemovedHandler_T_(DefaultEcs_Entity_T)_T 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T).T') is removed from an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)')

Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is created.  

***
[EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)')

Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is disabled.  

***
[EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)')

Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is disposed.  

***
[EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)')

Represents the method that will called when an [Entity](Entity.md 'DefaultEcs.Entity') is enabled.  

***
[MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)')

Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher_Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)') method.  

***
[WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)')

Represents the method that will called when a [World](World.md 'DefaultEcs.World') is created.  
  
<a name='DefaultEcs_Command'></a>
## DefaultEcs.Command Namespace
The [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command') namespace contains types used in the recording and deferred execution of modifications on entities.  
### Classes

***
[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')

Represents a buffer of structural modifications to apply on [Entity](Entity.md 'DefaultEcs.Entity') to record as postoned commands.  
### Structs

***
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

Represents an [Entity](Entity.md 'DefaultEcs.Entity') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
  
<a name='DefaultEcs_Resource'></a>
## DefaultEcs.Resource Namespace
The [DefaultEcs.Resource](index.md#DefaultEcs_Resource 'DefaultEcs.Resource') namespace contains types used in the loading of unmanaged resources needed as components.  
### Classes

***
[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')

Base type used to load resources of type [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using info of type [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo').  
[TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') is used as key if the same resource is requested on multiple [Entity](Entity.md 'DefaultEcs.Entity') to only load the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource once.  
If no [Entity](Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component identifying the resource anymore, the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance is then unloaded automatically.  
By default, if [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [Unload(TInfo, TResource)](AResourceManager_TInfo_TResource__Unload(TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource)') will call the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method of the resource.  

***
[ManagedResource&lt;TResource&gt;](ManagedResource_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;')

Provides static methods for creating [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object.  
### Structs

***
[AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerable](AResourceManager_TInfo_TResource__ResourceEnumerable.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerable')

Allows to enumerate the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  

***
[AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator](AResourceManager_TInfo_TResource__ResourceEnumerator.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator')

Enumerates the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  

***
[ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')

Component type used to load managed resource with a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  
  
<a name='DefaultEcs_Serialization'></a>
## DefaultEcs.Serialization Namespace
The [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization') namespace contains types used to save and load DefaultEcs objects.  
### Classes

***
[BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')

Represents a context used by the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') to convert types during serialization and deserialization operations.  
The context marshalling will not be applied on members of unmanaged type as [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') just past their memory location with no transformation.  

***
[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')

Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a binary format.  

***
[ISerializerExtension](ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension')

Provides extension methods to the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') type.  

***
[TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')

Represents a context used by the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') to convert types during serialization and deserialization operations.  

***
[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

Provides a basic implementation of the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a text readable format.  
### Interfaces

***
[IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')

Exposes a method to be called back when getting an [Entity](Entity.md 'DefaultEcs.Entity') components, primarly used for serialization purpose.  

***
[IComponentTypeReader](IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader')

Exposes a method to be called back when getting the maximum number of component of a [World](World.md 'DefaultEcs.World'), primarly used for serialization purpose.  

***
[ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer')

Provides a set of methods to save and load DefaultEcs objects.  
  
<a name='DefaultEcs_System'></a>
## DefaultEcs.System Namespace
The [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System') namespace contains types to define workflows of modification on entities and components.  
### Classes

***
[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')

Represents a base class to process updates on a given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') instance to all its components of type [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent').  

***
[ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')

Represents a class to set up easily a custom action as a system update.  

***
[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')

Represents a base class to process updates on a given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance.  

***
[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')

Represents a base class to process updates on a given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') instance.  
Only [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](Entity_Set_T_(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(Entity)](Entity_SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.  

***
[ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute')

Represents the base attribute to declare how to build the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  
Do not use this attribute, prefer [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') instead.  

***
[DisabledAttribute](DisabledAttribute.md 'DefaultEcs.System.DisabledAttribute')

Makes so when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance, it will only contain disabled entities.  

***
[ParallelSystem&lt;T&gt;](ParallelSystem_T_.md 'DefaultEcs.System.ParallelSystem&lt;T&gt;')

Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update in parallel.  

***
[SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')

Represents a collection of [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update sequentially.  

***
[WhenAddedAttribute](WhenAddedAttribute.md 'DefaultEcs.System.WhenAddedAttribute')

Represents a component type to react to its addition when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WhenAddedEitherAttribute](WhenAddedEitherAttribute.md 'DefaultEcs.System.WhenAddedEitherAttribute')

Represents a group of component types to react to at least one of their addition when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WhenChangedAttribute](WhenChangedAttribute.md 'DefaultEcs.System.WhenChangedAttribute')

Represents a component type to react to its change when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WhenChangedEitherAttribute](WhenChangedEitherAttribute.md 'DefaultEcs.System.WhenChangedEitherAttribute')

Represents a group of component types to react to at least one of their change when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WhenRemovedAttribute](WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute')

Represents a component type to react to its deletion when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WhenRemovedEitherAttribute](WhenRemovedEitherAttribute.md 'DefaultEcs.System.WhenRemovedEitherAttribute')

Represents a group of component types to react to at least one of their deletion when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute')

Represents a component type to include when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WithEitherAttribute](WithEitherAttribute.md 'DefaultEcs.System.WithEitherAttribute')

Represents a group of component types which at least one should be present when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute')

Represents a component type to exclude when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WithoutEitherAttribute](WithoutEitherAttribute.md 'DefaultEcs.System.WithoutEitherAttribute')

Represents a group of component types which at least one should not be present when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  

***
[WithPredicateAttribute](WithPredicateAttribute.md 'DefaultEcs.System.WithPredicateAttribute')

Makes so when building the inner EntitySet of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance, the decorated method will be used as a component predicate.  
The decorated method should be of the type [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  
### Interfaces

***
[ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')

Exposes a method to update a system.  
### Enums

***
[ComponentFilterType](ComponentFilterType.md 'DefaultEcs.System.ComponentFilterType')

Specifies which filter rule should be applied when using a [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').  
  
<a name='DefaultEcs_Threading'></a>
## DefaultEcs.Threading Namespace
The [DefaultEcs.Threading](index.md#DefaultEcs_Threading 'DefaultEcs.Threading') namespace contains types used for multithreading operations.  
### Classes

***
[DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner')

Represents an object used to run an [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') by using multiple [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').  
### Interfaces

***
[IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable')

Exposes a method to run a process in parallel.  

***
[IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

Exposes a method to run in parallel a [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable').  
  
