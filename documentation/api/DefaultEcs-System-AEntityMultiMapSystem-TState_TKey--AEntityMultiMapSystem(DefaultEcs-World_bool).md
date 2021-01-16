#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem(DefaultEcs.World, bool) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World').  
To create the inner [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.World world, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_bool)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--World.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_bool)-useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-World_bool)-world 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.World, bool).world') is null.  
