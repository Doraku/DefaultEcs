#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.IsEnabled<T>() Method

Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.IsEnabled_T_().md#DefaultEcs.Entity.IsEnabled_T_().T 'DefaultEcs.Entity.IsEnabled<T>().T') is enabled or not.

```csharp
public bool IsEnabled<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.IsEnabled_T_().T'></a>

`T`

The type of the component.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [Entity](Entity.md 'DefaultEcs.Entity') has a component of type [T](Entity.IsEnabled_T_().md#DefaultEcs.Entity.IsEnabled_T_().T 'DefaultEcs.Entity.IsEnabled<T>().T') enabled; otherwise, false.