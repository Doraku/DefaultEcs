#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeComponentEnabled<T>(ComponentEnabledHandler<T>) Method

Subscribes a [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World.SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs.World.SubscribeComponentEnabled_T_(DefaultEcs.ComponentEnabledHandler_T_).T 'DefaultEcs.World.SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T>).T') is enabled.

```csharp
public System.IDisposable SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.SubscribeComponentEnabled_T_(DefaultEcs.ComponentEnabledHandler_T_).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.SubscribeComponentEnabled_T_(DefaultEcs.ComponentEnabledHandler_T_).action'></a>

`action` [DefaultEcs.ComponentEnabledHandler&lt;](ComponentEnabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T)')[T](World.SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs.World.SubscribeComponentEnabled_T_(DefaultEcs.ComponentEnabledHandler_T_).T 'DefaultEcs.World.SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T>).T')[&gt;](ComponentEnabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T)')

The [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity,T).md 'DefaultEcs.ComponentEnabledHandler<T>(DefaultEcs.Entity, T)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs.World.SubscribeComponentEnabled_T_(DefaultEcs.ComponentEnabledHandler_T_).action 'DefaultEcs.World.SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T>).action') is null.