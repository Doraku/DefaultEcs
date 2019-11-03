#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')
## EntitySetBuilder.WhenRemovedEither(System.Type[]) Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the given types is removed.  
```C#
public DefaultEcs.EntitySetBuilder WhenRemovedEither(params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilder-WhenRemovedEither(System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
