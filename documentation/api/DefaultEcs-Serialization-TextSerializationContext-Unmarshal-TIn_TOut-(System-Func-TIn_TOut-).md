#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')
## TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;) Method
Adds a convertion between the type [TIn](#DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn') and the type [TOut](#DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut') during a deserialization operation.  
```csharp
public DefaultEcs.Serialization.TextSerializationContext Unmarshal<TIn,TOut>(System.Func<TIn,TOut> converter);
```
#### Type parameters
<a name='DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TIn'></a>
`TIn`  
The type which need to be converted.  
  
<a name='DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TOut'></a>
`TOut`  
The resulting type of the conversion.  
  
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-converter'></a>
`converter` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TIn](#DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TIn 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')[TOut](#DefaultEcs-Serialization-TextSerializationContext-Unmarshal-TIn_TOut-(System-Func-TIn_TOut-)-TOut 'DefaultEcs.Serialization.TextSerializationContext.Unmarshal&lt;TIn,TOut&gt;(System.Func&lt;TIn,TOut&gt;).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-2 'System.Func`2')  
The function used for the conversion.  
  
#### Returns
[TextSerializationContext](./DefaultEcs-Serialization-TextSerializationContext.md 'DefaultEcs.Serialization.TextSerializationContext')  
Returns itself.  
