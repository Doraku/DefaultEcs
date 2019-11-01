#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource')
## AResourceManager&lt;TInfo,TResource&gt; Class
Base type used to load resources of type [TResource](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using info of type [TInfo](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo').  
[TInfo](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') is used as key if the same resource is requested on multiple [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to only load the [TResource](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource once.  
If no [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component identifying the resource anymore, the [TResource](#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance is then disposed automatically.  
```C#
public abstract class AResourceManager<TInfo,TResource>
```
#### Type parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--TInfo'></a>
`TInfo`  
The type used to identify a resource.  
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource'></a>
`TResource`  
The type of the resource.  
### Constructors
- [AResourceManager()](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--AResourceManager().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.AResourceManager()')
### Methods
- [Dispose()](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--Dispose().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Dispose()')
- [Load(TInfo)](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--Load(TInfo).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Load(TInfo)')
- [Manage(DefaultEcs.World)](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--Manage(DefaultEcs-World).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Manage(DefaultEcs.World)')
- [OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)](./DefaultEcs-Resource-AResourceManager-TInfo_TResource--OnResourceLoaded(DefaultEcs-Entity_TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)')
