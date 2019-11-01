#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;')
## AComponentSystem&lt;TState,TComponent&gt;.IsEnabled Property
Gets or sets whether the current [AComponentSystem&lt;TState,TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState,TComponent&gt;') instance should update or not.  
Will return false if there is no component to update.  
```C#
public sealed override bool IsEnabled { get; set; }
```
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
