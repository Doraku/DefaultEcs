#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](./DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## ReadAllComponents(DefaultEcs.Serialization.IComponentReader) `method`
Calls on [reader](#DefaultEcs-Entity-ReadAllComponents(DefaultEcs-Serialization-IComponentReader)-reader 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader') with all the component of the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').
This method is primiraly used for serialization purpose and should not be called in game logic.
### Parameters

<a name='DefaultEcs-Entity-ReadAllComponents(DefaultEcs-Serialization-IComponentReader)-reader'></a>
`reader`

The [IComponentReader](./DefaultEcs-Serialization-IComponentReader.md 'DefaultEcs.Serialization.IComponentReader') instance to be used as callback with the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') components.
