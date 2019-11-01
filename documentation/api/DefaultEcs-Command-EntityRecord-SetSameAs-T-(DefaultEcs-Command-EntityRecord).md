#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.SetSameAs&lt;T&gt;(DefaultEcs.Command.EntityRecord) Method
Sets the value of the component of type [T](#DefaultEcs-Command-EntityRecord-SetSameAs-T-(DefaultEcs-Command-EntityRecord)-T 'DefaultEcs.Command.EntityRecord.SetSameAs&lt;T&gt;(DefaultEcs.Command.EntityRecord).T') on the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to the same instance of an other [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord').  
This command takes 13 bytes.  
```C#
public void SetSameAs<T>(in DefaultEcs.Command.EntityRecord reference);
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-SetSameAs-T-(DefaultEcs-Command-EntityRecord)-T'></a>
`T`  
The type of the component.  
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-SetSameAs-T-(DefaultEcs-Command-EntityRecord)-reference'></a>
reference [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')  
The other [EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord') used as reference.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
