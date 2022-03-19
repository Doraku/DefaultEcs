#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## IPublisher Interface

Exposes methods to subscribe to [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') and publish message to callback those subscriptions.

```csharp
public interface IPublisher :
System.IDisposable
```

Derived  
&#8627; [World](World.md 'DefaultEcs.World')

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Methods | |
| :--- | :--- |
| [Publish&lt;T&gt;(T)](IPublisher.Publish_T_(T).md 'DefaultEcs.IPublisher.Publish<T>(T)') | Publishes a [T](IPublisher.Publish_T_(T).md#DefaultEcs.IPublisher.Publish_T_(T).T 'DefaultEcs.IPublisher.Publish<T>(T).T') object. |
| [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher.Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>)') | Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') to be called back when a [T](IPublisher.Subscribe_T_(MessageHandler_T_).md#DefaultEcs.IPublisher.Subscribe_T_(DefaultEcs.MessageHandler_T_).T 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>).T') object is published. |
