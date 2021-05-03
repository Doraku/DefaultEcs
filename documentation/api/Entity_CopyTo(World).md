#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.CopyTo(World) Method
Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World').  
```csharp
public DefaultEcs.Entity CopyTo(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_Entity_CopyTo(DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance to which copy current [Entity](Entity.md 'DefaultEcs.Entity') and its components.
  
#### Returns
[Entity](Entity.md 'DefaultEcs.Entity')  
The created [Entity](Entity.md 'DefaultEcs.Entity') in the given [World](World.md 'DefaultEcs.World').
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
