#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')
## Entity.Dispose() Method
Clean the current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') of all its components.  
The current [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') should not be used again after calling this method and [IsAlive](./DefaultEcs-Entity-IsAlive.md 'DefaultEcs.Entity.IsAlive') will return false.  
```C#
public void Dispose();
```
