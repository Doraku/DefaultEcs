#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityRecord](./DefaultEcs-Command-EntityRecord.md 'DefaultEcs.Command.EntityRecord')
## EntityRecord.Set&lt;T&gt;(T) Method
Sets the value of the component of type [T](#DefaultEcs-Command-EntityRecord-Set-T-(T)-T 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T).T') on the corresponding [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
For a blittable component, this command takes 9 bytes + the size of the component.  
For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.  
```csharp
public void Set<T>(in T component=default(T));
```
#### Type parameters
<a name='DefaultEcs-Command-EntityRecord-Set-T-(T)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-Command-EntityRecord-Set-T-(T)-component'></a>
`component` [T](#DefaultEcs-Command-EntityRecord-Set-T-(T)-T 'DefaultEcs.Command.EntityRecord.Set&lt;T&gt;(T).T')  
The value of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.  
