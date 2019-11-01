#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type) Method
Subscribes automatically methods of a Type marked with the [SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
```C#
public static System.IDisposable Subscribe(this DefaultEcs.IPublisher publisher, System.Type type);
```
#### Parameters
<a name='DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher_System-Type)-publisher'></a>
publisher [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher')  
The [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
<a name='DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher_System-Type)-type'></a>
type [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The type.  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](#DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher_System-Type)-publisher 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).publisher') or [type](#DefaultEcs-IPublisherExtension-Subscribe(DefaultEcs-IPublisher_System-Type)-type 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type).type') is null.  
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.  
