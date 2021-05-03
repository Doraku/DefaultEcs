#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## IPublisherExtension.Subscribe&lt;T&gt;(IPublisher) Method
Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  
```csharp
public static System.IDisposable Subscribe<T>(this DefaultEcs.IPublisher publisher);
```
#### Type parameters
<a name='DefaultEcs_IPublisherExtension_Subscribe_T_(DefaultEcs_IPublisher)_T'></a>
`T`  
The Type.
  
#### Parameters
<a name='DefaultEcs_IPublisherExtension_Subscribe_T_(DefaultEcs_IPublisher)_publisher'></a>
`publisher` [IPublisher](IPublisher.md 'DefaultEcs.IPublisher')  
The [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](IPublisherExtension_Subscribe_T_(IPublisher).md#DefaultEcs_IPublisherExtension_Subscribe_T_(DefaultEcs_IPublisher)_publisher 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher).publisher') is null.
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.
