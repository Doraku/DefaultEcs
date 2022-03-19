#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')

## EntitySortedSet<TComponent>.Contains(Entity) Method

Determines whether the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains a specific [Entity](Entity.md 'DefaultEcs.Entity').

```csharp
public bool Contains(in DefaultEcs.Entity entity);
```
#### Parameters

<a name='DefaultEcs.EntitySortedSet_TComponent_.Contains(DefaultEcs.Entity).entity'></a>

`entity` [Entity](Entity.md 'DefaultEcs.Entity')

The [Entity](Entity.md 'DefaultEcs.Entity') to locate in the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer').

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the [DefaultEcs.IEntityContainer](https://docs.microsoft.com/en-us/dotnet/api/DefaultEcs.IEntityContainer 'DefaultEcs.IEntityContainer') contains the specified [Entity](Entity.md 'DefaultEcs.Entity'); otherwise, false.