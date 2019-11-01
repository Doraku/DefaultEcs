#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader) Method
Calls on [reader](#DefaultEcs-World-ReadAllComponentTypes(DefaultEcs-Serialization-IComponentTypeReader)-reader 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader).reader') with all the maximum number of component of the current [World](./DefaultEcs-World.md 'DefaultEcs.World').  
This method is primiraly used for serialization purpose and should not be called in game logic.  
```C#
public void ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader reader);
```
#### Parameters
<a name='DefaultEcs-World-ReadAllComponentTypes(DefaultEcs-Serialization-IComponentTypeReader)-reader'></a>
`reader` [IComponentTypeReader](./DefaultEcs-Serialization-IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader')  
The [IComponentTypeReader](./DefaultEcs-Serialization-IComponentTypeReader.md 'DefaultEcs.Serialization.IComponentTypeReader') instance to be used as callback with the current [World](./DefaultEcs-World.md 'DefaultEcs.World') maximum number of component.  
  
