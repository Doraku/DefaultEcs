#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')

## EntityCommandRecorder.Record(World) Method

Gives an [WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord') to record action on the given [World](World.md 'DefaultEcs.World').

```csharp
public DefaultEcs.Command.WorldRecord Record(DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') to record action for.

#### Returns
[WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord')  
The [WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord') used to record actions on the given [World](World.md 'DefaultEcs.World').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](EntityCommandRecorder.Record(World).md#DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.World).world 'DefaultEcs.Command.EntityCommandRecorder.Record(DefaultEcs.World).world') is null.