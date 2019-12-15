#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilderExtension](./DefaultEcs-EntitySetBuilderExtension.md 'DefaultEcs.EntitySetBuilderExtension')
## EntitySetBuilderExtension.WhenRemoved(DefaultEcs.EntitySetBuilder, System.Type[]) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when all component of the given types are removed.  
```C#
public static DefaultEcs.EntitySetBuilder WhenRemoved(this DefaultEcs.EntitySetBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilderExtension-WhenRemoved(DefaultEcs-EntitySetBuilder_System-Type--)-builder'></a>
`builder` [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder') on which to create the rule.  
  
<a name='DefaultEcs-EntitySetBuilderExtension-WhenRemoved(DefaultEcs-EntitySetBuilder_System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
