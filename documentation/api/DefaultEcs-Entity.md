#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## Entity Struct
Represents an item in the [World](./DefaultEcs-World.md 'DefaultEcs.World').  
Only use [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') generated from the [CreateEntity()](./DefaultEcs-World-CreateEntity().md 'DefaultEcs.World.CreateEntity()') method.  
```csharp
public readonly struct Entity :
System.IDisposable,
System.IEquatable<DefaultEcs.Entity>
```
Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  
### Properties
- [IsAlive](./DefaultEcs-Entity-IsAlive.md 'DefaultEcs.Entity.IsAlive')
- [World](./DefaultEcs-Entity-World.md 'DefaultEcs.Entity.World')
### Methods
- [CopyTo(DefaultEcs.World)](./DefaultEcs-Entity-CopyTo(DefaultEcs-World).md 'DefaultEcs.Entity.CopyTo(DefaultEcs.World)')
- [Disable()](./DefaultEcs-Entity-Disable().md 'DefaultEcs.Entity.Disable()')
- [Disable&lt;T&gt;()](./DefaultEcs-Entity-Disable-T-().md 'DefaultEcs.Entity.Disable&lt;T&gt;()')
- [Dispose()](./DefaultEcs-Entity-Dispose().md 'DefaultEcs.Entity.Dispose()')
- [Enable()](./DefaultEcs-Entity-Enable().md 'DefaultEcs.Entity.Enable()')
- [Enable&lt;T&gt;()](./DefaultEcs-Entity-Enable-T-().md 'DefaultEcs.Entity.Enable&lt;T&gt;()')
- [Equals(DefaultEcs.Entity)](./DefaultEcs-Entity-Equals(DefaultEcs-Entity).md 'DefaultEcs.Entity.Equals(DefaultEcs.Entity)')
- [Equals(object)](./DefaultEcs-Entity-Equals(object).md 'DefaultEcs.Entity.Equals(object)')
- [Get&lt;T&gt;()](./DefaultEcs-Entity-Get-T-().md 'DefaultEcs.Entity.Get&lt;T&gt;()')
- [GetChildren()](./DefaultEcs-Entity-GetChildren().md 'DefaultEcs.Entity.GetChildren()')
- [GetHashCode()](./DefaultEcs-Entity-GetHashCode().md 'DefaultEcs.Entity.GetHashCode()')
- [Has&lt;T&gt;()](./DefaultEcs-Entity-Has-T-().md 'DefaultEcs.Entity.Has&lt;T&gt;()')
- [IsEnabled()](./DefaultEcs-Entity-IsEnabled().md 'DefaultEcs.Entity.IsEnabled()')
- [IsEnabled&lt;T&gt;()](./DefaultEcs-Entity-IsEnabled-T-().md 'DefaultEcs.Entity.IsEnabled&lt;T&gt;()')
- [NotifyChanged&lt;T&gt;()](./DefaultEcs-Entity-NotifyChanged-T-().md 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;()')
- [ReadAllComponents(DefaultEcs.Serialization.IComponentReader)](./DefaultEcs-Entity-ReadAllComponents(DefaultEcs-Serialization-IComponentReader).md 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader)')
- [Remove&lt;T&gt;()](./DefaultEcs-Entity-Remove-T-().md 'DefaultEcs.Entity.Remove&lt;T&gt;()')
- [RemoveFromChildrenOf(DefaultEcs.Entity)](./DefaultEcs-Entity-RemoveFromChildrenOf(DefaultEcs-Entity).md 'DefaultEcs.Entity.RemoveFromChildrenOf(DefaultEcs.Entity)')
- [RemoveFromParentsOf(DefaultEcs.Entity)](./DefaultEcs-Entity-RemoveFromParentsOf(DefaultEcs-Entity).md 'DefaultEcs.Entity.RemoveFromParentsOf(DefaultEcs.Entity)')
- [Set&lt;T&gt;(T)](./DefaultEcs-Entity-Set-T-(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)')
- [SetAsChildOf(DefaultEcs.Entity)](./DefaultEcs-Entity-SetAsChildOf(DefaultEcs-Entity).md 'DefaultEcs.Entity.SetAsChildOf(DefaultEcs.Entity)')
- [SetAsParentOf(DefaultEcs.Entity)](./DefaultEcs-Entity-SetAsParentOf(DefaultEcs-Entity).md 'DefaultEcs.Entity.SetAsParentOf(DefaultEcs.Entity)')
- [SetSameAs&lt;T&gt;(DefaultEcs.Entity)](./DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)')
- [ToString()](./DefaultEcs-Entity-ToString().md 'DefaultEcs.Entity.ToString()')
### Operators
- [operator ==(DefaultEcs.Entity, DefaultEcs.Entity)](./DefaultEcs-Entity-op_Equality(DefaultEcs-Entity_DefaultEcs-Entity).md 'DefaultEcs.Entity.op_Equality(DefaultEcs.Entity, DefaultEcs.Entity)')
- [operator !=(DefaultEcs.Entity, DefaultEcs.Entity)](./DefaultEcs-Entity-op_Inequality(DefaultEcs-Entity_DefaultEcs-Entity).md 'DefaultEcs.Entity.op_Inequality(DefaultEcs.Entity, DefaultEcs.Entity)')
