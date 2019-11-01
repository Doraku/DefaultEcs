#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource) Method
Called when a resource is loaded from a [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component of an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```C#
protected abstract void OnResourceLoaded(in DefaultEcs.Entity entity, TInfo info, TResource resource);
```
#### Parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--OnResourceLoaded(DefaultEcs-Entity_TInfo_TResource)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The w[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with the [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component.  
  
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--OnResourceLoaded(DefaultEcs-Entity_TInfo_TResource)-info'></a>
`info` [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo')  
The [TInfo](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') info used to load the resource.  
  
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--OnResourceLoaded(DefaultEcs-Entity_TInfo_TResource)-resource'></a>
`resource` [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource')  
The [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource.  
  
