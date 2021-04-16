#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder.EntityCommandRecorder(int, int) Constructor
Creates an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') with a custom default size which can grow to a maximum capacity.  
```csharp
public EntityCommandRecorder(int capacity, int maxCapacity);
```
#### Parameters
<a name='DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The default size of the [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').
  
<a name='DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum capacity of the [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[capacity](EntityCommandRecorder_EntityCommandRecorder(int_int).md#DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_capacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).capacity') cannot be negative.
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](EntityCommandRecorder_EntityCommandRecorder(int_int).md#DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).maxCapacity') cannot be negative.
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](EntityCommandRecorder_EntityCommandRecorder(int_int).md#DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).maxCapacity') is inferior to [capacity](EntityCommandRecorder_EntityCommandRecorder(int_int).md#DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int_int)_capacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int).capacity').
