#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T) `method`
Subscribes automatically methods of an instance and its Type marked with the [SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.
### Type parameters

<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher-_T)-T'></a>
`T`

The Type.
### Parameters

<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher-_T)-publisher'></a>
`publisher`

The [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.

<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher-_T)-target'></a>
`target`

The instance.
### Returns
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')

[publisher](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher-_T)-publisher 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T).publisher') or [target](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher-_T)-target 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T).target') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')

[SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.
