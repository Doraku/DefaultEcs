#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## WithPredicate Class
Makes so when building the inner EntitySet of [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') when giving a [World](./DefaultEcs-World.md 'DefaultEcs.World') instance, the decorated method will be used as a component predicate.  
The decorated method should be of the type [ComponentPredicate&lt;T&gt;(T)](./DefaultEcs-ComponentPredicate-T-(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  
```csharp
public sealed class WithPredicate : Attribute
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [System.Attribute](https://docs.microsoft.com/en-us/dotnet/api/System.Attribute 'System.Attribute') &gt; [WithPredicate](./DefaultEcs-System-WithPredicate.md 'DefaultEcs.System.WithPredicate')  
