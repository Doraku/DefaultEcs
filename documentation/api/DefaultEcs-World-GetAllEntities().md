#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.GetAllEntities() Method
Get all the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of the current [World](./DefaultEcs-World.md 'DefaultEcs.World').  
This method is primiraly used for serialization purpose and should not be called in game logic.  
```C#
public System.Collections.Generic.IEnumerable<DefaultEcs.Entity> GetAllEntities();
```
#### Returns
[System.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable')  
All the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of the current [World](./DefaultEcs-World.md 'DefaultEcs.World').  
