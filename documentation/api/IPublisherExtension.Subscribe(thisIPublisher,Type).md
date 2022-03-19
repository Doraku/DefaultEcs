#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')

## IPublisherExtension.Subscribe(this IPublisher, Type) Method

Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

```csharp
public static System.IDisposable Subscribe(this DefaultEcs.IPublisher publisher, System.Type type);
```
#### Parameters

<a name='DefaultEcs.IPublisherExtension.Subscribe(thisDefaultEcs.IPublisher,System.Type).publisher'></a>

`publisher` [IPublisher](IPublisher.md 'DefaultEcs.IPublisher')

The [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

<a name='DefaultEcs.IPublisherExtension.Subscribe(thisDefaultEcs.IPublisher,System.Type).type'></a>

`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

The type.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](IPublisherExtension.Subscribe(thisIPublisher,Type).md#DefaultEcs.IPublisherExtension.Subscribe(thisDefaultEcs.IPublisher,System.Type).publisher 'DefaultEcs.IPublisherExtension.Subscribe(this DefaultEcs.IPublisher, System.Type).publisher') or [type](IPublisherExtension.Subscribe(thisIPublisher,Type).md#DefaultEcs.IPublisherExtension.Subscribe(thisDefaultEcs.IPublisher,System.Type).type 'DefaultEcs.IPublisherExtension.Subscribe(this DefaultEcs.IPublisher, System.Type).type') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.