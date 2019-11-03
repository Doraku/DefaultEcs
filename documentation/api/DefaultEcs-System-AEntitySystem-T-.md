#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntitySystem&lt;T&gt; Class
Represents a base class to process updates on a given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') instance.  
```C#
public abstract class AEntitySystem<T> : ASystem<T>
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &gt; [DefaultEcs.System.ASystem&lt;](./DefaultEcs-System-ASystem-T-.md 'DefaultEcs.System.ASystem&lt;T&gt;')[T](#DefaultEcs-System-AEntitySystem-T--T 'DefaultEcs.System.AEntitySystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ASystem-T-.md 'DefaultEcs.System.ASystem&lt;T&gt;') &gt; [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')  
#### Type parameters
<a name='DefaultEcs-System-AEntitySystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Constructors
- [AEntitySystem(DefaultEcs.EntitySet)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet)')
- [AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-EntitySet_DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;)')
- [AEntitySystem(DefaultEcs.World)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World)')
- [AEntitySystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-AEntitySystem-T--AEntitySystem(DefaultEcs-World_DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.AEntitySystem(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntitySystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AEntitySystem-T--Dispose().md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Dispose()')
- [PostUpdate(T)](./DefaultEcs-System-AEntitySystem-T--PostUpdate(T).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.PostUpdate(T)')
- [Update(T, DefaultEcs.Entity)](./DefaultEcs-System-AEntitySystem-T--Update(T_DefaultEcs-Entity).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, DefaultEcs.Entity)')
- [Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntitySystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
### Events
- [EntityAdded](./DefaultEcs-System-AEntitySystem-T--EntityAdded.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.EntityAdded')
- [EntityRemoved](./DefaultEcs-System-AEntitySystem-T--EntityRemoved.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.EntityRemoved')
