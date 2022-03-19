#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')

## EntityCommandRecorder.Record(Entity) Method

Gives an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on the given [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.

```csharp
public DefaultEcs.Command.EntityRecord Record(in DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') to record action for.

#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the given [Entity](Entity.md 'DefaultEcs.Entity').

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.