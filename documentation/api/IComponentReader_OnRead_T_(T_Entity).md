#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')
## IComponentReader.OnRead&lt;T&gt;(T, Entity) Method
Processes the component of type [T](IComponentReader_OnRead_T_(T_Entity).md#DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_T 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity).T').  
```csharp
void OnRead<T>(ref T component, in DefaultEcs.Entity componentOwner);
```
#### Type parameters
<a name='DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_T'></a>
`T`  
The type of component.
  
#### Parameters
<a name='DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_component'></a>
`component` [T](IComponentReader_OnRead_T_(T_Entity).md#DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_T 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity).T')  
The component.
  
<a name='DefaultEcs_Serialization_IComponentReader_OnRead_T_(T_DefaultEcs_Entity)_componentOwner'></a>
`componentOwner` [Entity](Entity.md 'DefaultEcs.Entity')  
The owner of the component instance, in case it is used by multiple [Entity](Entity.md 'DefaultEcs.Entity').
  
