#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeComponentDisabled&lt;T&gt;(ComponentDisabledHandler&lt;T&gt;) Method
Subscribes a [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).T') is disabled.  
```csharp
public System.IDisposable SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_action'></a>
`action` [DefaultEcs.ComponentDisabledHandler&lt;](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](World_SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_T 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).T')[&gt;](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentDisabledHandler&lt;T&gt;(Entity, T)](ComponentDisabledHandler_T_(Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeComponentDisabled_T_(ComponentDisabledHandler_T_).md#DefaultEcs_World_SubscribeComponentDisabled_T_(DefaultEcs_ComponentDisabledHandler_T_)_action 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).action') is null.
