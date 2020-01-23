#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.SetAsChildOf(DefaultEcs.Entity) Method
Makes it so when given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is disposed, current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') will also be disposed.  
```csharp
public void SetAsChildOf(in DefaultEcs.Entity parent);
```
#### Parameters
<a name='DefaultEcs-Entity-SetAsChildOf(DefaultEcs-Entity)-parent'></a>
`parent` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') which acts as parent.  
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') was not created from a [World](./DefaultEcs-World.md 'DefaultEcs.World').  
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Child and parent [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') come from a different [World](./DefaultEcs-World.md 'DefaultEcs.World').  
