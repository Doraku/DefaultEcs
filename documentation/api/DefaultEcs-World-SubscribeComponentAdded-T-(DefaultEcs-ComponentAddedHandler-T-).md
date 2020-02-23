#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;) Method
Subscribes a [ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when a component of type [T](#DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).T') is added.  
```csharp
public System.IDisposable SubscribeComponentAdded<T>(DefaultEcs.ComponentAddedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-)-action'></a>
`action` [DefaultEcs.ComponentAddedHandler&lt;](./DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](#DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentAddedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentAddedHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-)-action 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;).action') is null.  
