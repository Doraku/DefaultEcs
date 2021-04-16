#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System')
## AEntityMultiMapSystem&lt;TState,TKey&gt; Class
Represents a base class to process updates on a given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance.  
```csharp
public abstract class AEntityMultiMapSystem<TState,TKey> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState'></a>
`TState`  
The type of the object used as state to update the system.
  
<a name='DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey'></a>
`TKey`  
The type of the component used as key.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntityMultiMapSystem&lt;TState,TKey&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TState 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, bool)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, bool)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  

***
[AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, IParallelRunner, int)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  

***
[AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, IParallelRunner)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey__IParallelRunner).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  

***
[AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(EntityMultiMap_TKey_).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  

***
[AEntityMultiMapSystem(World, bool)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, bool)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  

***
[AEntityMultiMapSystem(World, IParallelRunner, int)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  

***
[AEntityMultiMapSystem(World, IParallelRunner)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_IParallelRunner).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  

***
[AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, bool)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___bool).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  

***
[AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, IParallelRunner, int)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World_Func_object_World_EntityMultiMap_TKey___IParallelRunner_int).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') and factory.  
The current instance will be passed as the first parameter of the factory.  

***
[AEntityMultiMapSystem(World)](AEntityMultiMapSystem_TState_TKey__AEntityMultiMapSystem(World).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World)')

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
### Properties

***
[IsEnabled](AEntityMultiMapSystem_TState_TKey__IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.IsEnabled')

Gets or sets whether the current [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState_TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') instance should update or not.  

***
[MultiMap](AEntityMultiMapSystem_TState_TKey__MultiMap.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.MultiMap')

Gets the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance on which this system operates.  

***
[World](AEntityMultiMapSystem_TState_TKey__World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World')

Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates.  
### Methods

***
[Dispose()](AEntityMultiMapSystem_TState_TKey__Dispose().md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Dispose()')

Disposes of the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') instance.  

***
[GetKeys()](AEntityMultiMapSystem_TState_TKey__GetKeys().md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.GetKeys()')

Gets all the [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey') of the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') which [Entity](Entity.md 'DefaultEcs.Entity') instances will be updated.  

***
[PostUpdate(TState, TKey)](AEntityMultiMapSystem_TState_TKey__PostUpdate(TState_TKey).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PostUpdate(TState, TKey)')

Performs a post-update per [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey') treatment.  

***
[PostUpdate(TState)](AEntityMultiMapSystem_TState_TKey__PostUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PostUpdate(TState)')

Performs a post-update treatment.  

***
[PreUpdate(TState, TKey)](AEntityMultiMapSystem_TState_TKey__PreUpdate(TState_TKey).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PreUpdate(TState, TKey)')

Performs a pre-update per [TKey](AEntityMultiMapSystem_TState_TKey_.md#DefaultEcs_System_AEntityMultiMapSystem_TState_TKey__TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey') treatment.  

***
[PreUpdate(TState)](AEntityMultiMapSystem_TState_TKey__PreUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.PreUpdate(TState)')

Performs a pre-update treatment.  

***
[Update(TState, TKey, Entity)](AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_Entity).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, DefaultEcs.Entity)')

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.  

***
[Update(TState, TKey, ReadOnlySpan&lt;Entity&gt;)](AEntityMultiMapSystem_TState_TKey__Update(TState_TKey_ReadOnlySpan_Entity_).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState, TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')

Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.  

***
[Update(TState)](AEntityMultiMapSystem_TState_TKey__Update(TState).md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.Update(TState)')

Updates the system once.  
Does nothing if [IsEnabled](AEntityMultiMapSystem_TState_TKey__IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.IsEnabled') is false or if the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') is empty.  
