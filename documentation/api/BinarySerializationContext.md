#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## BinarySerializationContext Class
Represents a context used by the [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') to convert types during serialization and deserialization operations.  
The context marshalling will not be applied on members of unmanaged type as [BinarySerializer](BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer') just past their memory location with no transformation.  
```csharp
public sealed class BinarySerializationContext :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BinarySerializationContext  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[BinarySerializationContext()](BinarySerializationContext_BinarySerializationContext().md 'DefaultEcs.Serialization.BinarySerializationContext.BinarySerializationContext()')

Initializes a new instance of the [BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext') class.  
### Methods

***
[Dispose()](BinarySerializationContext_Dispose().md 'DefaultEcs.Serialization.BinarySerializationContext.Dispose()')

Releases inner resources.  

***
[Marshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](BinarySerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md 'DefaultEcs.Serialization.BinarySerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')

Adds a convertion between the type [TIn](BinarySerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_BinarySerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.BinarySerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](BinarySerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_BinarySerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.BinarySerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a serialization operation.  

***
[Unmarshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](BinarySerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')

Adds a convertion between the type [TIn](BinarySerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_BinarySerializationContext_Unmarshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](BinarySerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_BinarySerializationContext_Unmarshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a deserialization operation.  
