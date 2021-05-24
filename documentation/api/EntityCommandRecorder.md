#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command')
## EntityCommandRecorder Class
Represents a buffer of structural modifications to apply on [Entity](Entity.md 'DefaultEcs.Entity') to record as postoned commands.  
```csharp
public sealed class EntityCommandRecorder :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityCommandRecorder  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [EntityCommandRecorder()](EntityCommandRecorder_EntityCommandRecorder().md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder()') | Creates a default sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') of 1ko which can grow as needed.<br/> |
| [EntityCommandRecorder(int)](EntityCommandRecorder_EntityCommandRecorder(int).md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int)') | Creates a fixed sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').<br/> |
| [EntityCommandRecorder(int, int)](EntityCommandRecorder_EntityCommandRecorder(int_int).md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int)') | Creates an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') with a custom default size which can grow to a maximum capacity.<br/> |

| Properties | |
| :--- | :--- |
| [Capacity](EntityCommandRecorder_Capacity.md 'DefaultEcs.Command.EntityCommandRecorder.Capacity') | Gets current capacity of the current instance.<br/> |
| [MaxCapacity](EntityCommandRecorder_MaxCapacity.md 'DefaultEcs.Command.EntityCommandRecorder.MaxCapacity') | Gets the maximum capacity the current instance can grow to.<br/> |
| [Size](EntityCommandRecorder_Size.md 'DefaultEcs.Command.EntityCommandRecorder.Size') | Gets the size taken by recorded commands in current instance.<br/> |

| Methods | |
| :--- | :--- |
| [Clear()](EntityCommandRecorder_Clear().md 'DefaultEcs.Command.EntityCommandRecorder.Clear()') | Clears all recorded commands.<br/> |
| [CreateEntity(World)](EntityCommandRecorder_CreateEntity(World).md 'DefaultEcs.Command.EntityCommandRecorder.CreateEntity(DefaultEcs.World)') | Records the creation of an [Entity](Entity.md 'DefaultEcs.Entity') on a [World](World.md 'DefaultEcs.World') and returns an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.<br/>This command takes 9 bytes.<br/> |
| [Dispose()](EntityCommandRecorder_Dispose().md 'DefaultEcs.Command.EntityCommandRecorder.Dispose()') | Releases inner unmanaged resources.<br/> |
| [Execute()](EntityCommandRecorder_Execute().md 'DefaultEcs.Command.EntityCommandRecorder.Execute()') | Executes all recorded commands and clears those commands.<br/> |
| [Record(Entity)](EntityCommandRecorder_Record(Entity).md 'DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.Entity)') | Gives an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on the given [Entity](Entity.md 'DefaultEcs.Entity').<br/>This command takes 9 bytes.<br/> |
