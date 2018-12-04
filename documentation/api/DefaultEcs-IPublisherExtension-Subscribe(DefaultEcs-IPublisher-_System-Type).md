### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## Subscribe(DefaultEcs.IPublisher, System.Type) `method`
Subscribes automatically methods of a Type marked with the [DefaultEcs.SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [DefaultEcs.IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.
### Parameters

<a name='DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher-_System-Type)-publisher'></a>
`publisher`
>The [DefaultEcs.IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.

<a name='DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher-_System-Type)-type'></a>
`type`
>The type.
### Returns
>A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[publisher](#DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher-_System-Type)-publisher 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).publisher') or [type](#DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher-_System-Type)-type 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).type') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')
>[DefaultEcs.SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.
