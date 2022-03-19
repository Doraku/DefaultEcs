#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.ReadAllComponentTypes(IComponentTypeReader) Method

Calls on [reader](World.ReadAllComponentTypes(IComponentTypeReader).md#DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader).reader 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader).reader') with all the maximum number of component of the current [World](World.md 'DefaultEcs.World').  
This method is primiraly used for serialization purpose and should not be called in game logic.

```csharp
public void ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader reader);
```
#### Parameters

<a name='DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader).reader'></a>

`reader` [IComponentTypeReader](IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader')

The [IComponentTypeReader](IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader') instance to be used as callback with the current [World](World.md 'DefaultEcs.World') maximum number of component.