#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Enable&lt;T&gt;() Method
Enables the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') component of type [T](#DefaultEcs-Command-EntityRecord-Enable-T-()-T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T') so it can appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') does not have a component of type [T](#DefaultEcs-Command-EntityRecord-Enable-T-()-T 'DefaultEcs.Command.EntityRecord.Enable&lt;T&gt;().T').  
This command takes 9 bytes.  
```C#
public void Enable<T>();
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-Enable-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
