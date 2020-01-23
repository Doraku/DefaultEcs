#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.SetAsParentOf(DefaultEcs.Command.EntityRecord) Method
Makes it so when corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.  
This command takes 9 bytes.  
```csharp
public void SetAsParentOf(in DefaultEcs.Command.EntityRecord child);
```
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-SetAsParentOf(DefaultEcs-Command-EntityRecord)-child'></a>
`child` [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as child.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
