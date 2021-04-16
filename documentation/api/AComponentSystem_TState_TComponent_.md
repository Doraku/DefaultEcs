#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System')
## AComponentSystem&lt;TState,TComponent&gt; Class
Represents a base class to process updates on a given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') instance to all its components of type [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent').  
```csharp
public abstract class AComponentSystem<TState,TComponent> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__TState'></a>
`TState`  
The type of the object used as state to update the system.
  
<a name='DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent'></a>
`TComponent`  
The type of component to update.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AComponentSystem&lt;TState,TComponent&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TState 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[AComponentSystem(World)](AComponentSystem_TState_TComponent__AComponentSystem(World).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World)')

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World').  

***
[AComponentSystem(World, IParallelRunner)](AComponentSystem_TState_TComponent__AComponentSystem(World_IParallelRunner).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner)')

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  

***
[AComponentSystem(World, IParallelRunner, int)](AComponentSystem_TState_TComponent__AComponentSystem(World_IParallelRunner_int).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int)')

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') class with the given [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
### Properties

***
[IsEnabled](AComponentSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled')

Gets or sets whether the current [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState_TComponent_.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') instance should update or not.  

***
[World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World')

Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates.  
### Methods

***
[Dispose()](AComponentSystem_TState_TComponent__Dispose().md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Dispose()')

Does nothing.  

***
[PostUpdate(TState)](AComponentSystem_TState_TComponent__PostUpdate(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.PostUpdate(TState)')

Performs a post-update treatment.  

***
[PreUpdate(TState)](AComponentSystem_TState_TComponent__PreUpdate(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.PreUpdate(TState)')

Performs a pre-update treatment.  

***
[Update(TState)](AComponentSystem_TState_TComponent__Update(TState).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState)')

Updates the system once.  
Does nothing if [IsEnabled](AComponentSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.IsEnabled') is false or if there is no component of type [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') in the [World](AComponentSystem_TState_TComponent__World.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.World').  

***
[Update(TState, TComponent)](AComponentSystem_TState_TComponent__Update(TState_TComponent).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, TComponent)')

Update the given [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') once.  

***
[Update(TState, Span&lt;TComponent&gt;)](AComponentSystem_TState_TComponent__Update(TState_Span_TComponent_).md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.Update(TState, System.Span&lt;TComponent&gt;)')

Update the given [TComponent](AComponentSystem_TState_TComponent_.md#DefaultEcs_System_AComponentSystem_TState_TComponent__TComponent 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;.TComponent') once.  
