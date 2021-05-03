#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')
## TextSerializationContext.Marshal&lt;TIn,TOut&gt;(Func&lt;TIn,TOut&gt;) Method
Adds a convertion between the type [TIn](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a serialization operation.  
```csharp
public DefaultEcs.Serialization.TextSerializationContext Marshal<TIn,TOut>(System.Func<TIn,TOut> converter);
```
#### Type parameters
<a name='DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn'></a>
`TIn`  
The type which need to be converted.
  
<a name='DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut'></a>
`TOut`  
The resulting type of the conversion.
  
#### Parameters
<a name='DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_converter'></a>
`converter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TIn](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TIn 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TOut](TextSerializationContext_Marshal_TIn_TOut_(Func_TIn_TOut_).md#DefaultEcs_Serialization_TextSerializationContext_Marshal_TIn_TOut_(System_Func_TIn_TOut_)_TOut 'DefaultEcs.Serialization.TextSerializationContext.Marshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The function used for the conversion.
  
#### Returns
[TextSerializationContext](TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
Returns itself.
