#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Enable() Method
Enables the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') so it can appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 5 bytes.  
```C#
public void Enable();
```
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
