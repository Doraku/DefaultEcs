#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Threading](./DefaultEcs-Threading.md 'DefaultEcs.Threading').[DefaultParallelRunner](./DefaultEcs-Threading-DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner')
## DefaultParallelRunner(int) Constructor
Initialises a new instance of the [DefaultParallelRunner](./DefaultEcs-Threading-DefaultParallelRunner.md 'DefaultEcs.Threading.DefaultParallelRunner') class.  
```C#
public DefaultParallelRunner(int degreeOfParallelism);
```
#### Parameters
<a name='DefaultEcs-Threading-DefaultParallelRunner-DefaultParallelRunner(int)-degreeOfParallelism'></a>
`degreeOfParallelism` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of concurrent [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') used to update an [IParallelRunnable](./DefaultEcs-Threading-IParallelRunnable.md 'DefaultEcs.Threading.IParallelRunnable') in parallel.  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[degreeOfParallelism](#DefaultEcs-Threading-DefaultParallelRunner-DefaultParallelRunner(int)-degreeOfParallelism 'DefaultEcs.Threading.DefaultParallelRunner.DefaultParallelRunner(int).degreeOfParallelism') cannot be inferior to one.  
