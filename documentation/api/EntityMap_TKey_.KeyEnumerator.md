#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>')

## EntityMap<TKey>.KeyEnumerator Struct

Enumerates the [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey') of a [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>').

```csharp
public struct EntityMap<TKey>.KeyEnumerator :
System.Collections.Generic.IEnumerator<TKey>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey'></a>

`TKey`

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Current](EntityMap_TKey_.KeyEnumerator.Current.md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.Current') | Gets the [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey') at the current position of the enumerator. |

| Methods | |
| :--- | :--- |
| [Dispose()](EntityMap_TKey_.KeyEnumerator.Dispose().md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.Dispose()') | Releases all resources used by the [KeyEnumerator](EntityMap_TKey_.KeyEnumerator.md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator'). |
| [MoveNext()](EntityMap_TKey_.KeyEnumerator.MoveNext().md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.MoveNext()') | Advances the enumerator to the next [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey') of the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>'). |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.IEnumerator.Current](EntityMap_TKey_.KeyEnumerator.System.Collections.IEnumerator.Current.md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.System.Collections.IEnumerator.Current') | Gets the [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey') at the current position of the enumerator. |
| [System.Collections.IEnumerator.Reset()](EntityMap_TKey_.KeyEnumerator.System.Collections.IEnumerator.Reset().md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.System.Collections.IEnumerator.Reset()') | Sets the enumerator to its initial position, which is before the first element in the collection. |
