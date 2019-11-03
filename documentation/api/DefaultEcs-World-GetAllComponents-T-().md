#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.GetAllComponents&lt;T&gt;() Method
Gets all the component of a given type [T](#DefaultEcs-World-GetAllComponents-T-()-T 'DefaultEcs.World.GetAllComponents&lt;T&gt;().T').  
```C#
public System.Span<T> GetAllComponents<T>();
```
#### Type parameters
<a name='DefaultEcs-World-GetAllComponents-T-()-T'></a>
`T`  
The type of component.  
  
#### Returns
[System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[T](#DefaultEcs-World-GetAllComponents-T-()-T 'DefaultEcs.World.GetAllComponents&lt;T&gt;().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
A [System.Span&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1') pointing directly to the component values to edit them.  
