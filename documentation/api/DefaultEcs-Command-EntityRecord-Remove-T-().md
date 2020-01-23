#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Remove&lt;T&gt;() Method
Removes the component of type [T](#DefaultEcs-Command-EntityRecord-Remove-T-()-T 'DefaultEcs.Command.EntityRecord.Remove&lt;T&gt;().T') on the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.  
```csharp
public void Remove<T>();
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-Remove-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
