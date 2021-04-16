#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem&lt;T&gt;.AEntitySetSystem(EntitySet, bool) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_bool)_set'></a>
`set` [EntitySet](EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.
  
<a name='DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_bool)_useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](AEntitySetSystem_T__AEntitySetSystem(EntitySet_bool).md#DefaultEcs_System_AEntitySetSystem_T__AEntitySetSystem(DefaultEcs_EntitySet_bool)_set 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, bool).set') is null.
