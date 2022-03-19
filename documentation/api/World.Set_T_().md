#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Set<T>() Method

Sets the value of the component of type [T](World.Set_T_().md#DefaultEcs.World.Set_T_().T 'DefaultEcs.World.Set<T>().T') to its default value on the current [World](World.md 'DefaultEcs.World').  
This method is not thread safe.

```csharp
public void Set<T>();
```
#### Type parameters

<a name='DefaultEcs.World.Set_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](World.Set_T_().md#DefaultEcs.World.Set_T_().T 'DefaultEcs.World.Set<T>().T') reached.