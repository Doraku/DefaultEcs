#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;')
## AEntitySetSystem(DefaultEcs.EntitySet, bool) Constructor
Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') class with the given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, bool useBuffer);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_bool)-set'></a>
`set` [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.  
  
<a name='DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_bool)-useBuffer'></a>
`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the entities should be copied before being processed.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](#DefaultEcs-System-AEntitySetSystem-T--AEntitySetSystem(DefaultEcs-EntitySet_bool)-set 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;.AEntitySetSystem(DefaultEcs.EntitySet, bool).set') is null.  
