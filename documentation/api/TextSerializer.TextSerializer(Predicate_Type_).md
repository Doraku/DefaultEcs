#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')

## TextSerializer(Predicate<Type>) Constructor

Initializes a new instance of the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.

```csharp
public TextSerializer(System.Predicate<System.Type> componentFilter);
```
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate_System.Type_).componentFilter'></a>

`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

A filter used to check wether a component type should be serialized/deserialized or not. A [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') value means everything is taken.