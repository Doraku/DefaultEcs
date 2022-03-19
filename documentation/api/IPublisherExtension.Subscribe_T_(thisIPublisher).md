#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')

## IPublisherExtension.Subscribe<T>(this IPublisher) Method

Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

```csharp
public static System.IDisposable Subscribe<T>(this DefaultEcs.IPublisher publisher);
```
#### Type parameters

<a name='DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher).T'></a>

`T`

The Type.
#### Parameters

<a name='DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher).publisher'></a>

`publisher` [IPublisher](IPublisher.md 'DefaultEcs.IPublisher')

The [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](IPublisherExtension.Subscribe_T_(thisIPublisher).md#DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher).publisher 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher).publisher') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.