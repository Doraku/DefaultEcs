#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>')

## SequentialSystem(IEnumerable<ISystem<T>>) Constructor

Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>') class.

```csharp
public SequentialSystem(System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>> systems);
```
#### Parameters

<a name='DefaultEcs.System.SequentialSystem_T_.SequentialSystem(System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).systems'></a>

`systems` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](SequentialSystem_T_.md#DefaultEcs.System.SequentialSystem_T_.T 'DefaultEcs.System.SequentialSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](SequentialSystem_T_.SequentialSystem(IEnumerable_ISystem_T__).md#DefaultEcs.System.SequentialSystem_T_.SequentialSystem(System.Collections.Generic.IEnumerable_DefaultEcs.System.ISystem_T__).systems 'DefaultEcs.System.SequentialSystem<T>.SequentialSystem(System.Collections.Generic.IEnumerable<DefaultEcs.System.ISystem<T>>).systems') is null.