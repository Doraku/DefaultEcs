#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.Has<T>() Method

Returns whether the current [Entity](Entity.md 'DefaultEcs.Entity') has a component of type [T](Entity.Has_T_().md#DefaultEcs.Entity.Has_T_().T 'DefaultEcs.Entity.Has<T>().T').

```csharp
public bool Has<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.Has_T_().T'></a>

`T`

The type of the component.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [Entity](Entity.md 'DefaultEcs.Entity') has a component of type [T](Entity.Has_T_().md#DefaultEcs.Entity.Has_T_().T 'DefaultEcs.Entity.Has<T>().T'); otherwise, false.