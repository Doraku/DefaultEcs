#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World').  
To create the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world, System.Func<object,DefaultEcs.World,DefaultEcs.EntitySet> factory, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool)-factory'></a>
`factory` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[World](./DefaultEcs-World.md 'DefaultEcs.World')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')  
The factory used to create the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool)-useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool)-world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool).world') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[factory](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_System-Func-object_DefaultEcs-World_DefaultEcs-EntitySet-_bool)-factory 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySet&gt;, bool).factory') is null.  
