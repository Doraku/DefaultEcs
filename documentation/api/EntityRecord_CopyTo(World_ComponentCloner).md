#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.CopyTo(World, ComponentCloner) Method
Creates a copy of current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') with all of its components in the given [World](World.md 'DefaultEcs.World') using the given [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner').  
```csharp
public DefaultEcs.Command.EntityRecord CopyTo(DefaultEcs.World world, DefaultEcs.ComponentCloner cloner);
```
#### Parameters
<a name='DefaultEcs_Command_EntityRecord_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance to which copy current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') and its components.
  
<a name='DefaultEcs_Command_EntityRecord_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_cloner'></a>
`cloner` [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')  
The [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') to use to copy the components.
  
#### Returns
[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The created [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') in the given [World](World.md 'DefaultEcs.World').
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](EntityRecord_CopyTo(World_ComponentCloner).md#DefaultEcs_Command_EntityRecord_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_world 'DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).world') or [cloner](EntityRecord_CopyTo(World_ComponentCloner).md#DefaultEcs_Command_EntityRecord_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_cloner 'DefaultEcs.Command.EntityRecord.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).cloner') was null.
