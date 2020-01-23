#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ComponentFilterType Enum
Specifies which filter rule should be applied when using a [ComponentAttribute](./DefaultEcs-System-ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').  
```csharp
public enum ComponentFilterType
```
### Fields
<a name='DefaultEcs-System-ComponentFilterType-With'></a>
`With` 0  
Given component types should be present.  
  
<a name='DefaultEcs-System-ComponentFilterType-WithEither'></a>
`WithEither` 1  
At least one of the given component types should be present.  
  
<a name='DefaultEcs-System-ComponentFilterType-Without'></a>
`Without` 2  
Given component type should be absent.  
  
<a name='DefaultEcs-System-ComponentFilterType-WithoutEither'></a>
`WithoutEither` 3  
At least one of the given component types should not be present.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenAdded'></a>
`WhenAdded` 4  
Given component types are added.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenAddedEither'></a>
`WhenAddedEither` 5  
At least one of the given component types is added.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenChanged'></a>
`WhenChanged` 6  
Given component types are changed.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenChangedEither'></a>
`WhenChangedEither` 7  
At least one of the given component types is changed.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenRemoved'></a>
`WhenRemoved` 8  
Given component types are removed.  
  
<a name='DefaultEcs-System-ComponentFilterType-WhenRemovedEither'></a>
`WhenRemovedEither` 9  
At least one of the given component types is removed.  
  
