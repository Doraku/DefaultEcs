#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler) Method
Subscribes an [WorldDisposedHandler(DefaultEcs.World)](./DefaultEcs-WorldDisposedHandler(DefaultEcs-World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when current instance is disposed.  
```csharp
public System.IDisposable SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler action);
```
#### Parameters
<a name='DefaultEcs-World-SubscribeWorldDisposed(DefaultEcs-WorldDisposedHandler)-action'></a>
`action` [WorldDisposedHandler(DefaultEcs.World)](./DefaultEcs-WorldDisposedHandler(DefaultEcs-World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)')  
The [WorldDisposedHandler(DefaultEcs.World)](./DefaultEcs-WorldDisposedHandler(DefaultEcs-World).md 'DefaultEcs.WorldDisposedHandler(DefaultEcs.World)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeWorldDisposed(DefaultEcs-WorldDisposedHandler)-action 'DefaultEcs.World.SubscribeWorldDisposed(DefaultEcs.WorldDisposedHandler).action') is null.  
