#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem(World, Func<object,World,EntitySet>, bool) Constructor

Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [World](World.md 'DefaultEcs.World').  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.

```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, bool useBuffer);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,bool).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,bool).factory'></a>

`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

The factory used to create the [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,bool).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,bool).world 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, bool).world') is null.

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](AEntitySetSystem_T_.AEntitySetSystem(World,Func_object,World,EntitySet_,bool).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.World,System.Func_object,DefaultEcs.World,DefaultEcs.EntitySet_,bool).factory 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.World, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet>, bool).factory') is null.