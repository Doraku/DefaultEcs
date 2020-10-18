#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## IPublisher Interface
Exposes methods to subscribe to [MessageHandler&lt;T&gt;(T)](./DefaultEcs-MessageHandler-T-(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') and publish message to callback those subscriptions.  
```csharp
public interface IPublisher :
System.IDisposable
```
Derived  
&#8627; [World](./DefaultEcs-World.md 'DefaultEcs.World')  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Methods
- [Publish&lt;T&gt;(T)](./DefaultEcs-IPublisher-Publish-T-(T).md 'DefaultEcs.IPublisher.Publish&lt;T&gt;(T)')
- [Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)](./DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-MessageHandler-T-).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)')
