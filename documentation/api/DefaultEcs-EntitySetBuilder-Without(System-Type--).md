#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')
## EntitySetBuilder.Without(System.Type[]) Method
Makes a rule to ignore [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') with at least one component of the given types.  
```C#
public DefaultEcs.EntitySetBuilder Without(params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilder-Without(System-Type--)-componentTypes'></a>
componentTypes [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')  
The types of component.  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
