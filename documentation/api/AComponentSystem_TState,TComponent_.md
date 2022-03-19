#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## AComponentSystem<TState,TComponent> Class

Represents a base class to process updates on a given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') instance to all its components of type [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent').

```csharp
public abstract class AComponentSystem<TState,TComponent> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.TState'></a>

`TState`

The type of the object used as state to update the system.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent'></a>

`TComponent`

The type of component to update.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AComponentSystem<TState,TComponent>

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[TState](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TState 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [AComponentSystem(World)](AComponentSystem_TState,TComponent_.AComponentSystem(World).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World)') | Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World'). |
| [AComponentSystem(World, IParallelRunner)](AComponentSystem_TState,TComponent_.AComponentSystem(World,IParallelRunner).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)') | Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'). |
| [AComponentSystem(World, IParallelRunner, int)](AComponentSystem_TState,TComponent_.AComponentSystem(World,IParallelRunner,int).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)') | Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'). |

| Properties | |
| :--- | :--- |
| [IsEnabled](AComponentSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.IsEnabled') | Gets or sets whether the current [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') instance should update or not. |
| [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') | Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates. |

| Methods | |
| :--- | :--- |
| [Dispose()](AComponentSystem_TState,TComponent_.Dispose().md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.Dispose()') | Does nothing. |
| [PostUpdate(TState)](AComponentSystem_TState,TComponent_.PostUpdate(TState).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.PostUpdate(TState)') | Performs a post-update treatment. |
| [PreUpdate(TState)](AComponentSystem_TState,TComponent_.PreUpdate(TState).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.PreUpdate(TState)') | Performs a pre-update treatment. |
| [Update(TState)](AComponentSystem_TState,TComponent_.Update(TState).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.Update(TState)') | Updates the system once.<br/>Does nothing if [IsEnabled](AComponentSystem_TState,TComponent_.IsEnabled.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.IsEnabled') is false or if there is no component of type [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') in the [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World'). |
| [Update(TState, Span&lt;TComponent&gt;)](AComponentSystem_TState,TComponent_.Update(TState,Span_TComponent_).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.Update(TState, System.Span<TComponent>)') | Update the given [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') once. |
| [Update(TState, TComponent)](AComponentSystem_TState,TComponent_.Update(TState,TComponent).md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.Update(TState, TComponent)') | Update the given [TComponent](AComponentSystem_TState,TComponent_.md#DefaultEcs.System.AComponentSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AComponentSystem<TState,TComponent>.TComponent') once. |
