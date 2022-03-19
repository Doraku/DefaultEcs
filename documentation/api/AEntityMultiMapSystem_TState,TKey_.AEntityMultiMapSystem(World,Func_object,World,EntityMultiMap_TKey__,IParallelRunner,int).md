#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem(World, Func<object,World,EntityMultiMap<TKey>>, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World') and factory.  
The current instance will be passed as the first parameter of the factory.

```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The factory used to create the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>').

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).world 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, DefaultEcs.Threading.IParallelRunner, int).world') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,DefaultEcs.Threading.IParallelRunner,int).factory 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, DefaultEcs.Threading.IParallelRunner, int).factory') is null.