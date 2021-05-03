#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Optimize(IParallelRunner, Action) Method
Sorts current instance inner storage so accessing [Entity](Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  
This method will return once [mainAction](World_Optimize(IParallelRunner_Action).md#DefaultEcs_World_Optimize(DefaultEcs_Threading_IParallelRunner_System_Action)_mainAction 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action).mainAction') is executed even if the optimization process has not finished.  
```csharp
public void Optimize(DefaultEcs.Threading.IParallelRunner runner, System.Action mainAction);
```
#### Parameters
<a name='DefaultEcs_World_Optimize(DefaultEcs_Threading_IParallelRunner_System_Action)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') to process this operation in parallel.
  
<a name='DefaultEcs_World_Optimize(DefaultEcs_Threading_IParallelRunner_System_Action)_mainAction'></a>
`mainAction` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')  
An [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action') to execute on the main thread while the optimization is in process.
  
