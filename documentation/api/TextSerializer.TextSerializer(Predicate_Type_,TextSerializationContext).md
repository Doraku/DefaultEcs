#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer(Predicate<Type>, TextSerializationContext) Constructor

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.

```csharp
public TextSerializer(System.Predicate<System.Type> componentFilter, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate_System.Type_,DefaultEcs.Serialization.TextSerializationContext).componentFilter'></a>

`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

A filter used to check wether a component type should be serialized/deserialized or not. A [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') value means everything is taken.

<a name='DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate_System.Type_,DefaultEcs.Serialization.TextSerializationContext).context'></a>

`context` [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')

The [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during serialization/deserialization.