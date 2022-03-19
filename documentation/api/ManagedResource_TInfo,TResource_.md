#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource')

## ManagedResource<TInfo,TResource> Struct

Component type used to load managed resource with a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo,TResource_.md 'DefaultEcs.Resource.AResourceManager<TInfo,TResource>').

```csharp
public readonly struct ManagedResource<TInfo,TResource>
```
#### Type parameters

<a name='DefaultEcs.Resource.ManagedResource_TInfo,TResource_.TInfo'></a>

`TInfo`

The type used to identify a resource.

<a name='DefaultEcs.Resource.ManagedResource_TInfo,TResource_.TResource'></a>

`TResource`

The type of the resource.

| Constructors | |
| :--- | :--- |
| [ManagedResource(TInfo)](ManagedResource_TInfo,TResource_.ManagedResource(TInfo).md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>.ManagedResource(TInfo)') | Creates a component of type [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') used to load a resource of type [TResource](ManagedResource_TInfo,TResource_.md#DefaultEcs.Resource.ManagedResource_TInfo,TResource_.TResource 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>.TResource'). |

| Fields | |
| :--- | :--- |
| [Info](ManagedResource_TInfo,TResource_.Info.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>.Info') | Gets the info about the resource to load. |
