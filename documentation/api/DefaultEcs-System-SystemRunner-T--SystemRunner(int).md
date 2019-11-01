#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;')
## SystemRunner(int) Constructor
Initialises a new instance of the [SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') class.  
```C#
public SystemRunner(int degreeOfParallelism);
```
#### Parameters
<a name='DefaultEcs-System-SystemRunner-T--SystemRunner(int)-degreeOfParallelism'></a>
`degreeOfParallelism` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The number of [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances used to update a system in parallel.  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[degreeOfParallelism](#DefaultEcs-System-SystemRunner-T--SystemRunner(int)-degreeOfParallelism 'DefaultEcs.System.SystemRunner&lt;T&gt;.SystemRunner(int).degreeOfParallelism') cannot be inferior to one.  
