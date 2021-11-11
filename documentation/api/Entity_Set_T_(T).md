#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.Set&lt;T&gt;(T) Method
Sets the value of the component of type [T](Entity_Set_T_(T).md#DefaultEcs_Entity_Set_T_(T)_T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T') on the current [Entity](Entity.md 'DefaultEcs.Entity').  
This method is not thread safe.  
```csharp
public void Set<T>(in T component);
```
#### Type parameters
<a name='DefaultEcs_Entity_Set_T_(T)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_Entity_Set_T_(T)_component'></a>
`component` [T](Entity_Set_T_(T).md#DefaultEcs_Entity_Set_T_(T)_T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T')  
The value of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](Entity_Set_T_(T).md#DefaultEcs_Entity_Set_T_(T)_T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T') reached.
