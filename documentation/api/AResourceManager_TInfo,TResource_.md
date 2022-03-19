#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource')

## AResourceManager<TInfo,TResource> Class

Base type used to load resources of type [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') using info of type [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo').  
[TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') is used as key if the same resource is requested on multiple [Entity](Entity.md 'DefaultEcs.Entity') to only load the [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') resource once.  
If no [Entity](Entity.md 'DefaultEcs.Entity') contains the [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component identifying the resource anymore, the [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') instance is then unloaded automatically.  
By default, if [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [Unload(TInfo, TResource)](AResourceManager_TInfo,TResource_.Unload(TInfo,TResource).md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Unload(TInfo, TResource)') will call the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method of the resource.

```csharp
public abstract class AResourceManager<TInfo,TResource> :
System.IDisposable
```
#### Type parameters

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo'></a>

`TInfo`

The type used to identify a resource.

<a name='DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource'></a>

`TResource`

The type of the resource.

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AResourceManager<TInfo,TResource>

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')

| Constructors | |
| :--- | :--- |
| [AResourceManager()](AResourceManager_TInfo,TResource_.AResourceManager().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.AResourceManager()') | Creates an instance of type [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>'). |

| Properties | |
| :--- | :--- |
| [Resources](AResourceManager_TInfo,TResource_.Resources.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Resources') | Gets all the [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') loaded by the current instance and their corresponding [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo'). |

| Methods | |
| :--- | :--- |
| [Dispose()](AResourceManager_TInfo,TResource_.Dispose().md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Dispose()') | Unloads all loaded resources. |
| [Load(TInfo)](AResourceManager_TInfo,TResource_.Load(TInfo).md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Load(TInfo)') | Loads a resource of type [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') using the provided [TInfo](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TInfo 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TInfo') parameter. |
| [Manage(World)](AResourceManager_TInfo,TResource_.Manage(World).md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Manage(DefaultEcs.World)') | Sets up current [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>') instance to react to [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') components on [Entity](Entity.md 'DefaultEcs.Entity') instances of the provided [World](World.md 'DefaultEcs.World').<br/>Once no [Entity](Entity.md 'DefaultEcs.Entity') contains a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component anymore, the shared [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') resource is disposed automatically. |
| [OnResourceLoaded(Entity, TInfo, TResource)](AResourceManager_TInfo,TResource_.OnResourceLoaded(Entity,TInfo,TResource).md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.OnResourceLoaded(DefaultEcs.Entity, TInfo, TResource)') | Called when a resource is loaded from a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') component of an [Entity](Entity.md 'DefaultEcs.Entity'). |
| [Unload(TInfo, TResource)](AResourceManager_TInfo,TResource_.Unload(TInfo,TResource).md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.Unload(TInfo, TResource)') | Unloads a resource once it is no longer referenced by a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>').<br/>By default if [TResource](AResourceManager_TInfo,TResource_.md#DefaultEcs.Resource.AResourceManager_TInfo,TResource_.TResource 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>.TResource') is [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), calls the [System.IDisposable.Dispose](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable.Dispose 'System.IDisposable.Dispose') method. |
