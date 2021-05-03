#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Threading](DefaultEcs.md#DefaultEcs_Threading 'DefaultEcs.Threading')
## DefaultParallelRunner Class
Represents an object used to run an [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') by using multiple [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task').  
```csharp
public sealed class DefaultParallelRunner :
DefaultEcs.Threading.IParallelRunner,
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; DefaultParallelRunner  

Implements [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[DefaultParallelRunner(int)](DefaultParallelRunner_DefaultParallelRunner(int).md 'DefaultEcs.Threading.DefaultParallelRunner.DefaultParallelRunner(int)')

Initialises a new instance of the [DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner') class.  
### Properties

***
[DegreeOfParallelism](DefaultParallelRunner_DegreeOfParallelism.md 'DefaultEcs.Threading.DefaultParallelRunner.DegreeOfParallelism')

Gets the degree of parallelism used to run an [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable').  
### Methods

***
[Dispose()](DefaultParallelRunner_Dispose().md 'DefaultEcs.Threading.DefaultParallelRunner.Dispose()')

Releases all the resources used by the current [DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner') instance.  

***
[Run(IParallelRunnable)](DefaultParallelRunner_Run(IParallelRunnable).md 'DefaultEcs.Threading.DefaultParallelRunner.Run(DefaultEcs.Threading.IParallelRunnable)')

Runs the provided [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable').  
