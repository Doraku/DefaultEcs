#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.CopyTo(World) Method

Creates a copy of current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') with all of its components in the given [World](World.md 'DefaultEcs.World').

```csharp
public DefaultEcs.Command.EntityRecord CopyTo(DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') instance to which copy current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') and its components.

#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The created [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') in the given [World](World.md 'DefaultEcs.World').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](EntityRecord.CopyTo(World).md#DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World).world 'DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World).world') was null.