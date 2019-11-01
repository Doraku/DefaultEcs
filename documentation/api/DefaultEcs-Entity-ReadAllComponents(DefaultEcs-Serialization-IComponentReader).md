#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader) Method
Calls on [reader](#DefaultEcs-Entity-ReadAllComponents(DefaultEcs-Serialization-IComponentReader)-reader 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader') with all the component of the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
This method is primiraly used for serialization purpose and should not be called in game logic.  
```C#
public void ReadAllComponents(DefaultEcs.Serialization.IComponentReader reader);
```
#### Parameters
<a name='DefaultEcs-Entity-ReadAllComponents(DefaultEcs-Serialization-IComponentReader)-reader'></a>
`reader` [IComponentReader](./DefaultEcs-Serialization-IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')  
The [IComponentReader](./DefaultEcs-Serialization-IComponentReader.md 'DefaultEcs.Serialization.IComponentReader') instance to be used as callback with the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') components.  
  
