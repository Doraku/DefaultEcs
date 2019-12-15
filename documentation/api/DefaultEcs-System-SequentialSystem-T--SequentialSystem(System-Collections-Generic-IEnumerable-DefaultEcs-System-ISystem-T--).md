#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](./DefaultEcs-System-SequentialSystem-T-.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')
## SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;) Constructor
Initialises a new instance of the [SequentialSystem&lt;T&gt;](./DefaultEcs-System-SequentialSystem-T-.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.  
```C#
public SequentialSystem(System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>> systems);
```
#### Parameters
<a name='DefaultEcs-System-SequentialSystem-T--SequentialSystem(System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-systems'></a>
`systems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-SequentialSystem-T-.md#DefaultEcs-System-SequentialSystem-T--T 'DefaultEcs.System.SequentialSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](#DefaultEcs-System-SequentialSystem-T--SequentialSystem(System-Collections-Generic-IEnumerable-DefaultEcs-System-ISystem-T--)-systems 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;).systems') is null.  
