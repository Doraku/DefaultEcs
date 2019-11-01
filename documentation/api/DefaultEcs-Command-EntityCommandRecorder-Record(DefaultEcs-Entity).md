#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder.Record(DefaultEcs.Entity) Method
Gives an [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  
```C#
public DefaultEcs.Command.EntityRecord Record(in DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs-Command-EntityCommandRecorder-Record(DefaultEcs-Entity)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record action on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
  
#### Returns
[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
