#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer(System.Predicate&lt;System.Type&gt;) Constructor
Initializes a new instance of the [BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') class.  
```csharp
public BinarySerializer(System.Predicate<System.Type> componentFilter);
```
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-BinarySerializer(System-Predicate-System-Type-)-componentFilter'></a>
`componentFilter` [System.Predicate&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')[System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1')  
A filter used to check wether a component type should be serialized/deserialized or not. A https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null value means everything is taken.  
  
