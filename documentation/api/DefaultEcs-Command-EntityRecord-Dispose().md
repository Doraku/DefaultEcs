#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Dispose() Method
Clean the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of all its components.  
The current [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') should not be used again after calling this method.  
This command takes 5 bytes.  
```C#
public void Dispose();
```
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
