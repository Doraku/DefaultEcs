#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;')
## AEntityBufferedSystem(DefaultEcs.EntitySet) Constructor
Initialise a new instance of the [AEntityBufferedSystem&lt;T&gt;](./DefaultEcs-System-AEntityBufferedSystem-T-.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;') class with the given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
```C#
protected AEntityBufferedSystem(DefaultEcs.EntitySet set);
```
#### Parameters
<a name='DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-EntitySet)-set'></a>
`set` [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')  
The [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](#DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-EntitySet)-set 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.AEntityBufferedSystem(DefaultEcs.EntitySet).set') is null.  
