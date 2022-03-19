#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Get<T>() Method

Gets the component of type [T](World.Get_T_().md#DefaultEcs.World.Get_T_().T 'DefaultEcs.World.Get<T>().T') on the current [World](World.md 'DefaultEcs.World').

```csharp
public ref T Get<T>();
```
#### Type parameters

<a name='DefaultEcs.World.Get_T_().T'></a>

`T`

The type of the component.

#### Returns
[T](World.Get_T_().md#DefaultEcs.World.Get_T_().T 'DefaultEcs.World.Get<T>().T')  
A reference to the component.

#### Exceptions

[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
[World](World.md 'DefaultEcs.World') does not have a component of type [T](World.Get_T_().md#DefaultEcs.World.Get_T_().T 'DefaultEcs.World.Get<T>().T').