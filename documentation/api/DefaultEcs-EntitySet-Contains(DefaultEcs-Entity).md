#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet')
## EntitySet.Contains(DefaultEcs.Entity) Method
Determines whether an [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') is in the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
```C#
public bool Contains(in DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs-EntitySet-Contains(DefaultEcs-Entity)-entity'></a>
`entity` [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') to locate in the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if [entity](#DefaultEcs-EntitySet-Contains(DefaultEcs-Entity)-entity 'DefaultEcs.EntitySet.Contains(DefaultEcs.Entity).entity') is found in the [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'); otherwise, false.  
