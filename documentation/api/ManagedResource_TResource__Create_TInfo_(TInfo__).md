#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Resource](index.md#DefaultEcs_Resource 'DefaultEcs.Resource').[ManagedResource&lt;TResource&gt;](ManagedResource_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;')
## ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]) Method
Create a [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object with multiple infos.  
```csharp
public static DefaultEcs.Resource.ManagedResource<TInfo[],TResource> Create<TInfo>(params TInfo[] infos);
```
#### Type parameters
<a name='DefaultEcs_Resource_ManagedResource_TResource__Create_TInfo_(TInfo__)_TInfo'></a>
`TInfo`  
The infos used to identify the resources.
  
#### Parameters
<a name='DefaultEcs_Resource_ManagedResource_TResource__Create_TInfo_(TInfo__)_infos'></a>
`infos` [TInfo](ManagedResource_TResource__Create_TInfo_(TInfo__).md#DefaultEcs_Resource_ManagedResource_TResource__Create_TInfo_(TInfo__)_TInfo 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The type used to identify a resource.
  
#### Returns
[DefaultEcs.Resource.ManagedResource&lt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')[TInfo](ManagedResource_TResource__Create_TInfo_(TInfo__).md#DefaultEcs_Resource_ManagedResource_TResource__Create_TInfo_(TInfo__)_TInfo 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[,](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')[TResource](ManagedResource_TResource_.md#DefaultEcs_Resource_ManagedResource_TResource__TResource 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.TResource')[&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')  
The [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object.
