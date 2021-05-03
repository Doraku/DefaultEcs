#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## WithEitherAttribute Class
Represents a group of component types which at least one should be present when building the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') of [AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](World.md 'DefaultEcs.World') instance.  
```csharp
public sealed class WithEitherAttribute : DefaultEcs.System.ComponentAttribute
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') &#129106; WithEitherAttribute  
### Constructors

***
[WithEitherAttribute(Type[])](WithEitherAttribute_WithEitherAttribute(Type__).md 'DefaultEcs.System.WithEitherAttribute.WithEitherAttribute(System.Type[])')

Initialize a new instance of the [WithEitherAttribute](WithEitherAttribute.md 'DefaultEcs.System.WithEitherAttribute') type.  
