#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## MessageHandler<T>(T) Delegate

Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher.Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe<T>(DefaultEcs.MessageHandler<T>)') method.

```csharp
public delegate void MessageHandler<T>(in T message);
```
#### Type parameters

<a name='DefaultEcs.MessageHandler_T_(T).T'></a>

`T`

The type of the parameter of the method that this delegate encapsulates.
#### Parameters

<a name='DefaultEcs.MessageHandler_T_(T).message'></a>

`message` [T](MessageHandler_T_(T).md#DefaultEcs.MessageHandler_T_(T).T 'DefaultEcs.MessageHandler<T>(T).T')

The parameter of the method that this delegate encapsulates.