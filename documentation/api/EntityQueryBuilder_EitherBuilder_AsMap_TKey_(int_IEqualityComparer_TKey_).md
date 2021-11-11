#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder_EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')
## EntityQueryBuilder.EitherBuilder.AsMap&lt;TKey&gt;(int, IEqualityComparer&lt;TKey&gt;) Method
Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMap<TKey> AsMap<TKey>(int capacity, System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_System_Collections_Generic_IEqualityComparer_TKey_)_TKey'></a>
`TKey`  
The component type to use as key.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_System_Collections_Generic_IEqualityComparer_TKey_)_capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') can contain.
  
<a name='DefaultEcs_EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_System_Collections_Generic_IEqualityComparer_TKey_)_comparer'></a>
`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_IEqualityComparer_TKey_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_System_Collections_Generic_IEqualityComparer_TKey_)_TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.
  
#### Returns
[DefaultEcs.EntityMap&lt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')[TKey](EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_IEqualityComparer_TKey_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_AsMap_TKey_(int_System_Collections_Generic_IEqualityComparer_TKey_)_TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')  
The [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').
