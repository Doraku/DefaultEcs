#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## AoTHelper Class
Provides a set of methods to help the generation of generic code for AoT compilation.  
```csharp
public static class AoTHelper
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AoTHelper  
### Methods

***
[RegisterComponent&lt;T&gt;()](AoTHelper_RegisterComponent_T_().md 'DefaultEcs.AoTHelper.RegisterComponent&lt;T&gt;()')

Registers the type [T](AoTHelper_RegisterComponent_T_().md#DefaultEcs_AoTHelper_RegisterComponent_T_()_T 'DefaultEcs.AoTHelper.RegisterComponent&lt;T&gt;().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').  

***
[RegisterMessage&lt;T&gt;()](AoTHelper_RegisterMessage_T_().md 'DefaultEcs.AoTHelper.RegisterMessage&lt;T&gt;()')

Registers the type [T](AoTHelper_RegisterMessage_T_().md#DefaultEcs_AoTHelper_RegisterMessage_T_()_T 'DefaultEcs.AoTHelper.RegisterMessage&lt;T&gt;().T') so [SubscribeAttribute](SubscribeAttribute.md 'DefaultEcs.SubscribeAttribute') can freely be used on method like the delegate [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to automatically subscribe when using [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension') on a [World](World.md 'DefaultEcs.World') instance.  

***
[RegisterUnmanagedComponent&lt;T&gt;()](AoTHelper_RegisterUnmanagedComponent_T_().md 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent&lt;T&gt;()')

Registers the unmanaged type [T](AoTHelper_RegisterUnmanagedComponent_T_().md#DefaultEcs_AoTHelper_RegisterUnmanagedComponent_T_()_T 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent&lt;T&gt;().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') and by [Set&lt;T&gt;(T)](EntityRecord_Set_T_(T).md 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T)').  
