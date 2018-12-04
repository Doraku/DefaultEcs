### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World')
## SetMaximumComponentCount&lt;T&gt;(System.Int32) `method`
>Sets up the current [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') to handle component of type [T](#DefaultEcs-World-SetMaximumComponentCount-T-(System-Int32)-T 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(System.Int32).T') with a different maximum count than [DefaultEcs.World.MaxEntityCount](./DefaultEcs-World-MaxEntityCount.md 'DefaultEcs.World.MaxEntityCount').<br/>If the type of component is already handled by the current [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World'), does nothing.
### Type parameters

<a name='DefaultEcs-World-SetMaximumComponentCount-T-(System-Int32)-T'></a>
`T`
>The type of component.
### Parameters

<a name='DefaultEcs-World-SetMaximumComponentCount-T-(System-Int32)-maxComponentCount'></a>
`maxComponentCount`
>The maximum number of component of type [T](#DefaultEcs-World-SetMaximumComponentCount-T-(System-Int32)-T 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(System.Int32).T') that can exist in this [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').
### Returns
>Whether the maximum count has been setted or not.
### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')
>[maxComponentCount](#DefaultEcs-World-SetMaximumComponentCount-T-(System-Int32)-maxComponentCount 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(System.Int32).maxComponentCount') cannot be negative.
