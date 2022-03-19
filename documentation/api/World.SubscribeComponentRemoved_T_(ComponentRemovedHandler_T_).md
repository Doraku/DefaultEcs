#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SubscribeComponentRemoved<T>(ComponentRemovedHandler<T>) Method

Subscribes an [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity,T).md 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World.SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs.World.SubscribeComponentRemoved_T_(DefaultEcs.ComponentRemovedHandler_T_).T 'DefaultEcs.World.SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T>).T') is removed.

```csharp
public System.IDisposable SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T> action);
```
#### Type parameters

<a name='DefaultEcs.World.SubscribeComponentRemoved_T_(DefaultEcs.ComponentRemovedHandler_T_).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.SubscribeComponentRemoved_T_(DefaultEcs.ComponentRemovedHandler_T_).action'></a>

`action` [DefaultEcs.ComponentRemovedHandler&lt;](ComponentRemovedHandler_T_(Entity,T).md 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T)')[T](World.SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs.World.SubscribeComponentRemoved_T_(DefaultEcs.ComponentRemovedHandler_T_).T 'DefaultEcs.World.SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T>).T')[&gt;](ComponentRemovedHandler_T_(Entity,T).md 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T)')

The [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity,T).md 'DefaultEcs.ComponentRemovedHandler<T>(DefaultEcs.Entity, T)') to be called.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World.SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs.World.SubscribeComponentRemoved_T_(DefaultEcs.ComponentRemovedHandler_T_).action 'DefaultEcs.World.SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T>).action') is null.