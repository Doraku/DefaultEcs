#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.GetAll<T>() Method

Gets all the component of a given type [T](World.GetAll_T_().md#DefaultEcs.World.GetAll_T_().T 'DefaultEcs.World.GetAll<T>().T').

```csharp
public System.Span<T> GetAll<T>();
```
#### Type parameters

<a name='DefaultEcs.World.GetAll_T_().T'></a>

`T`

The type of component.

#### Returns
[System.Span&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')[T](World.GetAll_T_().md#DefaultEcs.World.GetAll_T_().T 'DefaultEcs.World.GetAll<T>().T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1')  
A [System.Span&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Span-1 'System.Span`1') pointing directly to the component values to edit them.