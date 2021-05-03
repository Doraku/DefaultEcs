#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeEntityDisposed(EntityDisposedHandler) Method
Subscribes an [EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is disposed.  
```csharp
public System.IDisposable SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler action);
```
#### Parameters
<a name='DefaultEcs_World_SubscribeEntityDisposed(DefaultEcs_EntityDisposedHandler)_action'></a>
`action` [EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)')  
The [EntityDisposedHandler(Entity)](EntityDisposedHandler(Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeEntityDisposed(EntityDisposedHandler).md#DefaultEcs_World_SubscribeEntityDisposed(DefaultEcs_EntityDisposedHandler)_action 'DefaultEcs.World.SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler).action') is null.
