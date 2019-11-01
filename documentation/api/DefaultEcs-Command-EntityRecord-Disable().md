#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Disable() Method
Disables the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') so it does not appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  
```C#
public void Disable();
```
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
