#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;) Method
Subscribes a [ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentEnabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when a component of type [T](#DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-)-T 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).T') is enabled.  
```csharp
public System.IDisposable SubscribeComponentEnabled<T>(DefaultEcs.ComponentEnabledHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-)-action'></a>
`action` [DefaultEcs.ComponentEnabledHandler&lt;](./DefaultEcs-ComponentEnabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](#DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-)-T 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentEnabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentEnabledHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentEnabledHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-)-action 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;).action') is null.  
