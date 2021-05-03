#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## IPublisherExtension Class
Provides set of static methods to automatically subscribe [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') methods marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on a [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  
```csharp
public static class IPublisherExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IPublisherExtension  
### Methods

***
[Subscribe&lt;T&gt;(IPublisher)](IPublisherExtension_Subscribe_T_(IPublisher).md 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher)')

Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  

***
[Subscribe&lt;T&gt;(IPublisher, T)](IPublisherExtension_Subscribe_T_(IPublisher_T).md 'DefaultEcs.IPublisherExtension.Subscribe&lt;T&gt;(DefaultEcs.IPublisher, T)')

Subscribes automatically methods of an instance and its Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  

***
[Subscribe(IPublisher, Type)](IPublisherExtension_Subscribe(IPublisher_Type).md 'DefaultEcs.IPublisherExtension.Subscribe(DefaultEcs.IPublisher, System.Type)')

Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.  
