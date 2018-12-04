### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World')
## Subscribe&lt;T&gt;(DefaultEcs.SubscribeAction&lt;T&gt;) `method`
Subscribes an [DefaultEcs.SubscribeAction&lt;T&gt;](./DefaultEcs-SubscribeAction-T-.md 'DefaultEcs.SubscribeAction&lt;T&gt;') to be called back when a [T](#DefaultEcs-World-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.SubscribeAction&lt;T&gt;).T') object is published.
### Type parameters

<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-T'></a>
`T`

The type of the object to be called back with.
### Parameters

<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-action'></a>
`action`

The delegate to be called back.
### Returns
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
