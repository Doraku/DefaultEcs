#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner) Constructor
Initialise a new instance of the [AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;') class with the given [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntitiesSystem(DefaultEcs.EntitiesMap<TKey> map, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner)-map'></a>
`map` [DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') on which to process the update.  
  
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](#DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-_DefaultEcs-Threading-IParallelRunner)-map 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;, DefaultEcs.Threading.IParallelRunner).map') is null.  
