#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySetBuilderExtension](./DefaultEcs-EntitySetBuilderExtension.md 'DefaultEcs.EntitySetBuilderExtension')
## EntitySetBuilderExtension.WhenChangedEither&lt;T1,T2&gt;(DefaultEcs.EntitySetBuilder) Method
Makes a rule to obsverve [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') when at least one component of type [T1](#DefaultEcs-EntitySetBuilderExtension-WhenChangedEither-T1_T2-(DefaultEcs-EntitySetBuilder)-T1 'DefaultEcs.EntitySetBuilderExtension.WhenChangedEither&lt;T1,T2&gt;(DefaultEcs.EntitySetBuilder).T1') or [T2](#DefaultEcs-EntitySetBuilderExtension-WhenChangedEither-T1_T2-(DefaultEcs-EntitySetBuilder)-T2 'DefaultEcs.EntitySetBuilderExtension.WhenChangedEither&lt;T1,T2&gt;(DefaultEcs.EntitySetBuilder).T2') is changed.  
```C#
public static DefaultEcs.EntitySetBuilder WhenChangedEither<T1,T2>(this DefaultEcs.EntitySetBuilder builder);
```
#### Type parameters
<a name='DefaultEcs-EntitySetBuilderExtension-WhenChangedEither-T1_T2-(DefaultEcs-EntitySetBuilder)-T1'></a>
`T1`  
The first type of component.  
  
<a name='DefaultEcs-EntitySetBuilderExtension-WhenChangedEither-T1_T2-(DefaultEcs-EntitySetBuilder)-T2'></a>
`T2`  
The second type of component.  
  
#### Parameters
<a name='DefaultEcs-EntitySetBuilderExtension-WhenChangedEither-T1_T2-(DefaultEcs-EntitySetBuilder)-builder'></a>
`builder` [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder') on which to create the rule.  
  
#### Returns
[EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder')  
The given [EntitySetBuilder](./DefaultEcs-EntitySetBuilder.md 'DefaultEcs.EntitySetBuilder').  
