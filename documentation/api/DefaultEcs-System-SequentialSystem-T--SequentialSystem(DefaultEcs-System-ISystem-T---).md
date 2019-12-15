#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](./DefaultEcs-System-SequentialSystem-T-.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;')
## SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[]) Constructor
Initialises a new instance of the [SequentialSystem&lt;T&gt;](./DefaultEcs-System-SequentialSystem-T-.md 'DefaultEcs.System.SequentialSystem&lt;T&gt;') class.  
```C#
public SequentialSystem(params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters
<a name='DefaultEcs-System-SequentialSystem-T--SequentialSystem(DefaultEcs-System-ISystem-T---)-systems'></a>
`systems` [DefaultEcs.System.ISystem&lt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[T](./DefaultEcs-System-SequentialSystem-T-.md#DefaultEcs-System-SequentialSystem-T--T 'DefaultEcs.System.SequentialSystem&lt;T&gt;.T')[&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')  
The [ISystem&lt;T&gt;](./DefaultEcs-System-ISystem-T-.md 'DefaultEcs.System.ISystem&lt;T&gt;') instances.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](#DefaultEcs-System-SequentialSystem-T--SequentialSystem(DefaultEcs-System-ISystem-T---)-systems 'DefaultEcs.System.SequentialSystem&lt;T&gt;.SequentialSystem(DefaultEcs.System.ISystem&lt;T&gt;[]).systems') is null.  
