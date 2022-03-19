#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.SetSameAsWorld<T>() Method

Sets the value of the component of type [T](Entity.SetSameAsWorld_T_().md#DefaultEcs.Entity.SetSameAsWorld_T_().T 'DefaultEcs.Entity.SetSameAsWorld<T>().T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').  
This method is not thread safe.

```csharp
public void SetSameAsWorld<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.SetSameAsWorld_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[World](Entity.World.md 'DefaultEcs.Entity.World') does not have a component of type [T](Entity.SetSameAsWorld_T_().md#DefaultEcs.Entity.SetSameAsWorld_T_().T 'DefaultEcs.Entity.SetSameAsWorld<T>().T').