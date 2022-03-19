#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.OnResourceLoaded(Entity, TInfo, TResource) Method

Called when a resource is loaded from a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component of an [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
protected abstract void OnResourceLoaded(in DefaultEcs.Entity entity, TInfo info, TResource resource);
```
#### Parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.OnResourceLoaded(DefaultEcs.Entity,TInfo,TResource).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The w[Entity](Entity.md 'DefaultEcs.Entity') with the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component.

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.OnResourceLoaded(DefaultEcs.Entity,TInfo,TResource).info'></a>

`info` [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo')

The [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') info used to load the resource.

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.OnResourceLoaded(DefaultEcs.Entity,TInfo,TResource).resource'></a>

`resource` [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource')

The [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') resource.