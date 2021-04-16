#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Disable&lt;T&gt;() Method
Disables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord_Disable_T_().md#DefaultEcs_Command_EntityRecord_Disable_T_()_T 'DefaultEcs.Command.EntityRecord.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 9 bytes.  
```csharp
public void Disable<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_Disable_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
