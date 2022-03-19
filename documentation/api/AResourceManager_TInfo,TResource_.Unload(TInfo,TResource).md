#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.Unload(TInfo, TResource) Method

Unloads a resource once it is no longer referenced by a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>').  
By default if [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), calls the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method.

```csharp
protected virtual void Unload(TInfo info, TResource resource);
```
#### Parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.Unload(TInfo,TResource).info'></a>

`info` [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo')

The [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') that was used to load the resource.

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.Unload(TInfo,TResource).resource'></a>

`resource` [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource')

The [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') to unload.