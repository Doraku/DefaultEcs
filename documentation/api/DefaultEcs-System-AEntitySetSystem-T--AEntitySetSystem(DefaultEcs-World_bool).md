#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem(DefaultEcs.World, bool) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World').  
To create the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_bool)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-System-AEntitySetSystem-T--World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_bool)-useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-World_bool)-world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World, bool).world') is null.  
