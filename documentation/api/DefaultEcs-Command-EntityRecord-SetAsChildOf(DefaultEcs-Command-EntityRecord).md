#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## SetAsChildOf(DefaultEcs.Command.EntityRecord) `method`
Makes it so when given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.
### Parameters

<a name='DefaultEcs-Command-EntityRecord-SetAsChildOf(DefaultEcs-Command-EntityRecord)-parent'></a>
`parent`

The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') which acts as parent.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Command buffer is full.
