#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.GetMaxCapacity&lt;T&gt;() Method
Gets the maximum number of [T](World_GetMaxCapacity_T_().md#DefaultEcs_World_GetMaxCapacity_T_()_T 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;().T') components this [World](World.md 'DefaultEcs.World') can create.  
```csharp
public int GetMaxCapacity<T>();
```
#### Type parameters
<a name='DefaultEcs_World_GetMaxCapacity_T_()_T'></a>
`T`  
The type of component.
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of [T](World_GetMaxCapacity_T_().md#DefaultEcs_World_GetMaxCapacity_T_()_T 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;().T') components this [World](World.md 'DefaultEcs.World') can create, or -1 if it is currently not handled.
