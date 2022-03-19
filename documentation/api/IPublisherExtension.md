#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## IPublisherExtension Class

Provides set of static methods to automatically subscribe [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') methods marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on a [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance.

```csharp
public static class IPublisherExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; IPublisherExtension

| Methods | |
| :--- | :--- |
| [Subscribe(this IPublisher, Type)](IPublisherExtension.Subscribe(thisIPublisher,Type).md 'DefaultEcs.IPublisherExtension.Subscribe(this DefaultEcs.IPublisher, System.Type)') | Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance. |
| [Subscribe&lt;T&gt;(this IPublisher)](IPublisherExtension.Subscribe_T_(thisIPublisher).md 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher)') | Subscribes automatically methods of a Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance. |
| [Subscribe&lt;T&gt;(this IPublisher, T)](IPublisherExtension.Subscribe_T_(thisIPublisher,T).md 'DefaultEcs.IPublisherExtension.Subscribe<T>(this DefaultEcs.IPublisher, T)') | Subscribes automatically methods of an instance and its Type marked with the [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') on an [IPublisher](IPublisher.md 'DefaultEcs.IPublisher') instance. |
