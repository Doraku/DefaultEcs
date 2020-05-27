#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Threading](./DefaultEcs-Threading.md 'DefaultEcs.Threading')
## IParallelRunner Interface
Exposes a method to run in parallel a [IParallelRunnable](./DefaultEcs-Threading-IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable').  
```csharp
public interface IParallelRunner :
IDisposable
```
Derived  
&#8627; [DefaultParallelRunner](./DefaultEcs-Threading-DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Properties
- [DegreeOfParallelism](./DefaultEcs-Threading-IParallelRunner-DegreeOfParallelism.md 'DefaultEcs.Threading.IParallelRunner.DegreeOfParallelism')
### Methods
- [Run(DefaultEcs.Threading.IParallelRunnable)](./DefaultEcs-Threading-IParallelRunner-Run(DefaultEcs-Threading-IParallelRunnable).md 'DefaultEcs.Threading.IParallelRunner.Run(DefaultEcs.Threading.IParallelRunnable)')
