#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;) Method
Subscribes an [ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') on the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to be called when a component of type [T](#DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).T') is removed.  
```csharp
public System.IDisposable SubscribeComponentRemoved<T>(DefaultEcs.ComponentRemovedHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-)-action'></a>
`action` [DefaultEcs.ComponentRemovedHandler&lt;](./DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)')[T](#DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-)-T 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)')  
The [ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)](./DefaultEcs-ComponentRemovedHandler-T-(DefaultEcs-Entity_T).md 'DefaultEcs.ComponentRemovedHandler&lt;T&gt;(DefaultEcs.Entity, T)') to be called.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-)-action 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;).action') is null.  
