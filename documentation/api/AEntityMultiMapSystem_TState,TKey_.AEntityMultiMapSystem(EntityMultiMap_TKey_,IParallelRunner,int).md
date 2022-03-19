#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem(EntityMultiMap<TKey>, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').

```csharp
protected AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey> map, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex=0);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap_TKey_,DefaultEcs.Threading.IParallelRunner,int).map'></a>

`map` [DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')

The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') on which to process the update.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap_TKey_,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap_TKey_,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(EntityMultiMap_TKey_,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap_TKey_,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey>, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(EntityMultiMap_TKey_,IParallelRunner,int).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap_TKey_,DefaultEcs.Threading.IParallelRunner,int).map 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey>, DefaultEcs.Threading.IParallelRunner, int).map') is null.