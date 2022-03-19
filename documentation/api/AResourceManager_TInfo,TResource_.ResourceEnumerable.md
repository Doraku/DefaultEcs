#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.ResourceEnumerable Struct

Allows to enumerate the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>').

```csharp
public readonly struct AResourceManager<TInfo,TResource>.ResourceEnumerable :
System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TInfo, TResource>>,
System.Collections.IEnumerable
```
#### Type parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerable.TInfo'></a>

`TInfo`

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerable.TResource'></a>

`TResource`

Implements [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInfo](AResourceManager_TInfo,TResource_.ResourceEnumerable.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerable.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerable.TInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TResource](AResourceManager_TInfo,TResource_.ResourceEnumerable.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.ResourceEnumerable.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerable.TResource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1'), [System.Collections.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerable 'System.Collections.IEnumerable')

| Methods | |
| :--- | :--- |
| [GetEnumerator()](AResourceManager_TInfo,TResource_.ResourceEnumerable.GetEnumerator().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerable.GetEnumerator()') | Returns an enumerator that iterates through the collection. |

| Explicit Interface Implementations | |
| :--- | :--- |
| [System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.KeyValuePair&lt;TInfo,TResource&gt;&gt;.GetEnumerator()](AResourceManager_TInfo,TResource_.ResourceEnumerable.System.Collections.Generic.IEnumerable_System.Collections.Generic.KeyValuePair_TInfo,TResource__.GetEnumerator().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerable.System.Collections.Generic.IEnumerable<System.Collections.Generic.KeyValuePair<TInfo,TResource>>.GetEnumerator()') | Returns an enumerator that iterates through the collection. |
| [System.Collections.IEnumerable.GetEnumerator()](AResourceManager_TInfo,TResource_.ResourceEnumerable.System.Collections.IEnumerable.GetEnumerator().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.ResourceEnumerable.System.Collections.IEnumerable.GetEnumerator()') | Returns an enumerator that iterates through the collection. |
