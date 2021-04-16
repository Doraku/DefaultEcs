#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Resource](index.md#DefaultEcs_Resource 'DefaultEcs.Resource')
## AResourceManager&lt;TInfo,TResource&gt; Class
Base type used to load resources of type [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using info of type [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo').  
[TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') is used as key if the same resource is requested on multiple [Entity](Entity.md 'DefaultEcs.Entity') to only load the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource once.  
If no [Entity](Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component identifying the resource anymore, the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') instance is then unloaded automatically.  
By default, if [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [Unload(TInfo, TResource)](AResourceManager_TInfo_TResource__Unload(TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource)') will call the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method of the resource.  
```csharp
public abstract class AResourceManager<TInfo,TResource> :
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo'></a>
`TInfo`  
The type used to identify a resource.
  
<a name='DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource'></a>
`TResource`  
The type of the resource.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AResourceManager&lt;TInfo,TResource&gt;  

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Constructors

***
[AResourceManager()](AResourceManager_TInfo_TResource__AResourceManager().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.AResourceManager()')

Creates an instance of type [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  
### Properties

***
[Resources](AResourceManager_TInfo_TResource__Resources.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Resources')

Gets all the [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') loaded by the current instance and their corresponding [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo').  
### Methods

***
[Dispose()](AResourceManager_TInfo_TResource__Dispose().md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Dispose()')

Unloads all loaded resources.  

***
[Load(TInfo)](AResourceManager_TInfo_TResource__Load(TInfo).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Load(TInfo)')

Loads a resource of type [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') using the provided [TInfo](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TInfo 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TInfo') parameter.  

***
[Manage(World)](AResourceManager_TInfo_TResource__Manage(World).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Manage(DefaultEcs.World)')

Sets up current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;') instance to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') components on [Entity](Entity.md 'DefaultEcs.Entity') instances of the provided [World](World.md 'DefaultEcs.World').  
Once no [Entity](Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component anymore, the shared [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') resource is disposed automatically.  

***
[OnResourceLoaded(Entity, TInfo, TResource)](AResourceManager_TInfo_TResource__OnResourceLoaded(Entity_TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)')

Called when a resource is loaded from a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') component of an [Entity](Entity.md 'DefaultEcs.Entity').  

***
[Unload(TInfo, TResource)](AResourceManager_TInfo_TResource__Unload(TInfo_TResource).md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.Unload(TInfo, TResource)')

Unloads a resource once it is no longer referenced by a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;').  
By default if [TResource](AResourceManager_TInfo_TResource_.md#DefaultEcs_Resource_AResourceManager_TInfo_TResource__TResource 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), calls the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method.  
