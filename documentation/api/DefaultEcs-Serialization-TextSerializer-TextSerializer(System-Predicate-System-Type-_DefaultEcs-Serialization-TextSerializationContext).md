#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.TextSerializationContext) Constructor
Initializes a new instance of the [TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') class.  
```csharp
public TextSerializer(System.Predicate<System.Type> componentFilter, DefaultEcs.Serialization.TextSerializationContext context);
```
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializer-TextSerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-TextSerializationContext)-componentFilter'></a>
`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')  
A filter used to check wether a component type should be serialized/deserialized or not. A https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null value means everything is taken.  
  
<a name='DefaultEcs-Serialization-TextSerializer-TextSerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-TextSerializationContext)-context'></a>
`context` [TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
The [TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') used to convert type during serialization/deserialization.  
  
