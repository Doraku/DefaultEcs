#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.AsMap&lt;TKey&gt;(IEqualityComparer&lt;TKey&gt;) Method
Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMap<TKey> AsMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMap_TKey_(System_Collections_Generic_IEqualityComparer_TKey_)_TKey'></a>
`TKey`  
The component type to use as key.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMap_TKey_(System_Collections_Generic_IEqualityComparer_TKey_)_comparer'></a>
`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](EntityQueryBuilder_AsMap_TKey_(IEqualityComparer_TKey_).md#DefaultEcs_EntityQueryBuilder_AsMap_TKey_(System_Collections_Generic_IEqualityComparer_TKey_)_TKey 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.
  
#### Returns
[DefaultEcs.EntityMap&lt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')[TKey](EntityQueryBuilder_AsMap_TKey_(IEqualityComparer_TKey_).md#DefaultEcs_EntityQueryBuilder_AsMap_TKey_(System_Collections_Generic_IEqualityComparer_TKey_)_TKey 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')  
The [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').
