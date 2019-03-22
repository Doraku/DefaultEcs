#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## Subscribe&lt;T&gt;(DefaultEcs.InAction&lt;T&gt;) `method`
Subscribes an [InAction&lt;T&gt;](./DefaultEcs-InAction-T-.md 'DefaultEcs.InAction&lt;T&gt;') to be called back when a [T](#DefaultEcs-World-Subscribe-T-(DefaultEcs-InAction-T-)-T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.InAction&lt;T&gt;).T') object is published.
### Type parameters

<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-InAction-T-)-T'></a>
`T`

The type of the object to be called back with.
### Parameters

<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-InAction-T-)-action'></a>
`action`

The delegate to be called back.
### Returns
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
