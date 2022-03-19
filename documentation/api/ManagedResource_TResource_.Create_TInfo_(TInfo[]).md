#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs.Resource 'DefaultEcs.Resource').[ManagedResource&lt;TResource&gt;](ManagedResource_TResource_.md 'DefaultEcs.Resource.ManagedResource<TResource>')

## ManagedResource<TResource>.Create<TInfo>(TInfo[]) Method

Create a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') object with multiple infos.

```csharp
public static DefaultEcs.Resource.ManagedResource<TInfo[],TResource> Create<TInfo>(params TInfo[] infos);
```
#### Type parameters

<a name='DefaultEcs.Resource.ManagedResource_TResource_.Create_TInfo_(TInfo[]).TInfo'></a>

`TInfo`

The infos used to identify the resources.
#### Parameters

<a name='DefaultEcs.Resource.ManagedResource_TResource_.Create_TInfo_(TInfo[]).infos'></a>

`infos` [TInfo](ManagedResource_TResource_.Create_TInfo_(TInfo[]).md#DefaultEcs.Resource.ManagedResource_TResource_.Create_TInfo_(TInfo[]).TInfo 'DefaultEcs.Resource.ManagedResource<TResource>.Create<TInfo>(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The type used to identify a resource.

#### Returns
[DefaultEcs.Resource.ManagedResource&lt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>')[TInfo](ManagedResource_TResource_.Create_TInfo_(TInfo[]).md#DefaultEcs.Resource.ManagedResource_TResource_.Create_TInfo_(TInfo[]).TInfo 'DefaultEcs.Resource.ManagedResource<TResource>.Create<TInfo>(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[,](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>')[TResource](ManagedResource_TResource_.md#DefaultEcs.Resource.ManagedResource_TResource_.TResource 'DefaultEcs.Resource.ManagedResource<TResource>.TResource')[&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>')  
The [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo,TResource_.md 'DefaultEcs.Resource.ManagedResource<TInfo,TResource>') object.