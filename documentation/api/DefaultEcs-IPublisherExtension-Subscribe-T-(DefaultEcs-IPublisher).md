#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher) Method
Subscribes automatically methods of a Type marked with the [SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
```C#
public static System.IDisposable Subscribe<T>(this DefaultEcs.IPublisher publisher);
```
#### Type parameters
<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-T'></a>
`T`  
The Type.  
  
#### Parameters
<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-publisher'></a>
`publisher` [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher')  
The [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher)-publisher 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher).publisher') is null.  
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.  
