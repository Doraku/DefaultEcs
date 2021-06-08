#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Set&lt;T&gt;(T) Method
Sets the value of the component of type [T](World_Set_T_(T).md#DefaultEcs_World_Set_T_(T)_T 'DefaultEcs.World.Set&lt;T&gt;(T).T') on the current [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public void Set<T>(in T component);
```
#### Type parameters
<a name='DefaultEcs_World_Set_T_(T)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_Set_T_(T)_component'></a>
`component` [T](World_Set_T_(T).md#DefaultEcs_World_Set_T_(T)_T 'DefaultEcs.World.Set&lt;T&gt;(T).T')  
The value of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](World_Set_T_(T).md#DefaultEcs_World_Set_T_(T)_T 'DefaultEcs.World.Set&lt;T&gt;(T).T') reached.
