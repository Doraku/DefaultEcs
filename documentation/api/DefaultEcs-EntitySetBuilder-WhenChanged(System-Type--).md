#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')
## EntitySetBuilder.WhenChanged(System.Type[]) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when all component of the given types are changed.  
```C#
public DefaultEcs.EntitySetBuilder WhenChanged(params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilder-WhenChanged(System-Type--)-componentTypes'></a>
componentTypes [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The types of component.  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
