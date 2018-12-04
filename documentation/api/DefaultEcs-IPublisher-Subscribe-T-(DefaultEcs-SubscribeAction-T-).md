### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher')
## Subscribe&lt;T&gt;(DefaultEcs.SubscribeAction&lt;T&gt;) `method`
Subscribes an [DefaultEcs.SubscribeAction&lt;T&gt;](./DefaultEcs-SubscribeAction-T-.md 'DefaultEcs.SubscribeAction&lt;T&gt;') to be called back when a [T](#DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.SubscribeAction&lt;T&gt;).T') object is published.
### Type parameters

<a name='DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-T'></a>
`T`

The type of the object to be called back with.
### Parameters

<a name='DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-SubscribeAction-T-)-action'></a>
`action`

The delegate to be called back.
### Returns
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
