#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## SubscribeAttribute Class

Specifies that the method should be automatically subscribed when its parent type or instance is called with [IPublisherExtension](IPublisherExtension.md 'DefaultEcs.IPublisherExtension').  
The decorated method should be of the type [MessageHandler&lt;T&gt;(T)](MessageHandler_T_(T).md 'DefaultEcs.MessageHandler<T>(T)').

```csharp
public sealed class SubscribeAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; SubscribeAttribute