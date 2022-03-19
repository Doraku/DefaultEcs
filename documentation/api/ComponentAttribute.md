#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System')

## ComponentAttribute Class

Represents the base attribute to declare how to build the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>') when giving a [World](World.md 'DefaultEcs.World') instance.  
Do not use this attribute, prefer [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') instead.

```csharp
public class ComponentAttribute : System.Attribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; ComponentAttribute

Derived  
&#8627; [WhenAddedAttribute](WhenAddedAttribute.md 'DefaultEcs.System.WhenAddedAttribute')  
&#8627; [WhenAddedEitherAttribute](WhenAddedEitherAttribute.md 'DefaultEcs.System.WhenAddedEitherAttribute')  
&#8627; [WhenChangedAttribute](WhenChangedAttribute.md 'DefaultEcs.System.WhenChangedAttribute')  
&#8627; [WhenChangedEitherAttribute](WhenChangedEitherAttribute.md 'DefaultEcs.System.WhenChangedEitherAttribute')  
&#8627; [WhenRemovedAttribute](WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute')  
&#8627; [WhenRemovedEitherAttribute](WhenRemovedEitherAttribute.md 'DefaultEcs.System.WhenRemovedEitherAttribute')  
&#8627; [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute')  
&#8627; [WithEitherAttribute](WithEitherAttribute.md 'DefaultEcs.System.WithEitherAttribute')  
&#8627; [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute')  
&#8627; [WithoutEitherAttribute](WithoutEitherAttribute.md 'DefaultEcs.System.WithoutEitherAttribute')

| Constructors | |
| :--- | :--- |
| [ComponentAttribute(ComponentFilterType, Type[])](ComponentAttribute.ComponentAttribute(ComponentFilterType,Type[]).md 'DefaultEcs.System.ComponentAttribute.ComponentAttribute(DefaultEcs.System.ComponentFilterType, System.Type[])') | Initialize a new instance of the [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') type. |

| Properties | |
| :--- | :--- |
| [ComponentTypes](ComponentAttribute.ComponentTypes.md 'DefaultEcs.System.ComponentAttribute.ComponentTypes') | The types of the component. |
| [FilterType](ComponentAttribute.FilterType.md 'DefaultEcs.System.ComponentAttribute.FilterType') | Whether the component type should be included or excluded. |
