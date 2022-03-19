#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## AEntityMultiMapSystem<TState,TKey> Class

Represents a base class to process updates on a given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') instance.  
Only [Get&lt;T&gt;()](Entity.Get_T_().md 'DefaultEcs.Entity.Get<T>()') operations on already present component type are safe.  
Any other operation maybe change the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') and should be done either by setting "useBuffer" of the available constructors to true or using an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

```csharp
public abstract class AEntityMultiMapSystem<TState,TKey> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState'></a>

`TState`

The type of the object used as state to update the system.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey'></a>

`TKey`

The type of the component used as key.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntityMultiMapSystem<TState,TKey>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[TState](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TState 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, bool)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(EntityMultiMap_TKey_,bool).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey>, bool)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'). |
| [AEntityMultiMapSystem(EntityMultiMap&lt;TKey&gt;, IParallelRunner, int)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(EntityMultiMap_TKey_,IParallelRunner,int).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey>, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'). |
| [AEntityMultiMapSystem(World, bool)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,bool).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, bool)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntityMultiMapSystem(World, IParallelRunner, int)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,IParallelRunner,int).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, bool)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,bool).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, bool)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntityMultiMapSystem(World, Func&lt;object,World,EntityMultiMap&lt;TKey&gt;&gt;, IParallelRunner, int)](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,IParallelRunner,int).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>The current instance will be passed as the first parameter of the factory. |

| Properties | |
| :--- | :--- |
| [IsEnabled](AEntityMultiMapSystem_TState,TKey_.IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.IsEnabled') | Gets or sets whether the current [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') instance should update or not. |
| [MultiMap](AEntityMultiMapSystem_TState,TKey_.MultiMap.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.MultiMap') | Gets the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') instance on which this system operates. |
| [World](AEntityMultiMapSystem_TState,TKey_.World.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.World') | Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates. |

| Methods | |
| :--- | :--- |
| [Dispose()](AEntityMultiMapSystem_TState,TKey_.Dispose().md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.Dispose()') | Disposes of the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') instance. |
| [GetKeys()](AEntityMultiMapSystem_TState,TKey_.GetKeys().md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.GetKeys()') | Gets all the [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey') of the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') which [Entity](Entity.md 'DefaultEcs.Entity') instances will be updated. |
| [PostUpdate(TState)](AEntityMultiMapSystem_TState,TKey_.PostUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.PostUpdate(TState)') | Performs a post-update treatment. |
| [PostUpdate(TState, TKey)](AEntityMultiMapSystem_TState,TKey_.PostUpdate(TState,TKey).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.PostUpdate(TState, TKey)') | Performs a post-update per [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey') treatment. |
| [PreUpdate(TState)](AEntityMultiMapSystem_TState,TKey_.PreUpdate(TState).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.PreUpdate(TState)') | Performs a pre-update treatment. |
| [PreUpdate(TState, TKey)](AEntityMultiMapSystem_TState,TKey_.PreUpdate(TState,TKey).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.PreUpdate(TState, TKey)') | Performs a pre-update per [TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey') treatment. |
| [Update(TState)](AEntityMultiMapSystem_TState,TKey_.Update(TState).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.Update(TState)') | Updates the system once.<br/>Does nothing if [IsEnabled](AEntityMultiMapSystem_TState,TKey_.IsEnabled.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.IsEnabled') is false or if the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') is empty. |
| [Update(TState, TKey, Entity)](AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,Entity).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.Update(TState, TKey, DefaultEcs.Entity)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once. |
| [Update(TState, TKey, ReadOnlySpan&lt;Entity&gt;)](AEntityMultiMapSystem_TState,TKey_.Update(TState,TKey,ReadOnlySpan_Entity_).md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.Update(TState, TKey, System.ReadOnlySpan<DefaultEcs.Entity>)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once. |
