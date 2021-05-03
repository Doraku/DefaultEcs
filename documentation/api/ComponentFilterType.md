#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## ComponentFilterType Enum
Specifies which filter rule should be applied when using a [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').  
```csharp
public enum ComponentFilterType

```
#### Fields
<a name='DefaultEcs_System_ComponentFilterType_WhenAdded'></a>
`WhenAdded` 4  
Given component types are added.  
  
<a name='DefaultEcs_System_ComponentFilterType_WhenAddedEither'></a>
`WhenAddedEither` 5  
At least one of the given component types is added.  
  
<a name='DefaultEcs_System_ComponentFilterType_WhenChanged'></a>
`WhenChanged` 6  
Given component types are changed.  
  
<a name='DefaultEcs_System_ComponentFilterType_WhenChangedEither'></a>
`WhenChangedEither` 7  
At least one of the given component types is changed.  
  
<a name='DefaultEcs_System_ComponentFilterType_WhenRemoved'></a>
`WhenRemoved` 8  
Given component types are removed.  
  
<a name='DefaultEcs_System_ComponentFilterType_WhenRemovedEither'></a>
`WhenRemovedEither` 9  
At least one of the given component types is removed.  
  
<a name='DefaultEcs_System_ComponentFilterType_With'></a>
`With` 0  
Given component types should be present.  
  
<a name='DefaultEcs_System_ComponentFilterType_WithEither'></a>
`WithEither` 1  
At least one of the given component types should be present.  
  
<a name='DefaultEcs_System_ComponentFilterType_Without'></a>
`Without` 2  
Given component type should be absent.  
  
<a name='DefaultEcs_System_ComponentFilterType_WithoutEither'></a>
`WithoutEither` 3  
At least one of the given component types should not be present.  
  
