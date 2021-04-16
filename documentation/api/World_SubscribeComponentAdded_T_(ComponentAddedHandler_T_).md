#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SubscribeComponentAdded&lt;T&gt;(ComponentAddedHandler&lt;T&gt;) Method
Subscribes a [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](World.md 'DefaultEcs.World') to be called when a component of type [T](World_SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).T') is added.  
```csharp
public System.IDisposable SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_action'></a>
`action` [DefaultEcs.ComponentAddedHandler&lt;](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](World_SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_T 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).T')[&gt;](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentAddedHandler&lt;T&gt;(Entity, T)](ComponentAddedHandler_T_(Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](World_SubscribeComponentAdded_T_(ComponentAddedHandler_T_).md#DefaultEcs_World_SubscribeComponentAdded_T_(DefaultEcs_ComponentAddedHandler_T_)_action 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).action') is null.
