#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeComponentRemoved&lt;T&gt;(ComponentRemovedHandler&lt;T&gt;) Method
Subscribes an [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).T') is removed.  
```csharp
public System.IDisposable SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_action'></a>
`action` [DefaultEcs.ComponentRemovedHandler&lt;](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](World_SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).T')[&gt;](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentRemovedHandler&lt;T&gt;(Entity, T)](ComponentRemovedHandler_T_(Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeComponentRemoved_T_(ComponentRemovedHandler_T_).md#DefaultEcs_World_SubscribeComponentRemoved_T_(DefaultEcs_ComponentRemovedHandler_T_)_action 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).action') is null.
