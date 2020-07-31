#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator Struct
Enumerates the resources of a [AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  
```csharp
public struct AResourceManager<TInfo,TResource>.ResourceEnumerator :
IEnumerator<KeyValuePair<TInfo, TResource>>,
IEnumerator,
IDisposable
```
Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[System.Collections.Generic.KeyValuePair&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TInfo](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.TInfo')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[TResource](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.TResource')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.KeyValuePair-2 'System.Collections.Generic.KeyValuePair`2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-TInfo'></a>
`TInfo`  
  
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-TResource'></a>
`TResource`  
  
### Properties
- [Current](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-Current.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.Current')
### Methods
- [Dispose()](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-Dispose().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.Dispose()')
- [MoveNext()](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--ResourceEnumerator-MoveNext().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.ResourceEnumerator.MoveNext()')
