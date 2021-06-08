#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.SetSameAsWorld&lt;T&gt;() Method
Sets the value of the component of type [T](Entity_SetSameAsWorld_T_().md#DefaultEcs_Entity_SetSameAsWorld_T_()_T 'DefaultEcs.Entity.SetSameAsWorld&lt;T&gt;().T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public void SetSameAsWorld<T>();
```
#### Type parameters
<a name='DefaultEcs_Entity_SetSameAsWorld_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[World](Entity_World.md 'DefaultEcs.Entity.World') does not have a component of type [T](Entity_SetSameAsWorld_T_().md#DefaultEcs_Entity_SetSameAsWorld_T_()_T 'DefaultEcs.Entity.SetSameAsWorld&lt;T&gt;().T').
