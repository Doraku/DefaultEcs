#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') and [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner').  
```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, DefaultEcs.Threading.IParallelRunner runner);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner)-set'></a>
`set` [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner)-runner'></a>
`runner` [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner')  
The [IParallelRunner](./DefaultEcs-Threading-IParallelRunner.md 'DefaultEcs.Threading.IParallelRunner') used to process the update in parallel if not null.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_DefaultEcs-Threading-IParallelRunner)-set 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, DefaultEcs.Threading.IParallelRunner).set') is null.  
