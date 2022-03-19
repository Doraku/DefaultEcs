#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command')

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
| [EntityCommandRecorder()](EntityCommandRecorder.EntityCommandRecorder().md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder()') | Creates a default sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') of 1ko which can grow as needed. |
| [EntityCommandRecorder(int)](EntityCommandRecorder.EntityCommandRecorder(int).md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int)') | Creates a fixed sized [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder'). |
| [EntityCommandRecorder(int, int)](EntityCommandRecorder.EntityCommandRecorder(int,int).md 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int, int)') | Creates an [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder') with a custom default size which can grow to a maximum capacity. |

| Properties | |
| :--- | :--- |
| [Capacity](EntityCommandRecorder.Capacity.md 'DefaultEcs.Command.EntityCommandRecorder.Capacity') | Gets current capacity of the current instance. |
| [MaxCapacity](EntityCommandRecorder.MaxCapacity.md 'DefaultEcs.Command.EntityCommandRecorder.MaxCapacity') | Gets the maximum capacity the current instance can grow to. |
| [Size](EntityCommandRecorder.Size.md 'DefaultEcs.Command.EntityCommandRecorder.Size') | Gets the size taken by recorded commands in current instance. |

| Methods | |
| :--- | :--- |
| [Clear()](EntityCommandRecorder.Clear().md 'DefaultEcs.Command.EntityCommandRecorder.Clear()') | Clears all recorded commands. |
| [Dispose()](EntityCommandRecorder.Dispose().md 'DefaultEcs.Command.EntityCommandRecorder.Dispose()') | Releases inner unmanaged resources. |
| [Execute()](EntityCommandRecorder.Execute().md 'DefaultEcs.Command.EntityCommandRecorder.Execute()') | Executes all recorded commands and clears those commands. |
| [Record(Entity)](EntityCommandRecorder.Record(Entity).md 'DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.Entity)') | Gives an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on the given [Entity](Entity.md 'DefaultEcs.Entity').<br/>This command takes 9 bytes. |
| [Record(World)](EntityCommandRecorder.Record(World).md 'DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.World)') | Gives an [WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord') to record action on the given [World](World.md 'DefaultEcs.World'). |
