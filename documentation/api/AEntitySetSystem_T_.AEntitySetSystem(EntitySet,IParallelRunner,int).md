#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem(EntitySet, IParallelRunner, int) Constructor

Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').

```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex=0);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,DefaultEcs.Threading.IParallelRunner,int).set'></a>

`set` [EntitySet](EntitySet.md 'DefaultEcs.EntitySet')

The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,DefaultEcs.Threading.IParallelRunner,int).runner'></a>

`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')

The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,DefaultEcs.Threading.IParallelRunner,int).minEntityCountByRunnerIndex'></a>

`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The minimum number of [Entity](Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](AEntitySetSystem_T_.AEntitySetSystem(EntitySet,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,DefaultEcs.Threading.IParallelRunner,int).runner 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int).runner').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](AEntitySetSystem_T_.AEntitySetSystem(EntitySet,IParallelRunner,int).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,DefaultEcs.Threading.IParallelRunner,int).set 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int).set') is null.