#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[ActionSystem&lt;T&gt;](./DefaultEcs-System-ActionSystem-T-.md 'DefaultEcs.System.ActionSystem&lt;T&gt;')
## ActionSystem(System.Action&lt;T&gt;) Constructor
Initialises a new instance of the [ActionSystem&lt;T&gt;](./DefaultEcs-System-ActionSystem-T-.md 'DefaultEcs.System.ActionSystem&lt;T&gt;') class with the given [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1').  
```csharp
public ActionSystem(System.Action<T> action);
```
#### Parameters
<a name='DefaultEcs-System-ActionSystem-T--ActionSystem(System-Action-T-)-action'></a>
`action` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')[T](./DefaultEcs-System-ActionSystem-T-.md#DefaultEcs-System-ActionSystem-T--T 'DefaultEcs.System.ActionSystem&lt;T&gt;.T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1')  
The [System.Action&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-1 'System.Action`1') to call as update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[action](#DefaultEcs-System-ActionSystem-T--ActionSystem(System-Action-T-)-action 'DefaultEcs.System.ActionSystem&lt;T&gt;.ActionSystem(System.Action&lt;T&gt;).action') is null.  
