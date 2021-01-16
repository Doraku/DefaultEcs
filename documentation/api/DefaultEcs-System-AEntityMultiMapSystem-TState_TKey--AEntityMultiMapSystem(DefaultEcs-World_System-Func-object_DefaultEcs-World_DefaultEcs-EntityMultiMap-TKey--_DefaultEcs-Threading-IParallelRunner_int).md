#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') and factory.  
The current instance will be passed as the first parameter of the factory.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](./DefaultEcs-World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-runner 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).world') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_DefaultEcs-Threading-IParallelRunner_int)-factory 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, DefaultEcs.Threading.IParallelRunner, int).factory') is null.  
