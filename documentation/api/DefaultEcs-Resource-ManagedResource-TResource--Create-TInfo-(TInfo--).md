#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Resource](./DefaultEcs-Resource.md 'DefaultEcs.Resource').[ManagedResource&lt;TResource&gt;](./DefaultEcs-Resource-ManagedResource-TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;')
## ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]) Method
Create a [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object with multiple infos.  
```C#
public static DefaultEcs.Resource.ManagedResource<TInfo[],TResource> Create<TInfo>(params TInfo[] infos);
```
#### Type parameters
<a name='DefaultEcs-Resource-ManagedResource-TResource--Create-TInfo-(TInfo--)-TInfo'></a>
`TInfo`  
The infos used to identify the resources.  
  
#### Parameters
<a name='DefaultEcs-Resource-ManagedResource-TResource--Create-TInfo-(TInfo--)-infos'></a>
`infos` [TInfo](#DefaultEcs-Resource-ManagedResource-TResource--Create-TInfo-(TInfo--)-TInfo 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The type used to identify a resource.  
  
#### Returns
[DefaultEcs.Resource.ManagedResource&lt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')[TInfo](#DefaultEcs-Resource-ManagedResource-TResource--Create-TInfo-(TInfo--)-TInfo 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.Create&lt;TInfo&gt;(TInfo[]).TInfo')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[,](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')[TResource](./DefaultEcs-Resource-ManagedResource-TResource-.md#DefaultEcs-Resource-ManagedResource-TResource--TResource 'DefaultEcs.Resource.ManagedResource&lt;TResource&gt;.TResource')[&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;')  
The [ManagedResource&lt;TInfo,TResource&gt;](./DefaultEcs-Resource-ManagedResource-TInfo_TResource-.md 'DefaultEcs.Resource.ManagedResource&lt;TInfo,TResource&gt;') object.  
