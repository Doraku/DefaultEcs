#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')
## Entity.Dispose() Method
Clean the current [Entity](Entity.md 'DefaultEcs.Entity') of all its components.  
The current [Entity](Entity.md 'DefaultEcs.Entity') should not be used again after calling this method and [IsAlive](Entity_IsAlive.md 'DefaultEcs.Entity.IsAlive') will return false.  
```csharp
public void Dispose();
```
