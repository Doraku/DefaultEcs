#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## AEntityBufferedSystem&lt;T&gt; Class
Represents a base class to process updates on a given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') instance.  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances are buffered in a rented array from [System.Buffers.ArrayPool&lt;&gt;.Shared](https://docs.microsoft.com/en-us/dotnet/api/System.Buffers.ArrayPool-1.Shared 'System.Buffers.ArrayPool`1.Shared') so structural modification are possible without the use of a [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
The updates are single threaded, all [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') operations are safe.  
```csharp
public abstract class AEntityBufferedSystem<T> :
ISystem<T>,
IDisposable
```
Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntityBufferedSystem&lt;T&gt;  

Implements [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](#DefaultEcs-System-AEntityBufferedSystem-T--T 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
#### Type parameters
<a name='DefaultEcs-System-AEntityBufferedSystem-T--T'></a>
`T`  
The type of the object used as state to update the system.  
  
### Constructors
- [AEntityBufferedSystem(DefaultEcs.EntitySet)](./DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-EntitySet).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.AEntityBufferedSystem(DefaultEcs.EntitySet)')
- [AEntityBufferedSystem(DefaultEcs.World)](./DefaultEcs-System-AEntityBufferedSystem-T--AEntityBufferedSystem(DefaultEcs-World).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.AEntityBufferedSystem(DefaultEcs.World)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntityBufferedSystem-T--IsEnabled.md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AEntityBufferedSystem-T--Dispose().md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.Dispose()')
- [PostUpdate(T)](./DefaultEcs-System-AEntityBufferedSystem-T--PostUpdate(T).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.PostUpdate(T)')
- [PreUpdate(T)](./DefaultEcs-System-AEntityBufferedSystem-T--PreUpdate(T).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.PreUpdate(T)')
- [Update(T)](./DefaultEcs-System-AEntityBufferedSystem-T--Update(T).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.Update(T)')
- [Update(T, DefaultEcs.Entity)](./DefaultEcs-System-AEntityBufferedSystem-T--Update(T_DefaultEcs-Entity).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.Update(T, DefaultEcs.Entity)')
- [Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntityBufferedSystem-T--Update(T_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntityBufferedSystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
