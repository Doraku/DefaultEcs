#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.GetMaxCapacity<T>() Method

Gets the maximum number of [T](World.GetMaxCapacity_T_().md#DefaultEcs.World.GetMaxCapacity_T_().T 'DefaultEcs.World.GetMaxCapacity<T>().T') components this [World](World.md 'DefaultEcs.World') can create.

```csharp
public int GetMaxCapacity<T>();
```
#### Type parameters

<a name='DefaultEcs.World.GetMaxCapacity_T_().T'></a>

`T`

The type of component.

#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of [T](World.GetMaxCapacity_T_().md#DefaultEcs.World.GetMaxCapacity_T_().T 'DefaultEcs.World.GetMaxCapacity<T>().T') components this [World](World.md 'DefaultEcs.World') can create, or -1 if it is currently not handled.