#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.SetSameAs&lt;T&gt;(EntityRecord) Method
Sets the value of the component of type [T](EntityRecord_SetSameAs_T_(EntityRecord).md#DefaultEcs_Command_EntityRecord_SetSameAs_T_(DefaultEcs_Command_EntityRecord)_T 'DefaultEcs.Command.EntityRecord.SetSameAs&lt;T&gt;(DefaultEcs.Command.EntityRecord).T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord').  
This command takes 13 bytes.  
```csharp
public void SetSameAs<T>(in DefaultEcs.Command.EntityRecord reference);
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_SetSameAs_T_(DefaultEcs_Command_EntityRecord)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_Command_EntityRecord_SetSameAs_T_(DefaultEcs_Command_EntityRecord)_reference'></a>
`reference` [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The other [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') used as reference.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
