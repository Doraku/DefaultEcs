#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Disable() Method
Disables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  
```csharp
public void Disable();
```
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
