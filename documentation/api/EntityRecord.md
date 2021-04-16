#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command')
## EntityRecord Struct
Represents an [Entity](Entity.md 'DefaultEcs.Entity') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
```csharp
public readonly ref struct EntityRecord
```
### Methods

***
[Disable&lt;T&gt;()](EntityRecord_Disable_T_().md 'DefaultEcs.Command.EntityRecord.Disable&lt;T&gt;()')

Disables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord_Disable_T_().md#DefaultEcs_Command_EntityRecord_Disable_T_()_T 'DefaultEcs.Command.EntityRecord.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 9 bytes.  

***
[Disable()](EntityRecord_Disable().md 'DefaultEcs.Command.EntityRecord.Disable()')

Disables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  

***
[Dispose()](EntityRecord_Dispose().md 'DefaultEcs.Command.EntityRecord.Dispose()')

Clean the corresponding [Entity](Entity.md 'DefaultEcs.Entity') of all its components.  
The current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') should not be used again after calling this method.  
This command takes 5 bytes.  

***
[Enable&lt;T&gt;()](EntityRecord_Enable_T_().md 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;()')

Enables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord_Enable_T_().md#DefaultEcs_Command_EntityRecord_Enable_T_()_T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if corresponding [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](EntityRecord_Enable_T_().md#DefaultEcs_Command_EntityRecord_Enable_T_()_T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T').  
This command takes 9 bytes.  

***
[Enable()](EntityRecord_Enable().md 'DefaultEcs.Command.EntityRecord.Enable()')

Enables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  

***
[NotifyChanged&lt;T&gt;()](EntityRecord_NotifyChanged_T_().md 'DefaultEcs.Command.EntityRecord.NotifyChanged&lt;T&gt;()')

Notifies the value of the component of type [T](EntityRecord_NotifyChanged_T_().md#DefaultEcs_Command_EntityRecord_NotifyChanged_T_()_T 'DefaultEcs.Command.EntityRecord.NotifyChanged&lt;T&gt;().T') has changed on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  

***
[Remove&lt;T&gt;()](EntityRecord_Remove_T_().md 'DefaultEcs.Command.EntityRecord.Remove&lt;T&gt;()')

Removes the component of type [T](EntityRecord_Remove_T_().md#DefaultEcs_Command_EntityRecord_Remove_T_()_T 'DefaultEcs.Command.EntityRecord.Remove&lt;T&gt;().T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  

***
[Set&lt;T&gt;()](EntityRecord_Set_T_().md 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;()')

Sets the value of the component of type [T](EntityRecord_Set_T_().md#DefaultEcs_Command_EntityRecord_Set_T_()_T 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;().T') to its default value on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
For a blittable component, this command takes 9 bytes + the size of the component.  
For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.  

***
[Set&lt;T&gt;(T)](EntityRecord_Set_T_(T).md 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T)')

Sets the value of the component of type [T](EntityRecord_Set_T_(T).md#DefaultEcs_Command_EntityRecord_Set_T_(T)_T 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T).T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
For a blittable component, this command takes 9 bytes + the size of the component.  
For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.  

***
[SetSameAs&lt;T&gt;(EntityRecord)](EntityRecord_SetSameAs_T_(EntityRecord).md 'DefaultEcs.Command.EntityRecord.SetSameAs&lt;T&gt;(DefaultEcs.Command.EntityRecord)')

Sets the value of the component of type [T](EntityRecord_SetSameAs_T_(EntityRecord).md#DefaultEcs_Command_EntityRecord_SetSameAs_T_(DefaultEcs_Command_EntityRecord)_T 'DefaultEcs.Command.EntityRecord.SetSameAs&lt;T&gt;(DefaultEcs.Command.EntityRecord).T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord').  
This command takes 13 bytes.  
