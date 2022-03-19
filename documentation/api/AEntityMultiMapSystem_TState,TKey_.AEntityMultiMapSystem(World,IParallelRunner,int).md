#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem(World, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex=0);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.