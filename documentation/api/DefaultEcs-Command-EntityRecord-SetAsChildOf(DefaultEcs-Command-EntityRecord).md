#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.SetAsChildOf(DefaultEcs.Command.EntityRecord) Method
Makes it so when given [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.  
```C#
public void SetAsChildOf(in DefaultEcs.Command.EntityRecord parent);
```
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-SetAsChildOf(DefaultEcs-Command-EntityRecord)-parent'></a>
parent [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') which acts as parent.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
