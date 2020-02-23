#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler) Method
Subscribes an [EntityCreatedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityCreatedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is created.  
```csharp
public System.IDisposable SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler action);
```
#### Parameters
<a name='DefaultEcs-World-SubscribeEntityCreated(DefaultEcs-EntityCreatedHandler)-action'></a>
`action` [EntityCreatedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityCreatedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)')  
The [EntityCreatedHandler(DefaultEcs.Entity)](./DefaultEcs-EntityCreatedHandler(DefaultEcs-Entity).md 'DefaultEcs.EntityCreatedHandler(DefaultEcs.Entity)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeEntityCreated(DefaultEcs-EntityCreatedHandler)-action 'DefaultEcs.World.SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler).action') is null.  
