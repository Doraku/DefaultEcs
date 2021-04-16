#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeComponentChanged&lt;T&gt;(ComponentChangedHandler&lt;T&gt;) Method
Subscribes a [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).T') is changed.  
```csharp
public System.IDisposable SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_action'></a>
`action` [DefaultEcs.ComponentChangedHandler&lt;](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)')[T](World_SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).T')[&gt;](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)')  
The [ComponentChangedHandler&lt;T&gt;(Entity, T, T)](ComponentChangedHandler_T_(Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeComponentChanged_T_(ComponentChangedHandler_T_).md#DefaultEcs_World_SubscribeComponentChanged_T_(DefaultEcs_ComponentChangedHandler_T_)_action 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).action') is null.
