#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler) Method
Subscribes an [EntityDisabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disabled.  
```csharp
public System.IDisposable SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler action);
```
#### Parameters
<a name='DefaultEcs-World-SubscribeEntityDisabled(DefaultEcs-EntityDisabledHandler)-action'></a>
`action` [EntityDisabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)')  
The [EntityDisabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityDisabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityDisabledHandler(DefaultEcs.Entity)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeEntityDisabled(DefaultEcs-EntityDisabledHandler)-action 'DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler).action') is null.  
