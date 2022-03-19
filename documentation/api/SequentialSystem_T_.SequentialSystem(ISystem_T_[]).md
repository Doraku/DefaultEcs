#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>')

## SequentialSystem(ISystem<T>[]) Constructor

Initialises a new instance of the [SequentialSystem&lt;T&gt;](SequentialSystem_T_.md 'DefaultEcs.System.SequentialSystem<T>') class.

```csharp
public SequentialSystem(params DefaultEcs.System.ISystem<T>[] systems);
```
#### Parameters

<a name='DefaultEcs.System.SequentialSystem_T_.SequentialSystem(DefaultEcs.System.ISystem_T_[]).systems'></a>

`systems` [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[T](SequentialSystem_T_.md#DefaultEcs.System.SequentialSystem_T_.T 'DefaultEcs.System.SequentialSystem<T>.T')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The [ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>') instances.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[systems](SequentialSystem_T_.SequentialSystem(ISystem_T_[]).md#DefaultEcs.System.SequentialSystem_T_.SequentialSystem(DefaultEcs.System.ISystem_T_[]).systems 'DefaultEcs.System.SequentialSystem<T>.SequentialSystem(DefaultEcs.System.ISystem<T>[]).systems') is null.