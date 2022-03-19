#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.SetSameAs<T>(Entity) Method

Sets the value of the component of type [T](Entity.SetSameAs_T_(Entity).md#DefaultEcs.Entity.SetSameAs_T_(DefaultEcs.Entity).T 'DefaultEcs.Entity.SetSameAs<T>(DefaultEcs.Entity).T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').  
This method is not thread safe.

```csharp
public void SetSameAs<T>(in DefaultEcs.Entity reference);
```
#### Type parameters

<a name='DefaultEcs.Entity.SetSameAs_T_(DefaultEcs.Entity).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.Entity.SetSameAs_T_(DefaultEcs.Entity).reference'></a>

`reference` [Entity](Entity.md 'DefaultEcs.Entity')

The other [Entity](Entity.md 'DefaultEcs.Entity') used as reference.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Reference [Entity](Entity.md 'DefaultEcs.Entity') comes from a different [World](World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Reference [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.SetSameAs_T_(Entity).md#DefaultEcs.Entity.SetSameAs_T_(DefaultEcs.Entity).T 'DefaultEcs.Entity.SetSameAs<T>(DefaultEcs.Entity).T').