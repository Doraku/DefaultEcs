#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.RemoveFromParentsOf(DefaultEcs.Command.EntityRecord) Method
Remove the given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') from corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') children.  
```C#
public void RemoveFromParentsOf(in DefaultEcs.Command.EntityRecord child);
```
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-RemoveFromParentsOf(DefaultEcs-Command-EntityRecord)-child'></a>
`child` [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as child.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
