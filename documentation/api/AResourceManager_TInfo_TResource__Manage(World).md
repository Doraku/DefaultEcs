#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Manage(World) Method
Sets up current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') instance to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') components on [Entity](Entity.md 'DefaultEcs.Entity') instances of the provided [World](World.md 'DefaultEcs.World').  
Once no [Entity](Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component anymore, the shared [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource is disposed automatically.  
```csharp
public System.IDisposable Manage(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__Manage(DefaultEcs_World)_world'></a>
`world` [World](World.md 'DefaultEcs.World')  
The [World](World.md 'DefaultEcs.World') instance on which to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') components.
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') instance used to make current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') instance stop reacting to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component of the provided [World](World.md 'DefaultEcs.World').
