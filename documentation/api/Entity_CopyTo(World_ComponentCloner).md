#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.CopyTo(World, ComponentCloner) Method
Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World') using the given [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner').  
This method is not thread safe.  
```csharp
public DefaultEcs.Entity CopyTo(DefaultEcs.World world, DefaultEcs.ComponentCloner cloner);
```
#### Parameters
<a name='DefaultEcs_Entity_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance to which copy current [Entity](Entity.md 'DefaultEcs.Entity') and its components.
  
<a name='DefaultEcs_Entity_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_cloner'></a>
`cloner` [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner')  
The [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') to use to copy the components.
  
#### Returns
[Entity](Entity.md 'DefaultEcs.Entity')  
The created [Entity](Entity.md 'DefaultEcs.Entity') in the given [World](World.md 'DefaultEcs.World').
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](Entity_CopyTo(World_ComponentCloner).md#DefaultEcs_Entity_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_world 'DefaultEcs.Entity.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).world') or [cloner](Entity_CopyTo(World_ComponentCloner).md#DefaultEcs_Entity_CopyTo(DefaultEcs_World_DefaultEcs_ComponentCloner)_cloner 'DefaultEcs.Entity.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner).cloner') was null.
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
