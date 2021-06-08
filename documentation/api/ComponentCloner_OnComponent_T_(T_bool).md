#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')
## ComponentCloner.OnComponent&lt;T&gt;(T, bool) Method
Handles the component of type [T](ComponentCloner_OnComponent_T_(T_bool).md#DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_T 'DefaultEcs.ComponentCloner.OnComponent&lt;T&gt;(T, bool).T') from the source [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
protected virtual void OnComponent<T>(in T component, bool isEnabled);
```
#### Type parameters
<a name='DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_component'></a>
`component` [T](ComponentCloner_OnComponent_T_(T_bool).md#DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_T 'DefaultEcs.ComponentCloner.OnComponent&lt;T&gt;(T, bool).T')  
The value of the component.
  
<a name='DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_isEnabled'></a>
`isEnabled` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the component is enabled or not on the source [Entity](Entity.md 'DefaultEcs.Entity').
  
