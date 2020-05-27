#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization')
## TextSerializer Class
Provides a basic implementation of the [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer') interface using a text readable format.  
```csharp
public sealed class TextSerializer :
ISerializer
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextSerializer  

Implements [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')  
### Constructors
- [TextSerializer()](./DefaultEcs-Serialization-TextSerializer-TextSerializer().md 'DefaultEcs.Serialization.TextSerializer.TextSerializer()')
- [TextSerializer(DefaultEcs.Serialization.TextSerializationContext)](./DefaultEcs-Serialization-TextSerializer-TextSerializer(DefaultEcs-Serialization-TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(DefaultEcs.Serialization.TextSerializationContext)')
- [TextSerializer(System.Predicate&lt;System.Type&gt;)](./DefaultEcs-Serialization-TextSerializer-TextSerializer(System-Predicate-System-Type-).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate&lt;System.Type&gt;)')
- [TextSerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.TextSerializationContext)](./DefaultEcs-Serialization-TextSerializer-TextSerializer(System-Predicate-System-Type-_DefaultEcs-Serialization-TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.TextSerializer(System.Predicate&lt;System.Type&gt;, DefaultEcs.Serialization.TextSerializationContext)')
### Methods
- [Deserialize(System.IO.Stream)](./DefaultEcs-Serialization-TextSerializer-Deserialize(System-IO-Stream).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream)')
- [Deserialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-TextSerializer-Deserialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.TextSerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')
- [Read&lt;T&gt;(System.IO.Stream)](./DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream).md 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream)')
- [Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext)](./DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream_DefaultEcs-Serialization-TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream, DefaultEcs.Serialization.TextSerializationContext)')
- [Serialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, DefaultEcs.World)')
- [Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-).md 'DefaultEcs.Serialization.TextSerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')
- [Write&lt;T&gt;(System.IO.Stream, T)](./DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T).md 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T)')
- [Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext)](./DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream_T_DefaultEcs-Serialization-TextSerializationContext).md 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T, DefaultEcs.Serialization.TextSerializationContext)')
