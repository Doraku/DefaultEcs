#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.BinarySerializationContext) Constructor
Initializes a new instance of the [BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  
```csharp
public BinarySerializer(System.Predicate<System.Type> componentFilter, DefaultEcs.Serialization.BinarySerializationContext context);
```
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-BinarySerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-BinarySerializationContext)-componentFilter'></a>
`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')  
A filter used to check wether a component type should be serialized/deserialized or not. A https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null value means everything is taken.  
  
<a name='DefaultEcs-Serialization-BinarySerializer-BinarySerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-BinarySerializationContext)-context'></a>
`context` [BinarySerializationContext](./DefaultEcs-Serialization-BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')  
The [BinarySerializationContext](./DefaultEcs-Serialization-BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') used to convert type during serialization/deserialization.  
  
