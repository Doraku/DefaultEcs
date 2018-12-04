### [DefaultEcs](./DefaultEcs 'DefaultEcs')
### [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity')
## SetSameAs&lt;T&gt;(DefaultEcs.Entity) `method`
Sets the value of the component of type [T](./DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)#T 'T') on the current Entity to the same instance of an other [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity').
### Type parameters

<a name='DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-T'></a>
`T`

The type of the component.
### Parameters

<a name='DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-reference'></a>
`reference`

The other [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') used as reference.
### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

[DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') was not created from a [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Reference [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') comes from a different [DefaultEcs.World](./DefaultEcs-World 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')

Reference [DefaultEcs.Entity](./DefaultEcs-Entity 'DefaultEcs.Entity') does not have a component of type [T](./DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)#T 'T').
