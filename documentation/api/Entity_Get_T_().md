#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.Get&lt;T&gt;() Method
Gets the component of type [T](Entity_Get_T_().md#DefaultEcs_Entity_Get_T_()_T 'DefaultEcs.Entity.Get&lt;T&gt;().T') on the current [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public ref T Get<T>();
```
#### Type parameters
<a name='DefaultEcs_Entity_Get_T_()_T'></a>
`T`  
The type of the component.
  
#### Returns
[T](Entity_Get_T_().md#DefaultEcs_Entity_Get_T_()_T 'DefaultEcs.Entity.Get&lt;T&gt;().T')  
A reference to the component.
#### Exceptions
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World') or does not have a component of type [T](Entity_Get_T_().md#DefaultEcs_Entity_Get_T_()_T 'DefaultEcs.Entity.Get&lt;T&gt;().T').
