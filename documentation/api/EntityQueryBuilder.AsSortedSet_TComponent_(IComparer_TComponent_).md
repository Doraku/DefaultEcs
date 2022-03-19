#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')

## EntityQueryBuilder.AsSortedSet<TComponent>(IComparer<TComponent>) Method

Returns an [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>') with the specified rules.

```csharp
public DefaultEcs.EntitySortedSet<TComponent> AsSortedSet<TComponent>(System.Collections.Generic.IComparer<TComponent> comparer);
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.AsSortedSet_TComponent_(System.Collections.Generic.IComparer_TComponent_).TComponent'></a>

`TComponent`

The component type by which [Entity](Entity.md 'DefaultEcs.Entity') will be sorted.
#### Parameters

<a name='DefaultEcs.EntityQueryBuilder.AsSortedSet_TComponent_(System.Collections.Generic.IComparer_TComponent_).comparer'></a>

`comparer` [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[TComponent](EntityQueryBuilder.AsSortedSet_TComponent_(IComparer_TComponent_).md#DefaultEcs.EntityQueryBuilder.AsSortedSet_TComponent_(System.Collections.Generic.IComparer_TComponent_).TComponent 'DefaultEcs.EntityQueryBuilder.AsSortedSet<TComponent>(System.Collections.Generic.IComparer<TComponent>).TComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')

The custom [System.Collections.Generic.IComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1') to use to sort [Entity](Entity.md 'DefaultEcs.Entity').

#### Returns
[DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')[TComponent](EntityQueryBuilder.AsSortedSet_TComponent_(IComparer_TComponent_).md#DefaultEcs.EntityQueryBuilder.AsSortedSet_TComponent_(System.Collections.Generic.IComparer_TComponent_).TComponent 'DefaultEcs.EntityQueryBuilder.AsSortedSet<TComponent>(System.Collections.Generic.IComparer<TComponent>).TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>')  
The [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet<TComponent>').