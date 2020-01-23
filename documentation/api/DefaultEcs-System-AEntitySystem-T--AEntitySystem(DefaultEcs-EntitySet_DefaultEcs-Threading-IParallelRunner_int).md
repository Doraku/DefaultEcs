#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int) Constructor
Initialise a new instance of the [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntitySystem(DefaultEcs.EntitySet set, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int)-set'></a>
`set` [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.  
  
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int)-minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](#DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int)-runner 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int).runner').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](#DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner_int)-set 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner, int).set') is null.  
