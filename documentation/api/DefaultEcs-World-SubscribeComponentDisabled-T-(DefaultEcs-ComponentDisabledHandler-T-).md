#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;) Method
Subscribes a [ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when a component of type [T](#DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-)-T 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).T') is disabled.  
```csharp
public System.IDisposable SubscribeComponentDisabled<T>(DefaultEcs.ComponentDisabledHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-)-action'></a>
`action` [DefaultEcs.ComponentDisabledHandler&lt;](./DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](#DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-)-T 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentDisabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentDisabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-)-action 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;).action') is null.  
