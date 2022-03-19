#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.Enable<T>() Method

Enables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.Enable_T_().md#DefaultEcs.Entity.Enable_T_().T 'DefaultEcs.Entity.Enable<T>().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.Enable_T_().md#DefaultEcs.Entity.Enable_T_().T 'DefaultEcs.Entity.Enable<T>().T').  
This method is not thread safe.

```csharp
public void Enable<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.Enable_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').