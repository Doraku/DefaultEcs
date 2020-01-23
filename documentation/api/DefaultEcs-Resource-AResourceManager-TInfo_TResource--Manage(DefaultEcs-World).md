#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;')
## AResourceManager&lt;TInfo,TResource&gt;.Manage(DefaultEcs.World) Method
Sets up current [AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') instance to react to [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') components on [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances of the provided [World](./DefaultEcs-World.md 'DefaultEcs.World').  
Once no [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component anymore, the shared [TResource](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md#DefaultEcs-Resource-AResourceManager-TInfo_TResource--TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource is disposed automatically.  
```csharp
public System.IDisposable Manage(DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs-Resource-AResourceManager-TInfo_TResource--Manage(DefaultEcs-World)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance on which to react to [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') components.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') instance used to make current [AResourceManager&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-AResourceManager-TInfo_TResource-.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') instance stop reacting to [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component of the provided [World](./DefaultEcs-World.md 'DefaultEcs.World').  
