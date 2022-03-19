#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeEntityDisabled(EntityDisabledHandler) Method

Subscribes an [EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') on the current [World](World.md 'DefaultEcs.World') to be called when an [Entity](Entity.md 'DefaultEcs.Entity') is disabled.

```csharp
public System.IDisposable SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler action);
```
#### Parameters

<a name='DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler).action'></a>

`action` [EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)')

The [EntityDisabledHandler(Entity)](EntityDisabledHandler(Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeEntityDisabled(EntityDisabledHandler).md#DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler).action 'DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler).action') is null.