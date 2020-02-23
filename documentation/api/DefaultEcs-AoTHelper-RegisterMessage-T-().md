#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[AoTHelper](./DefaultEcs-AoTHelper.md 'DefaultEcs.AoTHelper')
## AoTHelper.RegisterMessage&lt;T&gt;() Method
Registers the type [T](#DefaultEcs-AoTHelper-RegisterMessage-T-()-T 'DefaultEcs.AoTHelper.RegisterMessage&lt;T&gt;().T') so [SubscribeAttribute](./DefaultEcs-SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') can freely be used on method like the delegate [MessageHandler&lt;T&gt;(T)](./DefaultEcs-MessageHandler-T-(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to automatically subscribe when using [IPublisherExtension](./DefaultEcs-IPublisherExtension.md 'DefaultEcs.IPublisherExtension') on a [World](./DefaultEcs-World.md 'DefaultEcs.World') instance.  
```csharp
public static void RegisterMessage<T>();
```
#### Type parameters
<a name='DefaultEcs-AoTHelper-RegisterMessage-T-()-T'></a>
`T`  
The type of message.  
  
