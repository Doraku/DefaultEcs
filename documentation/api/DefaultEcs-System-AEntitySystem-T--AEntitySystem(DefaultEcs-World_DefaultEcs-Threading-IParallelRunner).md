#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner) Constructor
Initialise a new instance of the [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [World](./DefaultEcs-World.md 'DefaultEcs.World').  
To create the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySystem(DefaultEcs.World world, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.  
  
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-Threading-IParallelRunner)-world 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World, DefaultEcs.Threading.IParallelRunner).world') is null.  
