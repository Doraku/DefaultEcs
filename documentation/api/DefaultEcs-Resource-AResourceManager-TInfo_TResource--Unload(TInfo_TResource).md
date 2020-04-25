#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource) Method
Unloads a resource once it is no longer referenced by a [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;').  
By default if [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), calls the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method.  
```csharp
protected virtual void Unload(TInfo info, TResource resource);
```
#### Parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--Unload(TInfo_TResource)-info'></a>
`info` [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') that was used to load the resource.  
  
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--Unload(TInfo_TResource)-resource'></a>
`resource` [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') to unload.  
  
