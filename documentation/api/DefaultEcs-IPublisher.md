#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## IPublisher Interface
Exposes methods to subscribe to [ActionIn&lt;T&gt;(T)](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)') and publish message to callback those subscriptions.  
```C#
public interface IPublisher :
IDisposable
```
Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Methods
- [Publish&lt;T&gt;(T)](./DefaultEcs-IPublisher-Publish-T-(T).md 'DefaultEcs.IPublisher.Publish&lt;T&gt;(T)')
- [Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)](./DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-ActionIn-T-).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)')
