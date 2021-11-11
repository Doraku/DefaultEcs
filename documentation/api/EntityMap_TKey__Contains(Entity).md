#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')
## EntityMap&lt;TKey&gt;.Contains(Entity) Method
Determines whether the [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public bool Contains(in DefaultEcs.Entity entity);
```
#### Parameters
<a name='DefaultEcs_EntityMap_TKey__Contains(DefaultEcs_Entity)_entity'></a>
`entity` [Entity](Entity.md 'DefaultEcs.Entity')  
The [Entity](Entity.md 'DefaultEcs.Entity') to locate in the [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer').
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [IEntityContainer](IEntityContainer.md 'DefaultEcs.IEntityContainer') contains the specified [Entity](Entity.md 'DefaultEcs.Entity'); otherwise, false.
