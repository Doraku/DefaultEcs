#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## World Class
Represents a item used to create and manage [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') objects.  
```csharp
public sealed class World :
System.Collections.Generic.IEnumerable<DefaultEcs.Entity>,
System.Collections.IEnumerable,
DefaultEcs.IPublisher,
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; World  

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable'), [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors
- [World()](./DefaultEcs-World-World().md 'DefaultEcs.World.World()')
- [World(int)](./DefaultEcs-World-World(int).md 'DefaultEcs.World.World(int)')
### Properties
- [MaxCapacity](./DefaultEcs-World-MaxCapacity.md 'DefaultEcs.World.MaxCapacity')
### Methods
- [CreateEntity()](./DefaultEcs-World-CreateEntity().md 'DefaultEcs.World.CreateEntity()')
- [Dispose()](./DefaultEcs-World-Dispose().md 'DefaultEcs.World.Dispose()')
- [Get&lt;T&gt;()](./DefaultEcs-World-Get-T-().md 'DefaultEcs.World.Get&lt;T&gt;()')
- [GetComponents&lt;T&gt;()](./DefaultEcs-World-GetComponents-T-().md 'DefaultEcs.World.GetComponents&lt;T&gt;()')
- [GetDisabledEntities()](./DefaultEcs-World-GetDisabledEntities().md 'DefaultEcs.World.GetDisabledEntities()')
- [GetEntities()](./DefaultEcs-World-GetEntities().md 'DefaultEcs.World.GetEntities()')
- [GetEnumerator()](./DefaultEcs-World-GetEnumerator().md 'DefaultEcs.World.GetEnumerator()')
- [GetMaxCapacity&lt;T&gt;()](./DefaultEcs-World-GetMaxCapacity-T-().md 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;()')
- [Optimize()](./DefaultEcs-World-Optimize().md 'DefaultEcs.World.Optimize()')
- [Optimize(DefaultEcs.Threading.IParallelRunner)](./DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner).md 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner)')
- [Optimize(DefaultEcs.Threading.IParallelRunner, System.Action)](./DefaultEcs-World-Optimize(DefaultEcs-Threading-IParallelRunner_System-Action).md 'DefaultEcs.World.Optimize(DefaultEcs.Threading.IParallelRunner, System.Action)')
- [Publish&lt;T&gt;(T)](./DefaultEcs-World-Publish-T-(T).md 'DefaultEcs.World.Publish&lt;T&gt;(T)')
- [ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader)](./DefaultEcs-World-ReadAllComponentTypes(DefaultEcs-Serialization-IComponentTypeReader).md 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader)')
- [SetMaxCapacity&lt;T&gt;(int)](./DefaultEcs-World-SetMaxCapacity-T-(int).md 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int)')
- [Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)](./DefaultEcs-World-Subscribe-T-(DefaultEcs-MessageHandler-T-).md 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)')
- [SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;)](./DefaultEcs-World-SubscribeComponentAdded-T-(DefaultEcs-ComponentAddedHandler-T-).md 'DefaultEcs.World.SubscribeComponentAdded&lt;T&gt;(DefaultEcs.ComponentAddedHandler&lt;T&gt;)')
- [SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;)](./DefaultEcs-World-SubscribeComponentChanged-T-(DefaultEcs-ComponentChangedHandler-T-).md 'DefaultEcs.World.SubscribeComponentChanged&lt;T&gt;(DefaultEcs.ComponentChangedHandler&lt;T&gt;)')
- [SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;)](./DefaultEcs-World-SubscribeComponentDisabled-T-(DefaultEcs-ComponentDisabledHandler-T-).md 'DefaultEcs.World.SubscribeComponentDisabled&lt;T&gt;(DefaultEcs.ComponentDisabledHandler&lt;T&gt;)')
- [SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;)](./DefaultEcs-World-SubscribeComponentEnabled-T-(DefaultEcs-ComponentEnabledHandler-T-).md 'DefaultEcs.World.SubscribeComponentEnabled&lt;T&gt;(DefaultEcs.ComponentEnabledHandler&lt;T&gt;)')
- [SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;)](./DefaultEcs-World-SubscribeComponentRemoved-T-(DefaultEcs-ComponentRemovedHandler-T-).md 'DefaultEcs.World.SubscribeComponentRemoved&lt;T&gt;(DefaultEcs.ComponentRemovedHandler&lt;T&gt;)')
- [SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler)](./DefaultEcs-World-SubscribeEntityCreated(DefaultEcs-EntityCreatedHandler).md 'DefaultEcs.World.SubscribeEntityCreated(DefaultEcs.EntityCreatedHandler)')
- [SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler)](./DefaultEcs-World-SubscribeEntityDisabled(DefaultEcs-EntityDisabledHandler).md 'DefaultEcs.World.SubscribeEntityDisabled(DefaultEcs.EntityDisabledHandler)')
- [SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler)](./DefaultEcs-World-SubscribeEntityDisposed(DefaultEcs-EntityDisposedHandler).md 'DefaultEcs.World.SubscribeEntityDisposed(DefaultEcs.EntityDisposedHandler)')
- [SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler)](./DefaultEcs-World-SubscribeEntityEnabled(DefaultEcs-EntityEnabledHandler).md 'DefaultEcs.World.SubscribeEntityEnabled(DefaultEcs.EntityEnabledHandler)')
- [ToString()](./DefaultEcs-World-ToString().md 'DefaultEcs.World.ToString()')
