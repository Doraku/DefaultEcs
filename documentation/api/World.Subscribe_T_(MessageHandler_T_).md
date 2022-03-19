#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Subscribe<T>(MessageHandler<T>) Method

Subscribes an [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') to be called back when a [T](World.Subscribe_T_(MessageHandler_T_).md#DefaultEcs.World.Subscribe_T_(DefaultEcs.MessageHandler_T_).T 'DefaultEcs.World.Subscribe<T>(DefaultEcs.MessageHandler<T>).T') object is published.

```csharp
public System.IDisposable Subscribe<T>(DefaultEcs.MessageHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.Subscribe_T_(DefaultEcs.MessageHandler_T_).T'></a>

`T`

The type of the object to be called back with.
#### Parameters

<a name='DefaultEcs.World.Subscribe_T_(DefaultEcs.MessageHandler_T_).action'></a>

`action` [DefaultEcs.MessageHandler&lt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)')[T](World.Subscribe_T_(MessageHandler_T_).md#DefaultEcs.World.Subscribe_T_(DefaultEcs.MessageHandler_T_).T 'DefaultEcs.World.Subscribe<T>(DefaultEcs.MessageHandler<T>).T')[&gt;](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)')

The delegate to be called back.

Implements [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher.Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>)')

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.