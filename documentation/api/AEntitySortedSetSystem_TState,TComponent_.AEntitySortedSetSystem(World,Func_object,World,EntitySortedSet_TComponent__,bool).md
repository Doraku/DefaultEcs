#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>')

## AEntitySortedSetSystem(World, Func<object,World,EntitySortedSet<TComponent>>, bool) Constructor

Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState,TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>') class with the given [World](World.md 'DefaultEcs.World') and factory.  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntitySortedSetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySortedSet<TComponent>> factory, bool useBuffer);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySortedSet_TComponent__,bool).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySortedSet_TComponent__,bool).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')[TComponent](AEntitySortedSetSystem_TState,TComponent_.md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.TComponent 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The factory used to create the [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>').

<a name='DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySortedSet_TComponent__,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(World,Func_object,World,EntitySortedSet_TComponent__,bool).md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySortedSet_TComponent__,bool).world 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySortedSet<TComponent>>, bool).world') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(World,Func_object,World,EntitySortedSet_TComponent__,bool).md#DefaultEcs.System.AEntitySortedSetSystem_TState,TComponent_.AEntitySortedSetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySortedSet_TComponent__,bool).factory 'DefaultEcs.System.AEntitySortedSetSystem<TState,TComponent>.AEntitySortedSetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySortedSet<TComponent>>, bool).factory') is null.