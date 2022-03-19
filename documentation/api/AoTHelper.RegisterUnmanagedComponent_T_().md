#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper')

## AoTHelper.RegisterUnmanagedComponent<T>() Method

Registers the unmanaged type [T](AoTHelper.RegisterUnmanagedComponent_T_().md#DefaultEcs.AoTHelper.RegisterUnmanagedComponent_T_().T 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent<T>().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') and by [Set&lt;T&gt;(T)](EntityRecord.Set_T_(T).md 'DefaultEcs.Command.EntityRecord.Set<T>(T)').

```csharp
public static void RegisterUnmanagedComponent<T>()
    where T : unmanaged, System.ValueType, System.ValueType;
```
#### Type parameters

<a name='DefaultEcs.AoTHelper.RegisterUnmanagedComponent_T_().T'></a>

`T`

The type of component.