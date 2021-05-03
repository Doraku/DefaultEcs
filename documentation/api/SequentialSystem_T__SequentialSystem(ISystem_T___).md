#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')
## SequentialSystem&lt;T&gt;.SequentialSystem(ISystem&lt;T&gt;[]) Constructor
Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.  
```csharp
public SequentialSystem(params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters
<a name='DefaultEcs_System_SequentialSystem_T__SequentialSystem(DefaultEcs_System_ISystem_T___)_systems'></a>
`systems` [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](SequentialSystem_T_.md#DefaultEcs_System_SequentialSystem_T__T 'DefaultEcs.System.SequentialSystem&lt;T&gt;.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](SequentialSystem_T__SequentialSystem(ISystem_T___).md#DefaultEcs_System_SequentialSystem_T__SequentialSystem(DefaultEcs_System_ISystem_T___)_systems 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[]).systems') is null.
