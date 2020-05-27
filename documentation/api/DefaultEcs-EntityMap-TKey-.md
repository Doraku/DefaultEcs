#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## EntityMap&lt;TKey&gt; Class
Represents a collection of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') mapped to a [TKey](#DefaultEcs-EntityMap-TKey--TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey') component. Only one [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](#DefaultEcs-EntityMap-TKey--TKey 'DefaultEcs.EntityMap&lt;TKey&gt;.TKey').  
```csharp
public sealed class EntityMap<TKey> :
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityMap&lt;TKey&gt;  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-EntityMap-TKey--TKey'></a>
`TKey`  
The type of the component used as key.  
  
### Properties
- [this[TKey]](./DefaultEcs-EntityMap-TKey--this-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;.this[TKey]')
- [Keys](./DefaultEcs-EntityMap-TKey--Keys.md 'DefaultEcs.EntityMap&lt;TKey&gt;.Keys')
- [World](./DefaultEcs-EntityMap-TKey--World.md 'DefaultEcs.EntityMap&lt;TKey&gt;.World')
### Methods
- [Complete()](./DefaultEcs-EntityMap-TKey--Complete().md 'DefaultEcs.EntityMap&lt;TKey&gt;.Complete()')
- [ContainsEntity(DefaultEcs.Entity)](./DefaultEcs-EntityMap-TKey--ContainsEntity(DefaultEcs-Entity).md 'DefaultEcs.EntityMap&lt;TKey&gt;.ContainsEntity(DefaultEcs.Entity)')
- [ContainsKey(TKey)](./DefaultEcs-EntityMap-TKey--ContainsKey(TKey).md 'DefaultEcs.EntityMap&lt;TKey&gt;.ContainsKey(TKey)')
- [Dispose()](./DefaultEcs-EntityMap-TKey--Dispose().md 'DefaultEcs.EntityMap&lt;TKey&gt;.Dispose()')
- [TryGetEntity(TKey, DefaultEcs.Entity)](./DefaultEcs-EntityMap-TKey--TryGetEntity(TKey_DefaultEcs-Entity).md 'DefaultEcs.EntityMap&lt;TKey&gt;.TryGetEntity(TKey, DefaultEcs.Entity)')
