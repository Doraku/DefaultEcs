#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World(int) Constructor
Initializes a new instance of the [World](./DefaultEcs-World.md 'DefaultEcs.World') class.  
```C#
public World(int maxCapacity);
```
#### Parameters
<a name='DefaultEcs-World-World(int)-maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') that can exist in this [World](./DefaultEcs-World.md 'DefaultEcs.World').  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](#DefaultEcs-World-World(int)-maxCapacity 'DefaultEcs.World.World(int).maxCapacity') cannot be negative.  
