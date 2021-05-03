#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Enable() Method
Enables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  
```csharp
public void Enable();
```
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
