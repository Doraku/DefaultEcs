#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeComponentEnabled&lt;T&gt;(ComponentEnabledHandler&lt;T&gt;) Method
Subscribes a [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).T') is enabled.  
```csharp
public System.IDisposable SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_action'></a>
`action` [DefaultEcs.ComponentEnabledHandler&lt;](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](World_SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).T')[&gt;](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentEnabledHandler&lt;T&gt;(Entity, T)](ComponentEnabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeComponentEnabled_T_(ComponentEnabledHandler_T_).md#DefaultEcs_World_SubscribeComponentEnabled_T_(DefaultEcs_ComponentEnabledHandler_T_)_action 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).action') is null.
