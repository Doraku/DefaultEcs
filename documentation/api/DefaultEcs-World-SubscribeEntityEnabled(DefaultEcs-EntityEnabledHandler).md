#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler) Method
Subscribes an [EntityEnabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityEnabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is enabled.  
```csharp
public System.IDisposable SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler action);
```
#### Parameters
<a name='DefaultEcs-World-SubscribeEntityEnabled(DefaultEcs-EntityEnabledHandler)-action'></a>
`action` [EntityEnabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityEnabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)')  
The [EntityEnabledHandler(DefaultEcs.Entity)](./DefaultEcs-EntityEnabledHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityEnabledHandler(DefaultEcs.Entity)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeEntityEnabled(DefaultEcs-EntityEnabledHandler)-action 'DefaultEcs.World.SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler).action') is null.  
