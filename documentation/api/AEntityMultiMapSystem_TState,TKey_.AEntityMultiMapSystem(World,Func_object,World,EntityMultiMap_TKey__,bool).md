#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>')

## AEntityMultiMapSystem(World, Func<object,World,EntityMultiMap<TKey>>, bool) Constructor

Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](AEntityMultiMapSystem_TState,TKey_.md 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, bool useBuffer);
```
#### Parameters

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,bool).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,bool).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[TKey](AEntityMultiMapSystem_TState,TKey_.md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.TKey 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').

<a name='DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,bool).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,bool).world 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, bool).world') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(World,Func_object,World,EntityMultiMap_TKey__,bool).md#DefaultEcs.System.AEntityMultiMapSystem_TState,TKey_.AEntityMultiMapSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntityMultiMap_TKey__,bool).factory 'DefaultEcs.System.AEntityMultiMapSystem<TState,TKey>.AEntityMultiMapSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>>, bool).factory') is null.