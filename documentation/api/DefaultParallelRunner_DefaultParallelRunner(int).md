#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Threading](DefaultEcs.md#DefaultEcs_Threading 'DefaultEcs.Threading').[DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner')
## DefaultParallelRunner.DefaultParallelRunner(int) Constructor
Initialises a new instance of the [DefaultParallelRunner](DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner') class.  
```csharp
public DefaultParallelRunner(int degreeOfParallelism);
```
#### Parameters
<a name='DefaultEcs_Threading_DefaultParallelRunner_DefaultParallelRunner(int)_degreeOfParallelism'></a>
`degreeOfParallelism` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of concurrent [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') used to update an [IParallelRunnable](IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') in parallel.
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[degreeOfParallelism](DefaultParallelRunner_DefaultParallelRunner(int).md#DefaultEcs_Threading_DefaultParallelRunner_DefaultParallelRunner(int)_degreeOfParallelism 'DefaultEcs.Threading.DefaultParallelRunner.DefaultParallelRunner(int).degreeOfParallelism') cannot be inferior to one.
