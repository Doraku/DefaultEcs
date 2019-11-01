#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.Enable&lt;T&gt;() Method
Enables the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') component of type [T](#DefaultEcs-Entity-Enable-T-()-T 'DefaultEcs.Entity.Enable&lt;T&gt;().T') so it can appear in [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') does not have a component of type [T](#DefaultEcs-Entity-Enable-T-()-T 'DefaultEcs.Entity.Enable&lt;T&gt;().T').  
```C#
public void Enable<T>();
```
#### Type parameters
<a name='DefaultEcs-Entity-Enable-T-()-T'></a>
`T`  
The type of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').  
