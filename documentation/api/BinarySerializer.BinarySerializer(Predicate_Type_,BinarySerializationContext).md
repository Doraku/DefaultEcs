#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')

## BinarySerializer(Predicate<Type>, BinarySerializationContext) Constructor

Initializes a new instance of the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.

```csharp
public BinarySerializer(System.Predicate<System.Type> componentFilter, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Parameters

<a name='DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate_System.Type_,DefaultEcs.Serialization.BinarySerializationContext).componentFilter'></a>

`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')

A filter used to check wether a component type should be serialized/deserialized or not. A [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') value means everything is taken.

<a name='DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate_System.Type_,DefaultEcs.Serialization.BinarySerializationContext).context'></a>

`context` [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')

The [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during serialization/deserialization.