#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')

## EntityCommandRecorder(int) Constructor

Creates a fixed sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

```csharp
public EntityCommandRecorder(int maxCapacity);
```
#### Parameters

<a name='DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int).maxCapacity'></a>

`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The size of the [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](EntityCommandRecorder.EntityCommandRecorder(int).md#DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int).maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int).maxCapacity') cannot be negative.