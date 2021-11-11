#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.AsSortedSet&lt;TComponent&gt;(IComparer&lt;TComponent&gt;) Method
Returns an [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntitySortedSet<TComponent> AsSortedSet<TComponent>(System.Collections.Generic.IComparer<TComponent> comparer);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(System_Collections_Generic_IComparer_TComponent_)_TComponent'></a>
`TComponent`  
The component type by which [Entity](Entity.md 'DefaultEcs.Entity') will be sorted.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(System_Collections_Generic_IComparer_TComponent_)_comparer'></a>
`comparer` [System.Collections.Generic.IComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')[TComponent](EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(IComparer_TComponent_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(System_Collections_Generic_IComparer_TComponent_)_TComponent 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsSortedSet&lt;TComponent&gt;(System.Collections.Generic.IComparer&lt;TComponent&gt;).TComponent')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1')  
The custom [System.Collections.Generic.IComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IComparer-1 'System.Collections.Generic.IComparer`1') to use to sort [Entity](Entity.md 'DefaultEcs.Entity').
  
#### Returns
[DefaultEcs.EntitySortedSet&lt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')[TComponent](EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(IComparer_TComponent_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_AsSortedSet_TComponent_(System_Collections_Generic_IComparer_TComponent_)_TComponent 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsSortedSet&lt;TComponent&gt;(System.Collections.Generic.IComparer&lt;TComponent&gt;).TComponent')[&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;')  
The [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').
