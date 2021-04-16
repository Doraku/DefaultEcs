#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeEntityEnabled(EntityEnabledHandler) Method
Subscribes an [EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is enabled.  
```csharp
public System.IDisposable SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler action);
```
#### Parameters
<a name='DefaultEcs_World_SubscribeEntityEnabled(DefaultEcs_EntityEnabledHandler)_action'></a>
`action` [EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)')  
The [EntityEnabledHandler(Entity)](EntityEnabledHandler(Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeEntityEnabled(EntityEnabledHandler).md#DefaultEcs_World_SubscribeEntityEnabled(DefaultEcs_EntityEnabledHandler)_action 'DefaultEcs.World.SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler).action') is null.
