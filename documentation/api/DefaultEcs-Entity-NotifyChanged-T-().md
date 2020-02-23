#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.NotifyChanged&lt;T&gt;() Method
Notifies the value of the component of type [T](#DefaultEcs-Entity-NotifyChanged-T-()-T 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;().T') has changed.  
```csharp
public void NotifyChanged<T>();
```
#### Type parameters
<a name='DefaultEcs-Entity-NotifyChanged-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').  
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') does not have a component of type [T](#DefaultEcs-Entity-NotifyChanged-T-()-T 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;().T').  
