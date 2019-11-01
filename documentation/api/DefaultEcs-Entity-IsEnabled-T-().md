#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.IsEnabled&lt;T&gt;() Method
Gets whether the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') component of type [T](#DefaultEcs-Entity-IsEnabled-T-()-T 'DefaultEcs.Entity.IsEnabled&lt;T&gt;().T') is enabled or not.  
```C#
public bool IsEnabled<T>();
```
#### Type parameters
<a name='DefaultEcs-Entity-IsEnabled-T-()-T'></a>
`T`  
The type of the component.  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') has a component of type [T](#DefaultEcs-Entity-IsEnabled-T-()-T 'DefaultEcs.Entity.IsEnabled&lt;T&gt;().T') enabled; otherwise, false.  
