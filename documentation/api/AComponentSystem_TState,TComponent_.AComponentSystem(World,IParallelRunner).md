#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem(World, IParallelRunner) Constructor

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').

```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') on which to process the update.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AComponentSystem_TState,TComponent_.AComponentSystem(World,IParallelRunner).md#DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner).world 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner).world') is null.