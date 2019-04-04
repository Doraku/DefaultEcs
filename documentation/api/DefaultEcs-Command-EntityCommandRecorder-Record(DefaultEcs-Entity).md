#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## Record(DefaultEcs.Entity) `method`
Gives an [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
This command takes 9 bytes.
### Parameters

<a name='DefaultEcs-Command-EntityCommandRecorder-Record(DefaultEcs-Entity)-entity'></a>
`entity`

The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record action on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
### Returns
The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Command buffer is full.
