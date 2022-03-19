#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem(World, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntitySetSystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex=0);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntitySetSystem_T_.AEntitySetSystem(World,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T_.AEntitySetSystem(World,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,DefaultEcs.Threading.IParallelRunner,int).world 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner, int).world') is null.