#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Enable&lt;T&gt;() Method
Enables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord_Enable_T_().md#DefaultEcs_Command_EntityRecord_Enable_T_()_T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if corresponding [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](EntityRecord_Enable_T_().md#DefaultEcs_Command_EntityRecord_Enable_T_()_T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T').  
This command takes 9 bytes.  
```csharp
public void Enable<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_Enable_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
