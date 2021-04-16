#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[IPublisher](IPublisher.md 'DefaultEcs.IPublisher')
## IPublisher.Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;) Method
Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to be called back when a [T](IPublisher_Subscribe_T_(MessageHandler_T_).md#DefaultEcs_IPublisher_Subscribe_T_(DefaultEcs_MessageHandler_T_)_T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T') object is published.  
```csharp
System.IDisposable Subscribe<T>(DefaultEcs.MessageHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_IPublisher_Subscribe_T_(DefaultEcs_MessageHandler_T_)_T'></a>
`T`  
The type of the object to be called back with.
  
#### Parameters
<a name='DefaultEcs_IPublisher_Subscribe_T_(DefaultEcs_MessageHandler_T_)_action'></a>
`action` [DefaultEcs.MessageHandler&lt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)')[T](IPublisher_Subscribe_T_(MessageHandler_T_).md#DefaultEcs_IPublisher_Subscribe_T_(DefaultEcs_MessageHandler_T_)_T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T')[&gt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)')  
The delegate to be called back.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
