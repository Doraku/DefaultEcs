#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## EntitiesMap&lt;TKey&gt; Class
Represents a collection of [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') mapped to a [TKey](#DefaultEcs-EntitiesMap-TKey--TKey 'DefaultEcs.EntitiesMap&lt;TKey&gt;.TKey') component. Multiple [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') can be associated with a given [TKey](#DefaultEcs-EntitiesMap-TKey--TKey 'DefaultEcs.EntitiesMap&lt;TKey&gt;.TKey').  
```csharp
public sealed class EntitiesMap<TKey> :
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntitiesMap&lt;TKey&gt;  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-EntitiesMap-TKey--TKey'></a>
`TKey`  
The type of the component used as key.  
  
### Properties
- [this[TKey]](./DefaultEcs-EntitiesMap-TKey--this-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.this[TKey]')
- [Keys](./DefaultEcs-EntitiesMap-TKey--Keys.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.Keys')
- [World](./DefaultEcs-EntitiesMap-TKey--World.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.World')
### Methods
- [Complete()](./DefaultEcs-EntitiesMap-TKey--Complete().md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.Complete()')
- [ContainsEntity(DefaultEcs.Entity)](./DefaultEcs-EntitiesMap-TKey--ContainsEntity(DefaultEcs-Entity).md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.ContainsEntity(DefaultEcs.Entity)')
- [ContainsKey(TKey)](./DefaultEcs-EntitiesMap-TKey--ContainsKey(TKey).md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.ContainsKey(TKey)')
- [Count(TKey)](./DefaultEcs-EntitiesMap-TKey--Count(TKey).md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.Count(TKey)')
- [Dispose()](./DefaultEcs-EntitiesMap-TKey--Dispose().md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.Dispose()')
- [TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-EntitiesMap-TKey--TryGetEntities(TKey_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.EntitiesMap&lt;TKey&gt;.TryGetEntities(TKey, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
