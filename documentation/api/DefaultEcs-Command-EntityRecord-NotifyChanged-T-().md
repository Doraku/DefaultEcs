#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.NotifyChanged&lt;T&gt;() Method
Notifies the value of the component of type [T](#DefaultEcs-Command-EntityRecord-NotifyChanged-T-()-T 'DefaultEcs.Command.EntityRecord.NotifyChanged&lt;T&gt;().T') has changed on the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  
```csharp
public void NotifyChanged<T>();
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-NotifyChanged-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
