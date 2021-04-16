#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Command](index.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder.CreateEntity(World) Method
Records the creation of an [Entity](Entity.md 'DefaultEcs.Entity') on a [World](World.md 'DefaultEcs.World') and returns an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.  
This command takes 9 bytes.  
```csharp
public DefaultEcs.Command.EntityRecord CreateEntity(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_Command_EntityCommandRecorder_CreateEntity(DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') on which the entity need to be created.
  
#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the later created [Entity](Entity.md 'DefaultEcs.Entity').
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
