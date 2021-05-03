#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource) Method
Unloads a resource once it is no longer referenced by a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;').  
By default if [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), calls the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method.  
```csharp
protected virtual void Unload(TInfo info, TResource resource);
```
#### Parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__Unload(TInfo_TResource)_info'></a>
`info` [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') that was used to load the resource.
  
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__Unload(TInfo_TResource)_resource'></a>
`resource` [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') to unload.
  
