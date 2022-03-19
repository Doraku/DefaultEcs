#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>')

## AResourceManager<TInfo,TResource>.Manage(World) Method

Sets up current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>') instance to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') components on [Entity](Entity.md 'DefaultEcs.Entity') instances of the provided [World](World.md 'DefaultEcs.World').  
Once no [Entity](Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component anymore, the shared [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') resource is disposed automatically.

```csharp
public System.IDisposable Manage(DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.Manage(DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](World.md 'DefaultEcs.World') instance on which to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') components.

#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') instance used to make current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>') instance stop reacting to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component of the provided [World](World.md 'DefaultEcs.World').