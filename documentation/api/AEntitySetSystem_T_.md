#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## AEntitySetSystem<T> Class

Represents a base class to process updates on a given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') instance.  
Only [Get&lt;T&gt;()](Entity.Get_T_().md 'DefaultEcs.Entity.Get<T>()') operations on already present component type are safe.  
Any other operation maybe change the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and should be done either by using setting "useBuffer" of the available constructors to true or using an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

```csharp
public abstract class AEntitySetSystem<T> :
DefaultEcs.System.ISystem<T>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.T'></a>

`T`

The type of the object used as state to update the system.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntitySetSystem<T>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](AEntitySetSystem_T_.md#DefaultEcs.System.AEntitySetSystem_T_.T 'DefaultEcs.System.AEntitySetSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [AEntitySetSystem(EntitySet, bool)](AEntitySetSystem_T_.AEntitySetSystem(EntitySet,bool).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.EntitySet, bool)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'). |
| [AEntitySetSystem(EntitySet, IParallelRunner, int)](AEntitySetSystem_T_.AEntitySetSystem(EntitySet,IParallelRunner,int).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'). |
| [AEntitySetSystem(World, bool)](AEntitySetSystem_T_.AEntitySetSystem(World,bool).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, bool)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntitySetSystem(World, IParallelRunner, int)](AEntitySetSystem_T_.AEntitySetSystem(World,IParallelRunner,int).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntitySetSystem(World, Func&lt;object,World,EntitySet&gt;, bool)](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,bool).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, bool)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World').<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used. |
| [AEntitySetSystem(World, Func&lt;object,World,EntitySet&gt;, IParallelRunner, int)](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,IParallelRunner,int).md 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>The current instance will be passed as the first parameter of the factory. |

| Properties | |
| :--- | :--- |
| [IsEnabled](AEntitySetSystem_T_.IsEnabled.md 'DefaultEcs.System.AEntitySetSystem<T>.IsEnabled') | Gets or sets whether the current [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') instance should update or not. |
| [Set](AEntitySetSystem_T_.Set.md 'DefaultEcs.System.AEntitySetSystem<T>.Set') | Gets the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') instance on which this system operates. |
| [World](AEntitySetSystem_T_.World.md 'DefaultEcs.System.AEntitySetSystem<T>.World') | Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates. |

| Methods | |
| :--- | :--- |
| [Dispose()](AEntitySetSystem_T_.Dispose().md 'DefaultEcs.System.AEntitySetSystem<T>.Dispose()') | Disposes of the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') instance. |
| [PostUpdate(T)](AEntitySetSystem_T_.PostUpdate(T).md 'DefaultEcs.System.AEntitySetSystem<T>.PostUpdate(T)') | Performs a post-update treatment. |
| [PreUpdate(T)](AEntitySetSystem_T_.PreUpdate(T).md 'DefaultEcs.System.AEntitySetSystem<T>.PreUpdate(T)') | Performs a pre-update treatment. |
| [Update(T)](AEntitySetSystem_T_.Update(T).md 'DefaultEcs.System.AEntitySetSystem<T>.Update(T)') | Updates the system once.<br/>Does nothing if [IsEnabled](AEntitySetSystem_T_.IsEnabled.md 'DefaultEcs.System.AEntitySetSystem<T>.IsEnabled') is false or if the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') is empty. |
| [Update(T, Entity)](AEntitySetSystem_T_.Update(T,Entity).md 'DefaultEcs.System.AEntitySetSystem<T>.Update(T, DefaultEcs.Entity)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once. |
| [Update(T, ReadOnlySpan&lt;Entity&gt;)](AEntitySetSystem_T_.Update(T,ReadOnlySpan_Entity_).md 'DefaultEcs.System.AEntitySetSystem<T>.Update(T, System.ReadOnlySpan<DefaultEcs.Entity>)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once. |
