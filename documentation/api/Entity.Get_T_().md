#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.Get<T>() Method

Gets the component of type [T](Entity.Get_T_().md#DefaultEcs.Entity.Get_T_().T 'DefaultEcs.Entity.Get<T>().T') on the current [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public ref T Get<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.Get_T_().T'></a>

`T`

The type of the component.

#### Returns
[T](Entity.Get_T_().md#DefaultEcs.Entity.Get_T_().T 'DefaultEcs.Entity.Get<T>().T')  
A reference to the component.

#### Exceptions

[System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World') or does not have a component of type [T](Entity.Get_T_().md#DefaultEcs.Entity.Get_T_().T 'DefaultEcs.Entity.Get<T>().T').