#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Load(TInfo) Method
Loads a resource of type [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using the provided [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') parameter.  
```csharp
protected abstract TResource Load(TInfo info);
```
#### Parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__Load(TInfo)_info'></a>
`info` [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') instance used to load the resource.
  
#### Returns
[TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance.
