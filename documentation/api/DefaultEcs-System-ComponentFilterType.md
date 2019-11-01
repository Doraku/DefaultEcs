#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ComponentFilterType Enum
Specifies which filter rule should be applied when using a [ComponentAttribute](./DefaultEcs-System-ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute').  
```C#
public enum ComponentFilterType
```
### Fields
With 0  
Given component types should be present.  
WithEither 1  
At least one of the given component types should be present.  
Without 2  
Given component type should be absent.  
WithoutEither 3  
At least one of the given component types should not be present.  
WhenAdded 4  
Given component types are added.  
WhenAddedEither 5  
At least one of the given component types is added.  
WhenChanged 6  
Given component types are changed.  
WhenChangedEither 7  
At least one of the given component types is changed.  
WhenRemoved 8  
Given component types are removed.  
WhenRemovedEither 9  
At least one of the given component types is removed.  
