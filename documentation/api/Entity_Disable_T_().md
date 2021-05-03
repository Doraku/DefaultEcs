#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.Disable&lt;T&gt;() Method
Disables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity_Disable_T_().md#DefaultEcs_Entity_Disable_T_()_T 'DefaultEcs.Entity.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity_Disable_T_().md#DefaultEcs_Entity_Disable_T_()_T 'DefaultEcs.Entity.Disable&lt;T&gt;().T').  
```csharp
public void Disable<T>();
```
#### Type parameters
<a name='DefaultEcs_Entity_Disable_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
