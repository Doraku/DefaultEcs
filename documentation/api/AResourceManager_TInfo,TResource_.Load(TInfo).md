#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.Load(TInfo) Method

Loads a resource of type [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') using the provided [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') parameter.

```csharp
protected abstract TResource Load(TInfo info);
```
#### Parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.Load(TInfo).info'></a>

`info` [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo')

The [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') instance used to load the resource.

#### Returns
[TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource')  
The [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') instance.