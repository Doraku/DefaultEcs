#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Resource](DefaultEcs.md#DefaultEcs_Resource 'DefaultEcs.Resource')
## ManagedResource&lt;TInfo,TResource&gt; Struct
Component type used to load managed resource with a [AResourceManager&lt;TInfo,TResource&gt;](AResourceManager_TInfo_TResource_.md 'DefaultEcs.Resource.AResourceManager&lt;TInfo,TResource&gt;').  
```csharp
public readonly struct ManagedResource<TInfo,TResource>
```
#### Type parameters
<a name='DefaultEcs_Resource_ManagedResource_TInfo_TResource__TInfo'></a>
`TInfo`  
The type used to identify a resource.
  
<a name='DefaultEcs_Resource_ManagedResource_TInfo_TResource__TResource'></a>
`TResource`  
The type of the resource.
  
### Constructors

***
[ManagedResource(TInfo)](ManagedResource_TInfo_TResource__ManagedResource(TInfo).md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;.ManagedResource(TInfo)')

Creates a component of type [ManagedResource&lt;TInfo,TResource&gt;](ManagedResource_TInfo_TResource_.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') used to load a resource of type [TResource](ManagedResource_TInfo_TResource_.md#DefaultEcs_Resource_ManagedResource_TInfo_TResource__TResource 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;.TResource').  
### Fields

***
[Info](ManagedResource_TInfo_TResource__Info.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;.Info')

Gets the info about the resource to load.  
