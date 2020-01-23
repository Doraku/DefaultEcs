#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.Get&lt;T&gt;() Method
Gets all the component of a given type [T](#DefaultEcs-World-Get-T-()-T 'DefaultEcs.World.Get&lt;T&gt;().T').  
```csharp
public System.Span<T> Get<T>();
```
#### Type parameters
<a name='DefaultEcs-World-Get-T-()-T'></a>
`T`  
The type of component.  
  
#### Returns
[System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[T](#DefaultEcs-World-Get-T-()-T 'DefaultEcs.World.Get&lt;T&gt;().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
A [System.Span&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1') pointing directly to the component values to edit them.  
