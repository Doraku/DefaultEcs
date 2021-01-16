#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## EntityMultiMap&lt;TKey&gt; Class
Represents a collection of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') mapped to a [TKey](#DefaultEcs-EntityMultiMap-TKey--TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey') component. Multiple [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](#DefaultEcs-EntityMultiMap-TKey--TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TKey').  
```csharp
public sealed class EntityMultiMap<TKey> :
System.IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityMultiMap&lt;TKey&gt;  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-EntityMultiMap-TKey--TKey'></a>
`TKey`  
The type of the component used as key.  
  
### Properties
- [this[TKey]](./DefaultEcs-EntityMultiMap-TKey--this-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.this[TKey]')
- [Keys](./DefaultEcs-EntityMultiMap-TKey--Keys.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Keys')
- [World](./DefaultEcs-EntityMultiMap-TKey--World.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.World')
### Methods
- [Complete()](./DefaultEcs-EntityMultiMap-TKey--Complete().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Complete()')
- [ContainsEntity(DefaultEcs.Entity)](./DefaultEcs-EntityMultiMap-TKey--ContainsEntity(DefaultEcs-Entity).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.ContainsEntity(DefaultEcs.Entity)')
- [ContainsKey(TKey)](./DefaultEcs-EntityMultiMap-TKey--ContainsKey(TKey).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.ContainsKey(TKey)')
- [Count(TKey)](./DefaultEcs-EntityMultiMap-TKey--Count(TKey).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Count(TKey)')
- [Dispose()](./DefaultEcs-EntityMultiMap-TKey--Dispose().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.Dispose()')
- [TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-EntityMultiMap-TKey--TryGetEntities(TKey_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
