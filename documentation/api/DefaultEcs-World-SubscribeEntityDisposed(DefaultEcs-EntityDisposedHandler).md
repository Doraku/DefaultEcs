#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler) Method
Subscribes an [EntityDisposedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisposedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed.  
```csharp
public System.IDisposable SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler action);
```
#### Parameters
<a name='DefaultEcs-World-SubscribeEntityDisposed(DefaultEcs-EntityDisposedHandler)-action'></a>
`action` [EntityDisposedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisposedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)')  
The [EntityDisposedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisposedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisposedHandler(DefaultEcs.Entity)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeEntityDisposed(DefaultEcs-EntityDisposedHandler)-action 'DefaultEcs.World.SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler).action') is null.  
