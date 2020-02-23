#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;) Method
Subscribes a [ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)](./DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when a component of type [T](#DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).T') is changed.  
```csharp
public System.IDisposable SubscribeComponentChanged<T>(DefaultEcs.ComponentChangedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-)-action'></a>
`action` [DefaultEcs.ComponentChangedHandler&lt;](./DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)')[T](#DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)')  
The [ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)](./DefaultEcs-ComponentChangedHandler-T-(DefaultEcs-Entity_T_T).md 'DefaultEcs.ComponentChangedHandler&lt;T&gt;(DefaultEcs.Entity, T, T)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-)-action 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;).action') is null.  
