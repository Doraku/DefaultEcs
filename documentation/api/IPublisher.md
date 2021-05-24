#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## IPublisher Interface
Exposes methods to subscribe to [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') and publish message to callback those subscriptions.  
```csharp
public interface IPublisher :
System.IDisposable
```

Derived  
&#8627; [World](World.md 'DefaultEcs.World')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Methods | |
| :--- | :--- |
| [Publish&lt;T&gt;(T)](IPublisher_Publish_T_(T).md 'DefaultEcs.IPublisher.Publish&lt;T&gt;(T)') | Publishes a [T](IPublisher_Publish_T_(T).md#DefaultEcs_IPublisher_Publish_T_(T)_T 'DefaultEcs.IPublisher.Publish&lt;T&gt;(T).T') object.<br/> |
| [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher_Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)') | Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to be called back when a [T](IPublisher_Subscribe_T_(MessageHandler_T_).md#DefaultEcs_IPublisher_Subscribe_T_(DefaultEcs_MessageHandler_T_)_T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T') object is published.<br/> |
