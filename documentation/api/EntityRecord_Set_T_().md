#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Set&lt;T&gt;() Method
Sets the value of the component of type [T](EntityRecord_Set_T_().md#DefaultEcs_Command_EntityRecord_Set_T_()_T 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;().T') to its default value on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
For a blittable component, this command takes 9 bytes + the size of the component.  
For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.  
```csharp
public void Set<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_Set_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
