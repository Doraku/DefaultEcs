#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System')
## SequentialSystem&lt;T&gt; Class
Represents a collection of [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') to update sequentially.  
```C#
public sealed class SequentialSystem<T>
```
#### Type parameters
<a name='DefaultEcs-System-SequentialSystem-T--T'></a>
`T`  
The type of the object used as state to update the systems.  
### Constructors
- [SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[])](./DefaultEcs-System-SequentialSystem-T--SequentialSystem(DefaultEcs-System-ISystem-T---).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[])')
- [SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)](./DefaultEcs-System-SequentialSystem-T--SequentialSystem(System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-SequentialSystem-T--IsEnabled.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-SequentialSystem-T--Dispose().md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.Dispose()')
- [Update(T)](./DefaultEcs-System-SequentialSystem-T--Update(T).md 'DefaultEcs.System.SequentialSystem&lt;T&gt;.Update(T)')
