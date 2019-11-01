#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World(int) Constructor
Initializes a new instance of the [World](./DefaultEcs-World.md 'DefaultEcs.World') class.  
```C#
public World(int maxEntityCount);
```
#### Parameters
<a name='DefaultEcs-World-World(int)-maxEntityCount'></a>
`maxEntityCount` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') that can exist in this [World](./DefaultEcs-World.md 'DefaultEcs.World').  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxEntityCount](#DefaultEcs-World-World(int)-maxEntityCount 'DefaultEcs.World.World(int).maxEntityCount') cannot be negative.  
