#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## ComponentAttribute Class
Represents the base attribute to declare how to build the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') when giving a [World](./DefaultEcs-World.md 'DefaultEcs.World') instance.  
Do not use this attribute, prefer [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') instead.  
```csharp
public class ComponentAttribute : System.Attribute
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; ComponentAttribute  

Derived  
&#8627; [WhenAddedAttribute](./DefaultEcs-System-WhenAddedAttribute.md 'DefaultEcs.System.WhenAddedAttribute')  
&#8627; [WhenAddedEitherAttribute](./DefaultEcs-System-WhenAddedEitherAttribute.md 'DefaultEcs.System.WhenAddedEitherAttribute')  
&#8627; [WhenChangedAttribute](./DefaultEcs-System-WhenChangedAttribute.md 'DefaultEcs.System.WhenChangedAttribute')  
&#8627; [WhenChangedEitherAttribute](./DefaultEcs-System-WhenChangedEitherAttribute.md 'DefaultEcs.System.WhenChangedEitherAttribute')  
&#8627; [WhenRemovedAttribute](./DefaultEcs-System-WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute')  
&#8627; [WhenRemovedEitherAttribute](./DefaultEcs-System-WhenRemovedEitherAttribute.md 'DefaultEcs.System.WhenRemovedEitherAttribute')  
&#8627; [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute')  
&#8627; [WithEitherAttribute](./DefaultEcs-System-WithEitherAttribute.md 'DefaultEcs.System.WithEitherAttribute')  
&#8627; [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute')  
&#8627; [WithoutEitherAttribute](./DefaultEcs-System-WithoutEitherAttribute.md 'DefaultEcs.System.WithoutEitherAttribute')  
### Constructors
- [ComponentAttribute(DefaultEcs.System.ComponentFilterType, System.Type[])](./DefaultEcs-System-ComponentAttribute-ComponentAttribute(DefaultEcs-System-ComponentFilterType_System-Type--).md 'DefaultEcs.System.ComponentAttribute.ComponentAttribute(DefaultEcs.System.ComponentFilterType, System.Type[])')
### Fields
- [ComponentTypes](./DefaultEcs-System-ComponentAttribute-ComponentTypes.md 'DefaultEcs.System.ComponentAttribute.ComponentTypes')
- [FilterType](./DefaultEcs-System-ComponentAttribute-FilterType.md 'DefaultEcs.System.ComponentAttribute.FilterType')
