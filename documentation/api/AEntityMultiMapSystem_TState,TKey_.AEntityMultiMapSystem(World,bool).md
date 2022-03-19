#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem(World, bool) Constructor

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, bool useBuffer=false);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,bool).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,bool).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,bool).world 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, bool).world') is null.