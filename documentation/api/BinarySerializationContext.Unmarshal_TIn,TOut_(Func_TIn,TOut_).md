#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs.Serialization 'DefaultEcs.Serialization').[BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')

## BinarySerializationContext.Unmarshal<TIn,TOut>(Func<TIn,TOut>) Method

Adds a convertion between the type [TIn](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn') and the type [TOut](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut') during a deserialization operation.

```csharp
public DefaultEcs.Serialization.BinarySerializationContext Unmarshal<TIn,TOut>(System.Func<TIn,TOut> converter);
```
#### Type parameters

<a name='DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn'></a>

`TIn`

The type which need to be converted.

<a name='DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut'></a>

`TOut`

The resulting type of the conversion.
#### Parameters

<a name='DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).converter'></a>

`converter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TIn](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TIn 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TOut](BinarySerializationContext.Unmarshal_TIn,TOut_(Func_TIn,TOut_).md#DefaultEcs.Serialization.BinarySerializationContext.Unmarshal_TIn,TOut_(System.Func_TIn,TOut_).TOut 'DefaultEcs.Serialization.BinarySerializationContext.Unmarshal<TIn,TOut>(System.Func<TIn,TOut>).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')

The function used for the conversion.

#### Returns
[BinarySerializationContext](BinarySerializationContext.md 'DefaultEcs.Serialization.BinarySerializationContext')  
Returns itself.