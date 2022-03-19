#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.CopyTo(World, ComponentCloner) Method

Creates a copy of current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') with all of its components in the given [World](World.md 'DefaultEcs.World') using the given [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner').

```csharp
public DefaultEcs.Command.EntityRecord CopyTo(DefaultEcs.World world, DefaultEcs.ComponentCloner cloner);
```
#### Parameters

<a name='DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World,DefaultEcs.ComponentCloner).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') instance to which copy current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') and its components.

<a name='DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World,DefaultEcs.ComponentCloner).cloner'></a>

`cloner` [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')

The [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') to use to copy the components.

#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The created [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') in the given [World](World.md 'DefaultEcs.World').

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](EntityRecord.CopyTo(World,ComponentCloner).md#DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World,DefaultEcs.ComponentCloner).world 'DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).world') or [cloner](EntityRecord.CopyTo(World,ComponentCloner).md#DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World,DefaultEcs.ComponentCloner).cloner 'DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).cloner') was null.