#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')

## TextSerializationContext.Unmarshal<TIn,TOut>(Func<TIn,TOut>) Method

Adds a convertion between the type [TIn](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a deserialization operation.

```csharp
public DefaultEcs.Serialization.TextSerializationContext Unmarshal<TIn,TOut>(System.Func<TIn,TOut> converter);
```
#### Type parameters

<a name='DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn'></a>

`TIn`

The type which need to be converted.

<a name='DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut'></a>

`TOut`

The resulting type of the conversion.
#### Parameters

<a name='DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).converter'></a>

`converter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TIn](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TOut](TextSerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.TextSerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function used for the conversion.

#### Returns
[TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
Returns itself.