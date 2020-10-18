#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization')
## BinarySerializer Class
Provides a basic implementation of the [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a binary format.  
```csharp
public sealed class BinarySerializer :
DefaultEcs.Serialization.ISerializer
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializer  

Implements [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
### Constructors
- [BinarySerializer()](./DefaultEcs-Serialization-BinarySerializer-BinarySerializer().md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer()')
- [BinarySerializer(DefaultEcs.Serialization.BinarySerializationContext)](./DefaultEcs-Serialization-BinarySerializer-BinarySerializer(DefaultEcs-Serialization-BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(DefaultEcs.Serialization.BinarySerializationContext)')
- [BinarySerializer(System.Predicate&lt;System.Type&gt;)](./DefaultEcs-Serialization-BinarySerializer-BinarySerializer(System-Predicate-System-Type-).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate&lt;System.Type&gt;)')
- [BinarySerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.BinarySerializationContext)](./DefaultEcs-Serialization-BinarySerializer-BinarySerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.BinarySerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.BinarySerializationContext)')
### Methods
- [Deserialize(System.IO.Stream)](./DefaultEcs-Serialization-BinarySerializer-Deserialize(System-IO-Stream).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream)')
- [Deserialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-BinarySerializer-Deserialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.BinarySerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')
- [Read&lt;T&gt;(System.IO.Stream)](./DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream).md 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream)')
- [Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext)](./DefaultEcs-Serialization-BinarySerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.BinarySerializationContext)')
- [Serialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World)')
- [Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-).md 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')
- [Write&lt;T&gt;(System.IO.Stream, T)](./DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T).md 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T)')
- [Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext)](./DefaultEcs-Serialization-BinarySerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-BinarySerializationContext).md 'DefaultEcs.Serialization.BinarySerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.BinarySerializationContext)')
