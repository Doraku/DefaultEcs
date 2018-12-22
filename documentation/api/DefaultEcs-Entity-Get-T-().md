#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Get&lt;T&gt;() `method`
Gets the component of type [T](#DefaultEcs-Entity-Get-T-()-T 'DefaultEcs.Entity.Get&lt;T&gt;().T') on the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
### Type parameters

<a name='DefaultEcs-Entity-Get-T-()-T'></a>
`T`
The type of the component.
### Returns
A reference to the component.
### Exceptions

[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World') or does not have a component of type [T](#DefaultEcs-Entity-Get-T-()-T 'DefaultEcs.Entity.Get&lt;T&gt;().T').
