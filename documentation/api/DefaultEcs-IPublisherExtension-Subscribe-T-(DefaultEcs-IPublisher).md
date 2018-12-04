### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## Subscribe&lt;T&gt;(DefaultEcs.IPublisher) `method`
Subscribes automatically methods of a Type marked with the [DefaultEcs.SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [DefaultEcs.IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.
### Type parameters

<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-T'></a>
`T`
>The Type.
### Parameters

<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-publisher'></a>
`publisher`
>The [DefaultEcs.IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.
### Returns
>A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[publisher](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-publisher 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher).publisher') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')
>[DefaultEcs.SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.
