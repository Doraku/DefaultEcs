#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.Optimize(DefaultEcs.Threading.IParallelRunner) Method
Sorts current instance inner storage so accessing [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') and their components from [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') and [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') always move forward in memory.  
```csharp
public void Optimize(DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') to process this operation in parallel.  
  
