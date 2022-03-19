#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem(World, Func<object,World,EntitySet>, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World') and factory.  
The current instance will be passed as the first parameter of the factory.

```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).world 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, DefaultEcs.Threading.IParallelRunner, int).world') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,DefaultEcs.Threading.IParallelRunner,int).factory 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, DefaultEcs.Threading.IParallelRunner, int).factory') is null.