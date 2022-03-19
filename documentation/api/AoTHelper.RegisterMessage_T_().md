#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper')

## AoTHelper.RegisterMessage<T>() Method

Registers the type [T](AoTHelper.RegisterMessage_T_().md#DefaultEcs.AoTHelper.RegisterMessage_T_().T 'DefaultEcs.AoTHelper.RegisterMessage<T>().T') so [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') can freely be used on method like the delegate [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') to automatically subscribe when using [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension') on a [World](World.md 'DefaultEcs.World') instance.

```csharp
public static void RegisterMessage<T>();
```
#### Type parameters

<a name='DefaultEcs.AoTHelper.RegisterMessage_T_().T'></a>

`T`

The type of message.