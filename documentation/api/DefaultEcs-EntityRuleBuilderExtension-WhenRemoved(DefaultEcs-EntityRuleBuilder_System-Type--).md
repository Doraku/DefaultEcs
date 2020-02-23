#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilderExtension](./DefaultEcs-EntityRuleBuilderExtension.md 'DefaultEcs.EntityRuleBuilderExtension')
## EntityRuleBuilderExtension.WhenRemoved(DefaultEcs.EntityRuleBuilder, System.Type[]) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when all component of the given types are removed.  
```csharp
public static DefaultEcs.EntityRuleBuilder WhenRemoved(this DefaultEcs.EntityRuleBuilder builder, params System.Type[] componentTypes);
```
#### Parameters
<a name='DefaultEcs-EntityRuleBuilderExtension-WhenRemoved(DefaultEcs-EntityRuleBuilder_System-Type--)-builder'></a>
`builder` [EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')  
The [EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder') on which to create the rule.  
  
<a name='DefaultEcs-EntityRuleBuilderExtension-WhenRemoved(DefaultEcs-EntityRuleBuilder_System-Type--)-componentTypes'></a>
`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The types of component.  
  
#### Returns
[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')  
The current [EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder').  
