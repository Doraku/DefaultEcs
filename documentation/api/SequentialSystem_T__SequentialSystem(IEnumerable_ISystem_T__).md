#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')
## SequentialSystem&lt;T&gt;.SequentialSystem(IEnumerable&lt;ISystem&lt;T&gt;&gt;) Constructor
Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.  
```csharp
public SequentialSystem(System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>> systems);
```
#### Parameters
<a name='DefaultEcs_System_SequentialSystem_T__SequentialSystem(System_Collections_Generic_IEnumerable_DefaultEcs_System_ISystem_T__)_systems'></a>
`systems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](SequentialSystem_T_.md#DefaultEcs_System_SequentialSystem_T__T 'DefaultEcs.System.SequentialSystem&lt;T&gt;.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](SequentialSystem_T__SequentialSystem(IEnumerable_ISystem_T__).md#DefaultEcs_System_SequentialSystem_T__SequentialSystem(System_Collections_Generic_IEnumerable_DefaultEcs_System_ISystem_T__)_systems 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(System.Collections.Generic.IEnumerable&lt;DefaultEcs.System.ISystem&lt;T&gt;&gt;).systems') is null.
