#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.Set&lt;T&gt;() Method
Sets the value of the component of type [T](Entity_Set_T_().md#DefaultEcs_Entity_Set_T_()_T 'DefaultEcs.Entity.Set&lt;T&gt;().T') to its default value on the current [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public void Set<T>();
```
#### Type parameters
<a name='DefaultEcs_Entity_Set_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](Entity_Set_T_().md#DefaultEcs_Entity_Set_T_()_T 'DefaultEcs.Entity.Set&lt;T&gt;().T') reached.
