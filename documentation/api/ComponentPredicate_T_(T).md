#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## ComponentPredicate&lt;T&gt;(T) Delegate
Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.  
```csharp
public delegate bool ComponentPredicate<T>(in T value);
```
#### Type parameters
<a name='DefaultEcs_ComponentPredicate_T_(T)_T'></a>
`T`  
The type of the component to compare.
  
#### Parameters
<a name='DefaultEcs_ComponentPredicate_T_(T)_value'></a>
`value` [T](ComponentPredicate_T_(T).md#DefaultEcs_ComponentPredicate_T_(T)_T 'DefaultEcs.ComponentPredicate&lt;T&gt;(T).T')  
The component value.
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the component meets the criteria; otherwise, false.
