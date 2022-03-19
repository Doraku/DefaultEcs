#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## AoTHelper Class

Provides a set of methods to help the generation of generic code for AoT compilation.

```csharp
public static class AoTHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AoTHelper

| Methods | |
| :--- | :--- |
| [RegisterComponent&lt;T&gt;()](AoTHelper.RegisterComponent_T_().md 'DefaultEcs.AoTHelper.RegisterComponent<T>()') | Registers the type [T](AoTHelper.RegisterComponent_T_().md#DefaultEcs.AoTHelper.RegisterComponent_T_().T 'DefaultEcs.AoTHelper.RegisterComponent<T>().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute'). |
| [RegisterMessage&lt;T&gt;()](AoTHelper.RegisterMessage_T_().md 'DefaultEcs.AoTHelper.RegisterMessage<T>()') | Registers the type [T](AoTHelper.RegisterMessage_T_().md#DefaultEcs.AoTHelper.RegisterMessage_T_().T 'DefaultEcs.AoTHelper.RegisterMessage<T>().T') so [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') can freely be used on method like the delegate [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)') to automatically subscribe when using [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension') on a [World](World.md 'DefaultEcs.World') instance. |
| [RegisterUnmanagedComponent&lt;T&gt;()](AoTHelper.RegisterUnmanagedComponent_T_().md 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent<T>()') | Registers the unmanaged type [T](AoTHelper.RegisterUnmanagedComponent_T_().md#DefaultEcs.AoTHelper.RegisterUnmanagedComponent_T_().T 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent<T>().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') and by [Set&lt;T&gt;(T)](EntityRecord.Set_T_(T).md 'DefaultEcs.Command.EntityRecord.Set<T>(T)'). |
