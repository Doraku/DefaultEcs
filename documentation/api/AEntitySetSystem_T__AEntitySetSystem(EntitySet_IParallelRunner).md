#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.AEntitySetSystem(EntitySet, IParallelRunner) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') and [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_DefaultEcs_Threading_IParallelRunner)_set'></a>
`set` [EntitySet](EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_DefaultEcs_Threading_IParallelRunner)_runner'></a>
`runner` [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](AEntitySetSystem_T__AEntitySetSystem(EntitySet_IParallelRunner).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_DefaultEcs_Threading_IParallelRunner)_set 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner).set') is null.
