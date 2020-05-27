#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization')
## ISerializer Interface
Provides a set of methods to save and load DefaultEcs objects.  
```csharp
public interface ISerializer
```
Derived  
&#8627; [BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')  
&#8627; [TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')  
### Methods
- [Deserialize(System.IO.Stream)](./DefaultEcs-Serialization-ISerializer-Deserialize(System-IO-Stream).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream)')
- [Deserialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-ISerializer-Deserialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.ISerializer.Deserialize(System.IO.Stream, DefaultEcs.World)')
- [Serialize(System.IO.Stream, DefaultEcs.World)](./DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_DefaultEcs-World).md 'DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream, DefaultEcs.World)')
- [Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-).md 'DefaultEcs.Serialization.ISerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;)')
