#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[IPublisher](IPublisher.md 'DefaultEcs.IPublisher')

## IPublisher.Subscribe<T>(MessageHandler<T>) Method

Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') to be called back when a [T](IPublisher.Subscribe_T_(MessageHandler_T_).md#DefaultEcs.IPublisher.Subscribe_T_(DefaultEcs.MessageHandler_T_).T 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>).T') object is published.

```csharp
System.IDisposable Subscribe<T>(DefaultEcs.MessageHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.IPublisher.Subscribe_T_(DefaultEcs.MessageHandler_T_).T'></a>

`T`

The type of the object to be called back with.
#### Parameters

<a name='DefaultEcs.IPublisher.Subscribe_T_(DefaultEcs.MessageHandler_T_).action'></a>

`action` [DefaultEcs.MessageHandler&lt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)')[T](IPublisher.Subscribe_T_(MessageHandler_T_).md#DefaultEcs.IPublisher.Subscribe_T_(DefaultEcs.MessageHandler_T_).T 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>).T')[&gt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)')

The delegate to be called back.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.