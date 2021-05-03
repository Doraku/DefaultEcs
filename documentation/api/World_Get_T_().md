#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Get&lt;T&gt;() Method
Gets all the component of a given type [T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T').  
```csharp
public System.Span<T> Get<T>();
```
#### Type parameters
<a name='DefaultEcs_World_Get_T_()_T'></a>
`T`  
The type of component.
  
#### Returns
[System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[T](World_Get_T_().md#DefaultEcs_World_Get_T_()_T 'DefaultEcs.World.Get&lt;T&gt;().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
A [System.Span&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1') pointing directly to the component values to edit them.
