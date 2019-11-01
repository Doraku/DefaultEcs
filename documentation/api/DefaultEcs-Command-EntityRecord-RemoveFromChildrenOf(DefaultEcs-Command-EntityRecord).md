#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.RemoveFromChildrenOf(DefaultEcs.Command.EntityRecord) Method
Remove the given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') from corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') parents.  
```C#
public void RemoveFromChildrenOf(in DefaultEcs.Command.EntityRecord parent);
```
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-RemoveFromChildrenOf(DefaultEcs-Command-EntityRecord)-parent'></a>
parent [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as parent.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
