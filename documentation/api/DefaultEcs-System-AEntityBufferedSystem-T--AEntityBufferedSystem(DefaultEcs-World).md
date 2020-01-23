#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;')
## AEntityBufferedSystem(DefaultEcs.World) Constructor
Initialise a new instance of the [AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;') class with the given [World](./DefaultEcs-World.md 'DefaultEcs.World').  
To create the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntityBufferedSystem(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-World)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-World)-world 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.AEntityBufferedSystem(DefaultEcs.World).world') is null.  
