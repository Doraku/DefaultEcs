#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') and factory.  
The current instance will be passed as the first parameter of the factory.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](./DefaultEcs-World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-runner 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).world') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_DefaultEcs-Threading-IParallelRunner_int)-factory 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, DefaultEcs.Threading.IParallelRunner, int).factory') is null.  
