#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.SetSameAsWorld&lt;T&gt;() Method
Sets the value of the component of type [T](EntityRecord_SetSameAsWorld_T_().md#DefaultEcs_Command_EntityRecord_SetSameAsWorld_T_()_T 'DefaultEcs.Command.EntityRecord.SetSameAsWorld&lt;T&gt;().T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of its [World](World.md 'DefaultEcs.World').  
This command takes 9 bytes.  
```csharp
public void SetSameAsWorld<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_EntityRecord_SetSameAsWorld_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
