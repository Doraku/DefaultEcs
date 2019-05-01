#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](./DefaultEcs.md#DefaultEcs-Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;')
## Manage(DefaultEcs.World) `method`
Sets up current [AResourceManager&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;') instance to react to [ManagedResource&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo-_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo, TResource&gt;') components on [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances of the provided [World](./DefaultEcs-World.md 'DefaultEcs.World').  
Once no [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo-_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo, TResource&gt;') component anymore, the shared [TResource](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo-_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;.TResource') resource is disposed automatically.
### Parameters

<a name='DefaultEcs-Resource-AResourceManager-TInfo-_TResource--Manage(DefaultEcs-World)-world'></a>
`world`

The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance on which to react to [ManagedResource&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo-_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo, TResource&gt;') components.
### Returns
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') instance used to make current [AResourceManager&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo-_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo, TResource&gt;') instance stop reacting to [ManagedResource&lt;TInfo, TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo-_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo, TResource&gt;') component of the provided [World](./DefaultEcs-World.md 'DefaultEcs.World').
