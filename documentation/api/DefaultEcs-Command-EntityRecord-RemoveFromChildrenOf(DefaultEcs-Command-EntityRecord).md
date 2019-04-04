#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## RemoveFromChildrenOf(DefaultEcs.Command.EntityRecord) `method`
Remove the given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') from corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') parents.
### Parameters

<a name='DefaultEcs-Command-EntityRecord-RemoveFromChildrenOf(DefaultEcs-Command-EntityRecord)-parent'></a>
`parent`

The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as parent.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Command buffer is full.
