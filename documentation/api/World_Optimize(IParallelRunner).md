#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Optimize(IParallelRunner) Method
Sorts current instance inner storage so accessing [Entity](Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  
This method is not thread safe.  
```csharp
public void Optimize(DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs_World_Optimize(DefaultEcs_Threading_IParallelRunner)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') to process this operation in parallel.
  
