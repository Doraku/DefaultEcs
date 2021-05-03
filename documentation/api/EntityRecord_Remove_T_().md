#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Remove&lt;T&gt;() Method
Removes the component of type [T](EntityRecord_Remove_T_().md#DefaultEcs_Command_EntityRecord_Remove_T_()_T 'DefaultEcs.Command.EntityRecord.Remove&lt;T&gt;().T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  
```csharp
public void Remove<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_Remove_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
