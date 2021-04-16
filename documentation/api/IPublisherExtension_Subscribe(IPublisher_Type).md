#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## IPublisherExtension.Subscribe(IPublisher, Type) Method
Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  
```csharp
public static System.IDisposable Subscribe(this DefaultEcs.IPublisher publisher, System.Type type);
```
#### Parameters
<a name='DefaultEcs_IPublisherExtension_Subscribe(DefaultEcs_IPublisher_System_Type)_publisher'></a>
`publisher` [IPublisher](IPublisher.md 'DefaultEcs.IPublisher')  
The [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.
  
<a name='DefaultEcs_IPublisherExtension_Subscribe(DefaultEcs_IPublisher_System_Type)_type'></a>
`type` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The type.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](IPublisherExtension_Subscribe(IPublisher_Type).md#DefaultEcs_IPublisherExtension_Subscribe(DefaultEcs_IPublisher_System_Type)_publisher 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).publisher') or [type](IPublisherExtension_Subscribe(IPublisher_Type).md#DefaultEcs_IPublisherExtension_Subscribe(DefaultEcs_IPublisher_System_Type)_type 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).type') is null.
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.
