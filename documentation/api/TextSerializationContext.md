#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## TextSerializationContext Class
Represents a context used by the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') to convert types during serialization and deserialization operations.  
```csharp
public sealed class TextSerializationContext :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextSerializationContext  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[TextSerializationContext()](TextSerializationContext_TextSerializationContext().md 'DefaultEcs.Serialization.TextSerializationContext.TextSerializationContext()')

Initializes a new instance of the [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') class.  
### Methods

***
[Dispose()](TextSerializationContext_Dispose().md 'DefaultEcs.Serialization.TextSerializationContext.Dispose()')

Releases inner resources.  

***
[Marshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')

Adds a convertion between the type [TIn](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a serialization operation.  

***
[Unmarshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](TextSerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;)')

Adds a convertion between the type [TIn](TextSerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Unmarshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](TextSerializationContext_Unmarshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Unmarshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a deserialization operation.  
