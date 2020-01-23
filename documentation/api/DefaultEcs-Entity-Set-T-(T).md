#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.Set&lt;T&gt;(T) Method
Sets the value of the component of type [T](#DefaultEcs-Entity-Set-T-(T)-T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T') on the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
```csharp
public void Set<T>(in T component=default(ref T));
```
#### Type parameters
<a name='DefaultEcs-Entity-Set-T-(T)-T'></a>
`T`  
The type of the component.  
  
#### Parameters
<a name='DefaultEcs-Entity-Set-T-(T)-component'></a>
`component` [T](#DefaultEcs-Entity-Set-T-(T)-T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T')  
The value of the component.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').  
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](#DefaultEcs-Entity-Set-T-(T)-T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T') reached.  
