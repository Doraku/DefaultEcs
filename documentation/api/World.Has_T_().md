#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Has<T>() Method

Returns whether the current [World](World.md 'DefaultEcs.World') has a component of type [T](World.Has_T_().md#DefaultEcs.World.Has_T_().T 'DefaultEcs.World.Has<T>().T').  
It has nothing to do whether or not the current [World](World.md 'DefaultEcs.World') instance has an [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](World.Has_T_().md#DefaultEcs.World.Has_T_().T 'DefaultEcs.World.Has<T>().T').

```csharp
public bool Has<T>();
```
#### Type parameters

<a name='DefaultEcs.World.Has_T_().T'></a>

`T`

The type of the component.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [World](World.md 'DefaultEcs.World') has a component of type [T](World.Has_T_().md#DefaultEcs.World.Has_T_().T 'DefaultEcs.World.Has<T>().T'); otherwise, false.