#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Resource](index.md#DefaultEcs_Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator Struct
Enumerates the resources of a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  
```csharp
public struct AResourceManager<TInfo,TResource>.ResourceEnumerator :
System.Collections.Generic.IEnumerator<System.Collections.Generic.KeyValuePair<TInfo, TResource>>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__ResourceEnumerator_TInfo'></a>
`TInfo`  
  
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__ResourceEnumerator_TResource'></a>
`TResource`  
  

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInfo](AResourceManager_TInfo_TResource__ResourceEnumerator.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__ResourceEnumerator_TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.TInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TResource](AResourceManager_TInfo_TResource__ResourceEnumerator.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__ResourceEnumerator_TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.TResource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Properties

***
[Current](AResourceManager_TInfo_TResource__ResourceEnumerator_Current.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.Current')

Gets the resource at the current position of the enumerator.  
### Methods

***
[Dispose()](AResourceManager_TInfo_TResource__ResourceEnumerator_Dispose().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.Dispose()')

Releases all resources used by the [ResourceEnumerator](AResourceManager_TInfo_TResource__ResourceEnumerator.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator').  

***
[MoveNext()](AResourceManager_TInfo_TResource__ResourceEnumerator_MoveNext().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.MoveNext()')

Advances the enumerator to the next resource of the [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').
### Explicit Interface Implementations

***
[System.Collections.IEnumerator.Current](AResourceManager_TInfo_TResource__ResourceEnumerator_System_Collections_IEnumerator_Current.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.System.Collections.IEnumerator.Current')

Gets the resource at the current position of the enumerator.  

***
[System.Collections.IEnumerator.Reset()](AResourceManager_TInfo_TResource__ResourceEnumerator_System_Collections_IEnumerator_Reset().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.System.Collections.IEnumerator.Reset()')

Sets the enumerator to its initial position, which is before the first element in the collection.
