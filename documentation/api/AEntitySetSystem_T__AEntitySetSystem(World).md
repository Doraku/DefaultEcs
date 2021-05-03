#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.AEntitySetSystem(World) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World').  
To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.  
```csharp
protected AEntitySetSystem(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](AEntitySetSystem_T__World.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.World') from which to get the [Entity](Entity.md 'DefaultEcs.Entity') instances to process the update.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AEntitySetSystem_T__AEntitySetSystem(World).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_World)_world 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.World).world') is null.
