#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeEntityCreated(EntityCreatedHandler) Method
Subscribes an [EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is created.  
```csharp
public System.IDisposable SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler action);
```
#### Parameters
<a name='DefaultEcs_World_SubscribeEntityCreated(DefaultEcs_EntityCreatedHandler)_action'></a>
`action` [EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)')  
The [EntityCreatedHandler(Entity)](EntityCreatedHandler(Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeEntityCreated(EntityCreatedHandler).md#DefaultEcs_World_SubscribeEntityCreated(DefaultEcs_EntityCreatedHandler)_action 'DefaultEcs.World.SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler).action') is null.
