#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int) Constructor
Initialise a new instance of the [AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;') class with the given [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntitiesSystem(DefaultEcs.EntitiesMap<TKey> map, DefaultEcs.Threading.IParallelRunner runner, int minEntityCountByRunnerIndex);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int)-map'></a>
`map` [DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') on which to process the update.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int)-minEntityCountByRunnerIndex'></a>
`minEntityCountByRunnerIndex` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The minimum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') per runner index to use the given [runner](#DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int)-runner 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int).runner').  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](#DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner_int)-map 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner, int).map') is null.  
