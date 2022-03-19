#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem(World, IParallelRunner, int) Constructor

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').

```csharp
protected AComponentSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minComponentCountByRunnerIndex);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') on which to process the update.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).minComponentCountByRunnerIndex'></a>

`minComponentCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of component per runner index to use the given [runner](AComponentSystem_TState,TComponent_.AComponentSystem(World,IParallelRunner,int).md#DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AComponentSystem_TState,TComponent_.AComponentSystem(World,IParallelRunner,int).md#DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.