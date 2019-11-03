#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.GetAllEntities() Method
Get all the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of the current [World](./DefaultEcs-World.md 'DefaultEcs.World').  
This method is primiraly used for serialization purpose and should not be called in game logic.  
```C#
public System.Collections.Generic.IEnumerable<DefaultEcs.Entity> GetAllEntities();
```
#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
All the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of the current [World](./DefaultEcs-World.md 'DefaultEcs.World').  
