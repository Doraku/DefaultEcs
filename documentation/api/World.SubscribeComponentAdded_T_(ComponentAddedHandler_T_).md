#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeComponentAdded<T>(ComponentAddedHandler<T>) Method

Subscribes a [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity,T).md 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World.SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs.World.SubscribeComponentAdded_T_(DefaultEcs.ComponentAddedHandler_T_).T 'DefaultEcs.World.SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T>).T') is added.

```csharp
public System.IDisposable SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.SubscribeComponentAdded_T_(DefaultEcs.ComponentAddedHandler_T_).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.SubscribeComponentAdded_T_(DefaultEcs.ComponentAddedHandler_T_).action'></a>

`action` [DefaultEcs.ComponentAddedHandler&lt;](ComponentAddedHandler_T_(Entity,T).md 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T)')[T](World.SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs.World.SubscribeComponentAdded_T_(DefaultEcs.ComponentAddedHandler_T_).T 'DefaultEcs.World.SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T>).T')[&gt;](ComponentAddedHandler_T_(Entity,T).md 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T)')

The [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity,T).md 'DefaultEcs.ComponentAddedHandler<T>(DefaultEcs.Entity, T)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs.World.SubscribeComponentAdded_T_(DefaultEcs.ComponentAddedHandler_T_).action 'DefaultEcs.World.SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T>).action') is null.