#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.GetAll&lt;T&gt;() Method
Gets all the component of a given type [T](World_GetAll_T_().md#DefaultEcs_World_GetAll_T_()_T 'DefaultEcs.World.GetAll&lt;T&gt;().T').  
```csharp
public System.Span<T> GetAll<T>();
```
#### Type parameters
<a name='DefaultEcs_World_GetAll_T_()_T'></a>
`T`  
The type of component.
  
#### Returns
[System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[T](World_GetAll_T_().md#DefaultEcs_World_GetAll_T_()_T 'DefaultEcs.World.GetAll&lt;T&gt;().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
A [System.Span&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1') pointing directly to the component values to edit them.
