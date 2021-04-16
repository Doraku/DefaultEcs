#### [DefaultEcs](index.md 'index')
### [DefaultEcs.System](index.md#DefaultEcs_System 'DefaultEcs.System').[ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')
## ActionSystem&lt;T&gt;.ActionSystem(Action&lt;T&gt;) Constructor
Initialises a new instance of the [ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem&lt;T&gt;') class with the given [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1').  
```csharp
public ActionSystem(System.Action<T> action);
```
#### Parameters
<a name='DefaultEcs_System_ActionSystem_T__ActionSystem(System_Action_T_)_action'></a>
`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](ActionSystem_T_.md#DefaultEcs_System_ActionSystem_T__T 'DefaultEcs.System.ActionSystem&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')  
The [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1') to call as update.
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](ActionSystem_T__ActionSystem(Action_T_).md#DefaultEcs_System_ActionSystem_T__ActionSystem(System_Action_T_)_action 'DefaultEcs.System.ActionSystem&lt;T&gt;.ActionSystem(System.Action&lt;T&gt;).action') is null.
