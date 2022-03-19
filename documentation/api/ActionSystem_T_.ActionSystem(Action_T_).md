#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem<T>')

## ActionSystem(Action<T>) Constructor

Initialises a new instance of the [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem<T>') class with the given [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1').

```csharp
public ActionSystem(System.Action<T> action);
```
#### Parameters

<a name='DefaultEcs.System.ActionSystem_T_.ActionSystem(System.Action_T_).action'></a>

`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](ActionSystem_T_.md#DefaultEcs.System.ActionSystem_T_.T 'DefaultEcs.System.ActionSystem<T>.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')

The [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1') to call as update.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](ActionSystem_T_.ActionSystem(Action_T_).md#DefaultEcs.System.ActionSystem_T_.ActionSystem(System.Action_T_).action 'DefaultEcs.System.ActionSystem<T>.ActionSystem(System.Action<T>).action') is null.