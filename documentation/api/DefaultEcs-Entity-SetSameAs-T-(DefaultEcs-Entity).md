#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity) Method
Sets the value of the component of type [T](#DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-T 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity).T') on the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```C#
public void SetSameAs<T>(in DefaultEcs.Entity reference);
```
#### Type parameters
<a name='DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-T'></a>
`T`  
The type of the component.  
#### Parameters
<a name='DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-reference'></a>
reference [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The other [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') used as reference.  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').  
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Reference [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') comes from a different [World](./DefaultEcs-World.md 'DefaultEcs.World').  
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Reference [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') does not have a component of type [T](#DefaultEcs-Entity-SetSameAs-T-(DefaultEcs-Entity)-T 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity).T').  
