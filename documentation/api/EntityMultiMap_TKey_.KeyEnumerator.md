#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')

## EntityMultiMap<TKey>.KeyEnumerator Struct

Enumerates the [TKey](EntityMultiMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>').

```csharp
public struct EntityMultiMap<TKey>.KeyEnumerator :
System.Collections.Generic.IEnumerator<TKey>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey'></a>

`TKey`

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[TKey](EntityMultiMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Current](EntityMultiMap_TKey_.KeyEnumerator.Current.md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.Current') | Gets the [TKey](EntityMultiMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.TKey') at the current position of the enumerator. |

| Methods | |
| :--- | :--- |
| [Dispose()](EntityMultiMap_TKey_.KeyEnumerator.Dispose().md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.Dispose()') | Releases all resources used by the [KeyEnumerator](EntityMultiMap_TKey_.KeyEnumerator.md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator'). |
| [MoveNext()](EntityMultiMap_TKey_.KeyEnumerator.MoveNext().md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.MoveNext()') | Advances the enumerator to the next [TKey](EntityMultiMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.TKey') of the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>'). |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.IEnumerator.Current](EntityMultiMap_TKey_.KeyEnumerator.System.Collections.IEnumerator.Current.md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.System.Collections.IEnumerator.Current') | Gets the [TKey](EntityMultiMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMultiMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.TKey') at the current position of the enumerator. |
| [System.Collections.IEnumerator.Reset()](EntityMultiMap_TKey_.KeyEnumerator.System.Collections.IEnumerator.Reset().md 'DefaultEcs.EntityMultiMap<TKey>.KeyEnumerator.System.Collections.IEnumerator.Reset()') | Sets the enumerator to its initial position, which is before the first element in the collection. |
