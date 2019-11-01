#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Disable&lt;T&gt;() Method
Disables the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') component of type [T](#DefaultEcs-Command-EntityRecord-Disable-T-()-T 'DefaultEcs.Command.EntityRecord.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 9 bytes.  
```C#
public void Disable<T>();
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-Disable-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
