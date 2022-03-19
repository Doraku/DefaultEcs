#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## AEntitySortedSetSystem<TState,TComponent> Class

Represents a base class to process updates on a given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') instance.  
Only [Get&lt;T&gt;()](Entity.Get_T_().md 'DefaultEcs.Entity.Get<T>()') operations on already present component type are safe.  
Any other operation maybe change the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') and should be done either by using setting "useBuffer" of the available constructors to true or using an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

```csharp
public abstract class AEntitySortedSetSystem<TState,TComponent> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TState'></a>

`TState`

The type of the object used as state to update the system.

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TComponent'></a>

`TComponent`

The type of the component to sort [Entity](Entity.md 'DefaultEcs.Entity') by.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntitySortedSetSystem<TState,TComponent>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[TState](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TState 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [AEntitySortedSetSystem(EntitySortedSet&lt;TComponent&gt;, bool)](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(EntitySortedSet_TComponent_,bool).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet<TComponent>, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>'). |
| [AEntitySortedSetSystem(World, bool)](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(World,bool).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.World, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntitySortedSetSystem(World, Func&lt;object,World,EntitySortedSet&lt;TComponent&gt;&gt;, bool)](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(World,Func_object,World,EntitySortedSet_TComponent__,bool).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySortedSet<TComponent>>, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |

| Properties | |
| :--- | :--- |
| [IsEnabled](AEntitySortedSetSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.IsEnabled') | Gets or sets whether the current [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') instance should update or not. |
| [SortedSet](AEntitySortedSetSystem_TState,TComponent_.SortedSet.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.SortedSet') | Gets the [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') instance on which this system operates. |
| [World](AEntitySortedSetSystem_TState,TComponent_.World.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.World') | Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates. |

| Methods | |
| :--- | :--- |
| [Dispose()](AEntitySortedSetSystem_TState,TComponent_.Dispose().md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.Dispose()') | Disposes of the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') instance. |
| [PostUpdate(TState)](AEntitySortedSetSystem_TState,TComponent_.PostUpdate(TState).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.PostUpdate(TState)') | Performs a post-update treatment. |
| [PreUpdate(TState)](AEntitySortedSetSystem_TState,TComponent_.PreUpdate(TState).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.PreUpdate(TState)') | Performs a pre-update treatment. |
| [Update(TState)](AEntitySortedSetSystem_TState,TComponent_.Update(TState).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.Update(TState)') | Updates the system once.<br/>Does nothing if [IsEnabled](AEntitySortedSetSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.IsEnabled') is false or if the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') is empty. |
| [Update(TState, Entity)](AEntitySortedSetSystem_TState,TComponent_.Update(TState,Entity).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.Update(TState, DefaultEcs.Entity)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once. |
| [Update(TState, ReadOnlySpan&lt;Entity&gt;)](AEntitySortedSetSystem_TState,TComponent_.Update(TState,ReadOnlySpan_Entity_).md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.Update(TState, System.ReadOnlySpan<DefaultEcs.Entity>)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once. |
