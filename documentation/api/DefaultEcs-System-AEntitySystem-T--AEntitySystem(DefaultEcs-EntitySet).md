#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## AEntitySystem(DefaultEcs.EntitySet) Constructor
Initialise a new instance of the [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
```csharp
protected AEntitySystem(DefaultEcs.EntitySet set);
```
#### Parameters
<a name='DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet)-set'></a>
`set` [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](#DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet)-set 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet).set') is null.  
