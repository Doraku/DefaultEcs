#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentCloner Class

Exposes a way to clone one [Entity](Entity.md 'DefaultEcs.Entity') components to an other.

```csharp
public class ComponentCloner
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ComponentCloner

| Constructors | |
| :--- | :--- |
| [ComponentCloner()](ComponentCloner.ComponentCloner().md 'DefaultEcs.ComponentCloner.ComponentCloner()') | Initialize a new instance of the [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') type. |

| Methods | |
| :--- | :--- |
| [Clone(Entity, Entity)](ComponentCloner.Clone(Entity,Entity).md 'DefaultEcs.ComponentCloner.Clone(DefaultEcs.Entity, DefaultEcs.Entity)') | Clones one [Entity](Entity.md 'DefaultEcs.Entity') components to an other. |
| [OnComponent&lt;T&gt;(T, bool)](ComponentCloner.OnComponent_T_(T,bool).md 'DefaultEcs.ComponentCloner.OnComponent<T>(T, bool)') | Handles the component of type [T](ComponentCloner.OnComponent_T_(T,bool).md#DefaultEcs.ComponentCloner.OnComponent_T_(T,bool).T 'DefaultEcs.ComponentCloner.OnComponent<T>(T, bool).T') from the source [Entity](Entity.md 'DefaultEcs.Entity'). |
| [Set&lt;T&gt;(T, bool)](ComponentCloner.Set_T_(T,bool).md 'DefaultEcs.ComponentCloner.Set<T>(T, bool)') | Sets the given component on the copied entity. |
