#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem(EntitySet, bool) Constructor

Initialise a new instance of the [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') class with the given [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').

```csharp
protected AEntitySetSystem(DefaultEcs.EntitySet set, bool useBuffer=false);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,bool).set'></a>

`set` [EntitySet](EntitySet.md 'DefaultEcs.EntitySet')

The [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') on which to process the update.

<a name='DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,bool).useBuffer'></a>

`useBuffer` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Whether the entities should be copied before being processed.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[set](AEntitySetSystem_T_.AEntitySetSystem(EntitySet,bool).md#DefaultEcs.System.AEntitySetSystem_T_.AEntitySetSystem(DefaultEcs.EntitySet,bool).set 'DefaultEcs.System.AEntitySetSystem<T>.AEntitySetSystem(DefaultEcs.EntitySet, bool).set') is null.