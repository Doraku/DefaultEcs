#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## WithPredicateAttribute Class
Makes so when building the inner EntitySet of [AEntitySetSystem&lt;T&gt;](./DefaultEcs-System-AEntitySetSystem-T-.md 'DefaultEcs.System.AEntitySetSystem&lt;T&gt;') when giving a [World](./DefaultEcs-World.md 'DefaultEcs.World') instance, the decorated method will be used as a component predicate.  
The decorated method should be of the type [ComponentPredicate&lt;T&gt;(T)](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  
```csharp
public sealed class WithPredicateAttribute : System.Attribute
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &#129106; WithPredicateAttribute  
