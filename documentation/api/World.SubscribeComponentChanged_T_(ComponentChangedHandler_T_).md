#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeComponentChanged<T>(ComponentChangedHandler<T>) Method

Subscribes a [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity,T,T).md 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World.SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs.World.SubscribeComponentChanged_T_(DefaultEcs.ComponentChangedHandler_T_).T 'DefaultEcs.World.SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T>).T') is changed.

```csharp
public System.IDisposable SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.SubscribeComponentChanged_T_(DefaultEcs.ComponentChangedHandler_T_).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.SubscribeComponentChanged_T_(DefaultEcs.ComponentChangedHandler_T_).action'></a>

`action` [DefaultEcs.ComponentChangedHandler&lt;](ComponentChangedHandler_T_(Entity,T,T).md 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T)')[T](World.SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs.World.SubscribeComponentChanged_T_(DefaultEcs.ComponentChangedHandler_T_).T 'DefaultEcs.World.SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T>).T')[&gt;](ComponentChangedHandler_T_(Entity,T,T).md 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T)')

The [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity,T,T).md 'DefaultEcs.ComponentChangedHandler<T>(DefaultEcs.Entity, T, T)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs.World.SubscribeComponentChanged_T_(DefaultEcs.ComponentChangedHandler_T_).action 'DefaultEcs.World.SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T>).action') is null.