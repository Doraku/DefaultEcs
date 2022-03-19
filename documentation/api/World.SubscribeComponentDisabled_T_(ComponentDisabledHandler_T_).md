#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeComponentDisabled<T>(ComponentDisabledHandler<T>) Method

Subscribes a [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World.SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs.World.SubscribeComponentDisabled_T_(DefaultEcs.ComponentDisabledHandler_T_).T 'DefaultEcs.World.SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T>).T') is disabled.

```csharp
public System.IDisposable SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.SubscribeComponentDisabled_T_(DefaultEcs.ComponentDisabledHandler_T_).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.SubscribeComponentDisabled_T_(DefaultEcs.ComponentDisabledHandler_T_).action'></a>

`action` [DefaultEcs.ComponentDisabledHandler&lt;](ComponentDisabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T)')[T](World.SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs.World.SubscribeComponentDisabled_T_(DefaultEcs.ComponentDisabledHandler_T_).T 'DefaultEcs.World.SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T>).T')[&gt;](ComponentDisabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T)')

The [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentDisabledHandler<T>(DefaultEcs.Entity, T)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs.World.SubscribeComponentDisabled_T_(DefaultEcs.ComponentDisabledHandler_T_).action 'DefaultEcs.World.SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T>).action') is null.