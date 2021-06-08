#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Get&lt;T&gt;() Method
Gets the component of type [T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T') on the current [World](World.md 'DefaultEcs.World').  
```csharp
public ref T Get<T>();
```
#### Type parameters
<a name='DefaultEcs_World_Get_T_()_T'></a>
`T`  
The type of the component.
  
#### Returns
[T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T')  
A reference to the component.
#### Exceptions
[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
[World](World.md 'DefaultEcs.World') does not have a component of type [T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T').
