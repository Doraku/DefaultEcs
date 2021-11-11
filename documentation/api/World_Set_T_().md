#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Set&lt;T&gt;() Method
Sets the value of the component of type [T](World_Set_T_().md#DefaultEcs_World_Set_T_()_T 'DefaultEcs.World.Set&lt;T&gt;().T') to its default value on the current [World](World.md 'DefaultEcs.World').  
This method is not thread safe.  
```csharp
public void Set<T>();
```
#### Type parameters
<a name='DefaultEcs_World_Set_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](World_Set_T_().md#DefaultEcs_World_Set_T_()_T 'DefaultEcs.World.Set&lt;T&gt;().T') reached.
