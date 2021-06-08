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
| [ComponentCloner()](ComponentCloner_ComponentCloner().md 'DefaultEcs.ComponentCloner.ComponentCloner()') | Initialize a new instance of the [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner') type.<br/> |

| Methods | |
| :--- | :--- |
| [Clone(Entity, Entity)](ComponentCloner_Clone(Entity_Entity).md 'DefaultEcs.ComponentCloner.Clone(DefaultEcs.Entity, DefaultEcs.Entity)') | Clones one [Entity](Entity.md 'DefaultEcs.Entity') components to an other.<br/> |
| [OnComponent&lt;T&gt;(T, bool)](ComponentCloner_OnComponent_T_(T_bool).md 'DefaultEcs.ComponentCloner.OnComponent&lt;T&gt;(T, bool)') | Handles the component of type [T](ComponentCloner_OnComponent_T_(T_bool).md#DefaultEcs_ComponentCloner_OnComponent_T_(T_bool)_T 'DefaultEcs.ComponentCloner.OnComponent&lt;T&gt;(T, bool).T') from the source [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [Set&lt;T&gt;(T, bool)](ComponentCloner_Set_T_(T_bool).md 'DefaultEcs.ComponentCloner.Set&lt;T&gt;(T, bool)') | Sets the given component on the copied entity.<br/> |
