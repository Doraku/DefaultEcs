#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord')
## WorldRecord.CreateEntity() Method
Records the creation of an [Entity](Entity.md 'DefaultEcs.Entity') on a [World](World.md 'DefaultEcs.World') and returns an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.  
This command takes 9 bytes.  
```csharp
public DefaultEcs.Command.EntityRecord CreateEntity();
```
#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') used to record actions on the later created [Entity](Entity.md 'DefaultEcs.Entity').
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
