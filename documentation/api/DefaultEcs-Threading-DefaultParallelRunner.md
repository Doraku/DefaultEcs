#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Threading](./DefaultEcs-Threading.md 'DefaultEcs.Threading')
## DefaultParallelRunner Class
Represents an object used to run an [IParallelRunnable](./DefaultEcs-Threading-IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') by using multiple [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').  
```C#
public sealed class DefaultParallelRunner :
IParallelRunner,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [DefaultParallelRunner](./DefaultEcs-Threading-DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner')  

Implements [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors
- [DefaultParallelRunner(int)](./DefaultEcs-Threading-DefaultParallelRunner-DefaultParallelRunner(int).md 'DefaultEcs.Threading.DefaultParallelRunner.DefaultParallelRunner(int)')
### Properties
- [DegreeOfParallelism](./DefaultEcs-Threading-DefaultParallelRunner-DegreeOfParallelism.md 'DefaultEcs.Threading.DefaultParallelRunner.DegreeOfParallelism')
### Methods
- [Dispose()](./DefaultEcs-Threading-DefaultParallelRunner-Dispose().md 'DefaultEcs.Threading.DefaultParallelRunner.Dispose()')
- [Run(DefaultEcs.Threading.IParallelRunnable)](./DefaultEcs-Threading-DefaultParallelRunner-Run(DefaultEcs-Threading-IParallelRunnable).md 'DefaultEcs.Threading.DefaultParallelRunner.Run(DefaultEcs.Threading.IParallelRunnable)')
