#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder.EntityCommandRecorder(int) Constructor
Creates a fixed sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
```csharp
public EntityCommandRecorder(int maxCapacity);
```
#### Parameters
<a name='DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int)_maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The size of the [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](EntityCommandRecorder_EntityCommandRecorder(int).md#DefaultEcs_Command_EntityCommandRecorder_EntityCommandRecorder(int)_maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int).maxCapacity') cannot be negative.
