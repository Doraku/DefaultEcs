#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeWorldDisposed(WorldDisposedHandler) Method
Subscribes an [WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') on the current [World](World.md 'DefaultEcs.World') to be called when current instance is disposed.  
```csharp
public System.IDisposable SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler action);
```
#### Parameters
<a name='DefaultEcs_World_SubscribeWorldDisposed(DefaultEcs_WorldDisposedHandler)_action'></a>
`action` [WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)')  
The [WorldDisposedHandler(World)](WorldDisposedHandler(World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeWorldDisposed(WorldDisposedHandler).md#DefaultEcs_World_SubscribeWorldDisposed(DefaultEcs_WorldDisposedHandler)_action 'DefaultEcs.World.SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler).action') is null.
