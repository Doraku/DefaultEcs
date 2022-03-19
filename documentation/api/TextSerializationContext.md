#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization')

## TextSerializationContext Class

Represents a context used by the [TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer') to convert types during serialization and deserialization operations.

```csharp
public sealed class TextSerializationContext :
System.IDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; TextSerializationContext

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [TextSerializationContext()](TextSerializationContext.TextSerializationContext().md 'DefaultEcs.Serialization.TextSerializationContext.TextSerializationContext()') | Initializes a new instance of the [TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext') class. |

| Methods | |
| :--- | :--- |
| [Dispose()](TextSerializationContext.Dispose().md 'DefaultEcs.Serialization.TextSerializationContext.Dispose()') | Releases inner resources. |
| [Marshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](TextSerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md 'DefaultEcs.Serialization.TextSerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>)') | Adds a convertion between the type [TIn](TextSerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Marshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.TextSerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](TextSerializationContext.Marshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Marshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.TextSerializationContext.Marshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a serialization operation. |
| [Unmarshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;)](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>)') | Adds a convertion between the type [TIn](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a deserialization operation. |
