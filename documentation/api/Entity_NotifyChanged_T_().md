#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.NotifyChanged&lt;T&gt;() Method
Notifies the value of the component of type [T](Entity_NotifyChanged_T_().md#DefaultEcs_Entity_NotifyChanged_T_()_T 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;().T') has changed.  
```csharp
public void NotifyChanged<T>();
```
#### Type parameters
<a name='DefaultEcs_Entity_NotifyChanged_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity_NotifyChanged_T_().md#DefaultEcs_Entity_NotifyChanged_T_()_T 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;().T').
