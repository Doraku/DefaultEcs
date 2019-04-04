#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](./DefaultEcs.md#DefaultEcs-Command 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## Disable&lt;T&gt;() `method`
Disables the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') component of type [T](#DefaultEcs-Command-EntityRecord-Disable-T-()-T 'DefaultEcs.Command.EntityRecord.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').
This command takes 9 bytes.
### Type parameters

<a name='DefaultEcs-Command-EntityRecord-Disable-T-()-T'></a>
`T`

The type of the component.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Command buffer is full.
