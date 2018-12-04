### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T- 'DefaultEcs.System.SystemRunner&lt;T&gt;')
## #ctor(System.Int32) `constructor`
Initialises a new instance of the [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T- 'DefaultEcs.System.SystemRunner&lt;T&gt;') class.
### Parameters

<a name='DefaultEcs-System-SystemRunner-T---ctor(System-Int32)-degreeOfParallelism'></a>
`degreeOfParallelism`

The number of [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task') instances used to update a system in parallel.
### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')

[degreeOfParallelism](#DefaultEcs-System-SystemRunner-T---ctor(System-Int32)-degreeOfParallelism 'DefaultEcs.System.SystemRunner&lt;T&gt;.#ctor(System.Int32).degreeOfParallelism') cannot be inferior to one.
