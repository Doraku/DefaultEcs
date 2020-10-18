#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension')
## IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T) Method
Subscribes automatically methods of an instance and its Type marked with the [SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
```csharp
public static System.IDisposable Subscribe<T>(this DefaultEcs.IPublisher publisher, T target)
    where T : class;
```
#### Type parameters
<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-T'></a>
`T`  
The Type.  
  
#### Parameters
<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-publisher'></a>
`publisher` [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher')  
The [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher') instance.  
  
<a name='DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-target'></a>
`target` [T](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-T 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T).T')  
The instance.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
A [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') to unregister.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[publisher](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-publisher 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T).publisher') or [target](#DefaultEcs-IPublisherExtension-Subscribe-T-(DefaultEcs-IPublisher_T)-target 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T).target') is null.  
[System.NotSupportedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotSupportedException 'System.NotSupportedException')  
[SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') is used on an uncompatible method of the instance.  
