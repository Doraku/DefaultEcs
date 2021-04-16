#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[AoTHelper](AoTHelper.md 'DefaultEcs.AoTHelper')
## AoTHelper.RegisterUnmanagedComponent&lt;T&gt;() Method
Registers the unmanaged type [T](AoTHelper_RegisterUnmanagedComponent_T_().md#DefaultEcs_AoTHelper_RegisterUnmanagedComponent_T_()_T 'DefaultEcs.AoTHelper.RegisterUnmanagedComponent&lt;T&gt;().T') so it can freely be used in [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') and by [Set&lt;T&gt;(T)](EntityRecord_Set_T_(T).md 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T)').  
```csharp
public static void RegisterUnmanagedComponent<T>()
    where T : unmanaged;
```
#### Type parameters
<a name='DefaultEcs_AoTHelper_RegisterUnmanagedComponent_T_()_T'></a>
`T`  
The type of component.
  
