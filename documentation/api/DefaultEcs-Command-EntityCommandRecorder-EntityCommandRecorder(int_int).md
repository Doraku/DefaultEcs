#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder(int, int) Constructor
Creates an [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') with a custom default size which can grow to a maximum capacity.  
```C#
public EntityCommandRecorder(int capacity, int maxCapacity);
```
#### Parameters
<a name='DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The default size of the [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
  
<a name='DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum capacity of the [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[capacity](#DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-capacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).capacity') cannot be negative.  
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](#DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).maxCapacity') cannot be negative.  
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](#DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).maxCapacity') is inferior to [capacity](#DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int_int)-capacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).capacity').  
