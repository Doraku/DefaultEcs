#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')

## IPublisherExtension.Subscribe<T>(this IPublisher, T) Method

Subscribes automatically methods of an instance and its Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

```csharp
public static System.IDisposable Subscribe<T>(this DefaultEcs.IPublisher publisher, T target)
    where T : class;
```
#### Type parameters

<a name='DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).T'></a>

`T`

The Type.
#### Parameters

<a name='DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).publisher'></a>

`publisher` [IPublisher](IPublisher.md 'DefaultEcs.IPublisher')

The [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

<a name='DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).target'></a>

`target` [T](IPublisherExtension.Subscribe_T_(thisIPublisher,T).md#DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).T 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher, T).T')

The instance.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](IPublisherExtension.Subscribe_T_(thisIPublisher,T).md#DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).publisher 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher, T).publisher') or [target](IPublisherExtension.Subscribe_T_(thisIPublisher,T).md#DefaultEcs.IPublisherExtension.Subscribe_T_(thisDefaultEcs.IPublisher,T).target 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher, T).target') is null.

[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.