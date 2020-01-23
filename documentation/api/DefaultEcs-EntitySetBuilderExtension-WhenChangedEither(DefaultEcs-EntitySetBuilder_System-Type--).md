#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilderExtension](./DefaultEcs-EntitySetBuilderExtension.md 'DefaultEcs.EntitySetBuilderExtension')
## EntitySetBuilderExtension.WhenChangedEither(DefaultEcs.EntitySetBuilder, System.Type[]) Method
Makes a rule to observe [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when one component of the given types is changed.  
```csharp
public static DefaultEcs.EntitySetBuilder WhenChangedEither(this DefaultEcs.EntitySetBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntitySetBuilderExtension-WhenChangedEither(DefaultEcs-EntitySetBuilder_System-Type--)-builder'></a>
`builder` [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder') on which to create the rule.  
  
<a name='DefaultEcs-EntitySetBuilderExtension-WhenChangedEither(DefaultEcs-EntitySetBuilder_System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The current [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
