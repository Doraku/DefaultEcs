#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.OnResourceLoaded(Entity, TInfo, TResource) Method
Called when a resource is loaded from a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component of an [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
protected abstract void OnResourceLoaded(in DefaultEcs.Entity entity, TInfo info, TResource resource);
```
#### Parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__OnResourceLoaded(DefaultEcs_Entity_TInfo_TResource)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The w[Entity](Entity.md 'DefaultEcs.Entity') with the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component.
  
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__OnResourceLoaded(DefaultEcs_Entity_TInfo_TResource)_info'></a>
`info` [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') info used to load the resource.
  
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__OnResourceLoaded(DefaultEcs_Entity_TInfo_TResource)_resource'></a>
`resource` [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource.
  
