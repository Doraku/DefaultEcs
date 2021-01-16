#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action) Method
Sorts current instance inner storage so accessing [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  
This method will return once [mainAction](#DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner_System-Action)-mainAction 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action).mainAction') is executed even if the optimization process has not finished.  
```csharp
public void Optimize(DefaultEcs.Threading.IParallelRunner runner, System.Action mainAction);
```
#### Parameters
<a name='DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner_System-Action)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') to process this operation in parallel.  
  
<a name='DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner_System-Action)-mainAction'></a>
`mainAction` [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action')  
An [System.Action](https://docs.microsoft.com/en-us/dotnet/api/System.Action 'System.Action') to execute on the main thread while the optimization is in process.  
  
