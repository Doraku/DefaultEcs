#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.ReadAllComponents(IComponentReader) Method
Calls on [reader](Entity_ReadAllComponents(IComponentReader).md#DefaultEcs_Entity_ReadAllComponents(DefaultEcs_Serialization_IComponentReader)_reader 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader') with all the component of the current [Entity](Entity.md 'DefaultEcs.Entity').  
This method is primiraly used for serialization purpose and should not be called in game logic.  
```csharp
public void ReadAllComponents(DefaultEcs.Serialization.IComponentReader reader);
```
#### Parameters
<a name='DefaultEcs_Entity_ReadAllComponents(DefaultEcs_Serialization_IComponentReader)_reader'></a>
`reader` [IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')  
The [IComponentReader](IComponentReader.md 'DefaultEcs.Serialization.IComponentReader') instance to be used as callback with the current [Entity](Entity.md 'DefaultEcs.Entity') components.
  
