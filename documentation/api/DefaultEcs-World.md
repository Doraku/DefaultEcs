#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## World Class
Represents a item used to create and manage [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') objects.  
```C#
public sealed class World :
IPublisher,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [World](./DefaultEcs-World.md 'DefaultEcs.World')  

Implements [IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors
- [World()](./DefaultEcs-World-World().md 'DefaultEcs.World.World()')
- [World(int)](./DefaultEcs-World-World(int).md 'DefaultEcs.World.World(int)')
### Properties
- [MaxEntityCount](./DefaultEcs-World-MaxEntityCount.md 'DefaultEcs.World.MaxEntityCount')
### Methods
- [CreateEntity()](./DefaultEcs-World-CreateEntity().md 'DefaultEcs.World.CreateEntity()')
- [Dispose()](./DefaultEcs-World-Dispose().md 'DefaultEcs.World.Dispose()')
- [GetAllComponents&lt;T&gt;()](./DefaultEcs-World-GetAllComponents-T-().md 'DefaultEcs.World.GetAllComponents&lt;T&gt;()')
- [GetAllEntities()](./DefaultEcs-World-GetAllEntities().md 'DefaultEcs.World.GetAllEntities()')
- [GetDisabledEntities()](./DefaultEcs-World-GetDisabledEntities().md 'DefaultEcs.World.GetDisabledEntities()')
- [GetEntities()](./DefaultEcs-World-GetEntities().md 'DefaultEcs.World.GetEntities()')
- [GetMaximumComponentCount&lt;T&gt;()](./DefaultEcs-World-GetMaximumComponentCount-T-().md 'DefaultEcs.World.GetMaximumComponentCount&lt;T&gt;()')
- [Publish&lt;T&gt;(T)](./DefaultEcs-World-Publish-T-(T).md 'DefaultEcs.World.Publish&lt;T&gt;(T)')
- [ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader)](./DefaultEcs-World-ReadAllComponentTypes(DefaultEcs-Serialization-IComponentTypeReader).md 'DefaultEcs.World.ReadAllComponentTypes(DefaultEcs.Serialization.IComponentTypeReader)')
- [SetMaximumComponentCount&lt;T&gt;(int)](./DefaultEcs-World-SetMaximumComponentCount-T-(int).md 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(int)')
- [Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)](./DefaultEcs-World-Subscribe-T-(DefaultEcs-ActionIn-T-).md 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)')
- [ToString()](./DefaultEcs-World-ToString().md 'DefaultEcs.World.ToString()')
### Events
- [EntityDisposed](./DefaultEcs-World-EntityDisposed.md 'DefaultEcs.World.EntityDisposed')
