#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper')
## AoTHelper.RegisterMessage&lt;T&gt;() Method
Registers the type [T](AoTHelper_RegisterMessage_T_().md#DefaultEcs_AoTHelper_RegisterMessage_T_()_T 'DefaultEcs.AoTHelper.RegisterMessage&lt;T&gt;().T') so [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') can freely be used on method like the delegate [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to automatically subscribe when using [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension') on a [World](World.md 'DefaultEcs.World') instance.  
```csharp
public static void RegisterMessage<T>();
```
#### Type parameters
<a name='DefaultEcs_AoTHelper_RegisterMessage_T_()_T'></a>
`T`  
The type of message.
  
