#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](./DefaultEcs.md#DefaultEcs-Resource 'DefaultEcs.Resource')
## AResourceManager&lt;TInfo, TResource&gt; `type`
Base type used to load resources of type [TResource](#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TResource') using info of type [TInfo](#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TInfo').
[TInfo](#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TInfo') is used as key if the same resource is requested on multiple [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to only load the [TResource](#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TResource') resource once.
If no [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo-_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo, TResource&gt;') component identifying the resource anymore, the [TResource](#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TResource') instance is then disposed automatically.
### Type parameters

<a name='DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TInfo'></a>
`TInfo`

The type used to identify a resource.

<a name='DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TResource'></a>
`TResource`

The type of the resource.
### Constructors
- [#ctor()](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource---ctor().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.#ctor()')
### Methods
- [Dispose()](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource--Dispose().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.Dispose()')
- [Load(TInfo)](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource--Load(TInfo).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.Load(TInfo)')
- [Manage(DefaultEcs.World)](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource--Manage(DefaultEcs-World).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.Manage(DefaultEcs.World)')
- [OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource--OnResourceLoaded(DefaultEcs-Entity-_TInfo-_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)')
