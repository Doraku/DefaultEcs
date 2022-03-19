#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.ResourceEnumerator Struct

Enumerates the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>').

```csharp
public struct AResourceManager<TInfo,TResource>.ResourceEnumerator :
System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TInfo, TResource>>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerator.TInfo'></a>

`TInfo`

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerator.TResource'></a>

`TResource`

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInfo](AResourceManager_TInfo,TResource_.ResourceEnumerator.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerator.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.TInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TResource](AResourceManager_TInfo,TResource_.ResourceEnumerator.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerator.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.TResource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Properties | |
| :--- | :--- |
| [Current](AResourceManager_TInfo,TResource_.ResourceEnumerator.Current.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.Current') | Gets the resource at the current position of the enumerator. |

| Methods | |
| :--- | :--- |
| [Dispose()](AResourceManager_TInfo,TResource_.ResourceEnumerator.Dispose().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.Dispose()') | Releases all resources used by the [ResourceEnumerator](AResourceManager_TInfo,TResource_.ResourceEnumerator.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator'). |
| [MoveNext()](AResourceManager_TInfo,TResource_.ResourceEnumerator.MoveNext().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.MoveNext()') | Advances the enumerator to the next resource of the [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>'). |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.IEnumerator.Current](AResourceManager_TInfo,TResource_.ResourceEnumerator.System.Collections.IEnumerator.Current.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.System.Collections.IEnumerator.Current') | Gets the resource at the current position of the enumerator. |
| [System.Collections.IEnumerator.Reset()](AResourceManager_TInfo,TResource_.ResourceEnumerator.System.Collections.IEnumerator.Reset().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerator.System.Collections.IEnumerator.Reset()') | Sets the enumerator to its initial position, which is before the first element in the collection. |
