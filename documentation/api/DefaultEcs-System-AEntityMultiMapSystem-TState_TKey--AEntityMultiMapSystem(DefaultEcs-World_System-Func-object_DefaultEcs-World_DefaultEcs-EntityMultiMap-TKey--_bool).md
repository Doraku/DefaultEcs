#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntityMultiMap<TKey>> factory, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool)-factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](./DefaultEcs-World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[DefaultEcs.EntityMultiMap&lt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool)-useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool)-world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool).world') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntityMultiMap-TKey--_bool)-factory 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntityMultiMap&lt;TKey&gt;&gt;, bool).factory') is null.  
