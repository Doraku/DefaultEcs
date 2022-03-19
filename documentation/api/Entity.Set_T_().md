#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.Set<T>() Method

Sets the value of the component of type [T](Entity.Set_T_().md#DefaultEcs.Entity.Set_T_().T 'DefaultEcs.Entity.Set<T>().T') to its default value on the current [Entity](Entity.md 'DefaultEcs.Entity').  
This method is not thread safe.

```csharp
public void Set<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.Set_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](Entity.Set_T_().md#DefaultEcs.Entity.Set_T_().T 'DefaultEcs.Entity.Set<T>().T') reached.