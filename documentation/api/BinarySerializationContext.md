#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## BinarySerializationContext Class

Represents a context used by the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') to convert types during serialization and deserialization operations.  
The context marshalling will not be applied on members of unmanaged type as [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') just past their memory location with no transformation.

```csharp
public sealed class BinarySerializationContext :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializationContext

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [BinarySerializationContext()](BinarySerializationContext.BinarySerializationContext().md 'DefaultEcs.Serialization.BinarySerializationContext.BinarySerializationContext()') | Initializes a new instance of the [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') class. |

| Methods | |
| :--- | :--- |
| [Dispose()](BinarySerializationContext.Dispose().md 'DefaultEcs.Serialization.BinarySerializationContext.Dispose()') | Releases inner resources. |
| [Marshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](BinarySerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md 'DefaultEcs.Serialization.BinarySerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>)') | Adds a convertion between the type [TIn](BinarySerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Marshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.BinarySerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](BinarySerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Marshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.BinarySerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a serialization operation. |
| [Unmarshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>)') | Adds a convertion between the type [TIn](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a deserialization operation. |
