#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')
## EntitySetBuilder.WhenAdded(System.Type[]) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when all component of the given types are added.  
```C#
public DefaultEcs.EntitySetBuilder WhenAdded(params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilder-WhenAdded(System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
