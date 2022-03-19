#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.Disable<T>() Method

Disables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.Disable_T_().md#DefaultEcs.Entity.Disable_T_().T 'DefaultEcs.Entity.Disable<T>().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.Disable_T_().md#DefaultEcs.Entity.Disable_T_().T 'DefaultEcs.Entity.Disable<T>().T').  
This method is not thread safe.

```csharp
public void Disable<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.Disable_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').