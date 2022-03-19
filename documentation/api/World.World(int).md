#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World(int) Constructor

Initializes a new instance of the [World](World.md 'DefaultEcs.World') class.

```csharp
public World(int maxCapacity);
```
#### Parameters

<a name='DefaultEcs.World.World(int).maxCapacity'></a>

`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of [Entity](Entity.md 'DefaultEcs.Entity') that can exist in this [World](World.md 'DefaultEcs.World').

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](World.World(int).md#DefaultEcs.World.World(int).maxCapacity 'DefaultEcs.World.World(int).maxCapacity') cannot be negative.