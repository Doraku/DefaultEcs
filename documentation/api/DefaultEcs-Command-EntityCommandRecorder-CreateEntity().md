#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## CreateEntity() `method`
Records the creation of an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') and returns an [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.
This command takes 9 bytes.
### Returns
The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the later created [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Command buffer is full.
