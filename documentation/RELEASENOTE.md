## DefaultEcs 0.14.4
added quote and multiline string support to TextSerializer  
added EntityRuleBuilder.Copy to duplicate an EntityRuleBuilder  
added EntityRuleBuilder.AsMap with capacity parameter  
added EntityRuleBuilder.AsMultiMap with capacity parameter  
added EntitiesMap.Count to get the number of entities for a given key  
added AResourceManager.Resources to get all resources loaded  
added AEntitiesSystem to process EntitiesMap in a controlled way  

fixed EntitySet, EntityMap and EntitiesMap initialization with pre-existing entities when applying a component predicate  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.14.4)

## DefaultEcs 0.14.3
added componentFilter parameter on BinarySerializer and TextSerializer to apply a filter on which component type should be serialized or deserialized  
added BinarySerializationContext to provide transformation between types when using the BinarySerializer  
added TextSerializationContext to provide transformation between types when using the TextSerializer  

fixed BinarySerializer and TextSerializer closing the stream parameter, it is now left open  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.14.3)

## DefaultEcs 0.14.2
removed restriction on ManagedResource TResource to be IDisposable  

added AResourceManager.Unload to give the possibility to override the unload action for a resource  

fixed Entity.Set overriding shared component value  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.14.2)

## DefaultEcs 0.14.1
fixed Entity.ReadAllComponents accessing previous value component used by map  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.14.1)

## DefaultEcs 0.14.0
breaking change:  
removed World.MaxEntityCount, obsolete  
removed World.SetMaximumComponentCount, obsolete  
removed World.GetMaximumComponentCount, obsolete  
removed World.GetAllComponents, obsolete  
removed World.GetAllEntities, obsolete  
removed World.EntityDisposed  
removed EntitySet.EntityAdded  
removed EntitySet.EntityRemoved  
removed AEntityBufferedSystem.EntityAdded  
removed AEntityBufferedSystem.EntityRemoved  
removed AEntitySystem.EntityAdded  
removed AEntitySystem.EntityRemoved  
renamed EntitySetBuilder to EntityRuleBuilder  
renamed EntitySetBuilderExtension to EntityRuleBuilderExtension  
renamed ActionIn to MessageHandler  

fixed BinarySerializer and TextSerializer serialization of multi generic types  
fixed World multi Dispose  

added World.Optimize to sort entities and their components so accessing them through EntitySet always move forward in memory  
added World.SubscribeEntityCreated to be called back when an entity is created  
added World.SubscribeEntityEnabled to be called back when an entity is enabled  
added World.SubscribeEntityDisabled to be called back when an entity is disabled  
added World.SubscribeEntityDisposed to be called back when an entity is disposed  
added World.SubscribeComponentAdded to be called back when a component is added on an entity  
added World.SubscribeComponentChanged to be called back when a component is changed on an entity  
added World.SubscribeComponentRemoved to be called back when a component is removed from an entity  
added World.SubscribeComponentEnabled to be called back when a component is enabled on an entity  
added World.SubscribeComponentDisabled to be called back when a component is disabled on an entity  
added EntityRuleBuilder.With with a Predicate parameter  
added EntityRuleBuilder.AsPredicate to get a predicate to validate the composition of an entity  
added EntityRuleBuilder.AsMap to get a mapping of entities by their component value  
added EntityRuleBuilder.AsMultiMap to get a mapping of entities by their component value  
added Entity.NotifyChanged to defer the notification that a component has changed  
added EntityRecord.NotifyChanged to defer the notification that a component has changed  
added AoTHelper to help the generic code generation for AoT compilation  
added EntityMap to have a one for one mapping between a component value and an entity  
added EntitiesMap to have a one to many mapping between a component value and entities  
added WithPredicateAttribute attribute to decorate ComponentPredicate methods in AEntitySystem and AEntityBufferedSystem to automatically build the underlying EntitySet with the predicate  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.14.0)

## DefaultEcs 0.13.1
added minEntityCountByRunnerIndex parameter to AEntitySystem constructors  
added minComponentCountByRunnerIndex parameter to AComponentSystem constructor  
added AEntityBufferedSystem type to make structural modification on entities in a safe way  
added World.MaxCapacity property, obsolete MaxEntityCount  
added World.SetMaxCapacity method, obsolete SetMaximumComponentCount  
added World.GetMaxCapacity method, obsolete GetMaximumComponentCount  
added World.Get method, obsolete GetAllComponents  
added World.GetEnumerator method, obsolete GetAllEntities  
added EntitySet.World property  
added Components type for fast access to entities component  
added World.GetComponents method  

changed BinarySerializer and TextSerializer to be assembly version independent  

updated System.Reflection.Emit.Lightweight to 4.7.0  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.13.1)

## DefaultEcs 0.13.0
breaking change:  
removed SystemRunner type, use DefaultEcs.Threading.DefaultParallelRunner instead  
removed ASystem type  
refactored EntitySetBuilder to a more fluent syntax, Build changed to AsSet, *Either&lt;T1, T2&gt;() replaced by *Either&lt;T1&gt;().Or&lt;T2&gt;()  
      
added World.GetDisabledEntities method to create EntitySet for disabled entities  
added DisabledAttribute to auto construct EntitySet of disabled entities for AEntitySystem  
added EntitySet.Contains method to check for an Entity inclusion  
added IParallelRunner to allow custom implementation to process AEntitySystem, AComponentSystem and ParallelSystem in parallel  
added Entity.World property  

fixed EntityCommandRecorder SetSameAs and Dispose command  
fixed size of commands in EntityCommandRecorder  
fixed size of Entity  
fixed WithoutEitherAttribute filter generation  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.13.0)

## DefaultEcs 0.12.1
fixed serialization of struct as an object  
fixed serialization of Type  
fixed AResourceManager.Manage for existing entities  

added netstandard2.1 target  
added == and != operators on Entity  
added internal version on Entity, Entity.IsAlive will return false if a stored disposed entity is reused  
added a helper ManagedResource static class to create ManagedResource  

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.12.1)

## DefaultEcs 0.12.0
breaking change:  
renamed EntitySetBuilder.WithAny and WithAny attribute to WithEither  
removed some methods from EntitySetBuilderExtension, Either methods stops at 3 components types but it is easy to add more if needed

added WithoutEither filter for EntitySet  
added WhenAddedEither filter for EntitySet  
added WhenChangedEither filter for EntitySet  
added WhenRemovedEither filter for EntitySet  
changed BinarySerializer Exception to EndOfStreamException

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.12.0)

## DefaultEcs 0.11.0
updated System.Memory reference  
enhanced debugging experience on World, Entity and EntitySet  
added MaxCapacity, Capacity and Size properties on EntityCommandRecorder  
added EntityAdded and EntityRemoved events on EntitySet  
added EntityAdded and EntityRemoved events on AEntitySystem  
added EntityDisposed event on World  
added WhenAdded, WhenChanged and WhenRemoved filter on EntitySetBuilder to create reactive EntitySet  
added WhenAddedAttribute, WhenChangedAttribute and WhenRemovedAttribute for automatique AEntitySystem EntitySet creation from a World  
added Complete method on EntitySet to clear its content if created with a reactive filter  
made T of ISystem contravariant

breaking changes  
removed IEntitySetObserver and implementation, use EntityAdded and EntityRemoved events on EntitySet instead

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.11.0)

## DefaultEcs 0.10.1
fixed multiple subscriptions on IPublisherExtension.Subscribe when a virtual method is decorated and overriden in a derived type

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.10.1)

## DefaultEcs 0.10.0
fixed double Dispose in AResourceManager  
fixed reference count in AResourceManager when World is disposed  
fixed Entity.CopyTo to correctly copy enabled/disabled state  
fixed non unmanaged struct serialization in BinarySerializer

added IEntitySetObserver and basic implementation EntitySetObserverEvents to get add/remove operations on EntitySet  
added EntityCommandRecorder to defer structural entity changes

breaking change: SubscribeAction renamed ActionIn

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.10.0)

## DefaultEcs 0.9.2
added IsAlive property on Entity  
added With(Type[]) and Without(Type[]) on EntitySetBuilder  
added managed resource helper class (probably not final)

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.9.2)

## DefaultEcs 0.9.1
added debug info for World  
added a way to enable/disable an entity without removing it  
handled empty struct as special flag case to not waste memory  
added a way to enable/disable a component on an entity without removing it

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.9.1)

## DefaultEcs 0.9.0
updated System.Memory reference  
added WithAny filter for EntitySetBuilder

Breaking change:  
added IsEnabled property on ISystem

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.9.0)

## DefaultEcs 0.8.1
fixed to have metadata documentation for all target frameworks  
changed With and Without attribute to accept multiple types

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.8.1)

## DefaultEcs 0.8.0
added SubscribeAttribute to automatically subscribe to decorated methods  
changed World.SetMaximumComponentCount return type and added World.GetMaximumComponentCount  
broke compatibility with BinarySerializer v0.7.0 produced data

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.8.0)

## DefaultEcs 0.7.0
added IPublisher abstraction on World  
fixed IEnumerable<Entity> serialization/deserialization  
relaxed World size at creation to allow growth when needed

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.7.0)

## DefaultEcs 0.6.3
reduced cpu usage of multithreading SystemRunner when idling

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.6.3)

## DefaultEcs 0.6.2
made ISystem implements IDisposable  
added WithAttribute and WithoutAttribute attributes to define EntitySet from World in AEntitySystem

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.6.2)

## DefaultEcs 0.6.1
added RemoveFromChildrenOf and RemoveFromParentsOf methods on Entity to remove hierarchy of dispose chain  
BinarySerializer and TextSerializer now handle abstract types and types with no default constructor  
some fixes on BinarySerializer and TextSerializer

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.6.1)

## DefaultEcs 0.6.0
added serialize feature to World and Entity  
renamed AEntitySetSystem base class to AEntitySystem  
renamed World.SetComponentTypeMaximumCount method to SetMaximumComponentCount  
inner improvements

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.6.0)

## DefaultEcs 0.5.0
added base system class to update an EntitySet  
added base system class to update a component type on a World  
added system class to process custom Action as update  
added system class to update sequentially multiple systems  
added system class to update in parallel multiple systems  
added a way to build entities hierarchy for dispose chain

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.5.0)

## DefaultEcs 0.4.0
Entity.Get is now unsafe: exception is more cryptic if it does not have a component but it's faster so eh  
updated System.Memory reference

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.4.0)

## DefaultEcs 0.3.2-alpha
relaxed the need to create EntitySet before creating Entity  
added default value to Entity.Set

fixed leak with EntitySetBuilder  
fixed Entity.Remove for multiple entity with the same component

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.3.2-alpha)

## DefaultEcs 0.3.1-alpha
fixed refCount bug when disposing Entity

[nuget package](https://www.nuget.org/packages/DefaultEcs/0.3.1-alpha)