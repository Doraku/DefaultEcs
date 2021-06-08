#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')
## ComponentCloner.Set&lt;T&gt;(T, bool) Method
Sets the given component on the copied entity.  
```csharp
protected void Set<T>(in T component, bool isEnabled);
```
#### Type parameters
<a name='DefaultEcs_ComponentCloner_Set_T_(T_bool)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_ComponentCloner_Set_T_(T_bool)_component'></a>
`component` [T](ComponentCloner_Set_T_(T_bool).md#DefaultEcs_ComponentCloner_Set_T_(T_bool)_T 'DefaultEcs.ComponentCloner.Set&lt;T&gt;(T, bool).T')  
The value of the component.
  
<a name='DefaultEcs_ComponentCloner_Set_T_(T_bool)_isEnabled'></a>
`isEnabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the component is enabled or not on the source [Entity](Entity.md 'DefaultEcs.Entity').
  
