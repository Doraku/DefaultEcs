#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Load(TInfo) Method
Loads a resource of type [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using the provided [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') parameter.  
```csharp
protected abstract TResource Load(TInfo info);
```
#### Parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--Load(TInfo)-info'></a>
`info` [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') instance used to load the resource.  
  
#### Returns
[TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance.  
