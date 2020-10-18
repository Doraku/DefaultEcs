#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization')
## BinarySerializationContext Class
Represents a context used by the [BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') to convert types during serialization and deserialization operations.  
The context marshalling will not be applied on members of unmanaged type as [BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') just past their memory location with no transformation.  
```csharp
public sealed class BinarySerializationContext :
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializationContext  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors
- [BinarySerializationContext()](./DefaultEcs-Serialization-BinarySerializationContext-BinarySerializationContext().md 'DefaultEcs.Serialization.BinarySerializationContext.BinarySerializationContext()')
### Methods
- [Dispose()](./DefaultEcs-Serialization-BinarySerializationContext-Dispose().md 'DefaultEcs.Serialization.BinarySerializationContext.Dispose()')
- [Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)](./DefaultEcs-Serialization-BinarySerializationContext-Marshal-TIn_TOut-(System-Func-TIn_TOut-).md 'DefaultEcs.Serialization.BinarySerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')
- [Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)](./DefaultEcs-Serialization-BinarySerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-).md 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')
