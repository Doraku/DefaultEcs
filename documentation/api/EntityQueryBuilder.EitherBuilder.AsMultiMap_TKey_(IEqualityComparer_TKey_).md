#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.AsMultiMap<TKey>(IEqualityComparer<TKey>) Method

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') with the specified rules.

```csharp
public DefaultEcs.EntityMultiMap<TKey> AsMultiMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(System.Collections.Generic.IEqualityComparer_TKey_).TKey'></a>

`TKey`

The component type to use as key.
#### Parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(System.Collections.Generic.IEqualityComparer_TKey_).comparer'></a>

`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(IEqualityComparer_TKey_).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(System.Collections.Generic.IEqualityComparer_TKey_).TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey>).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')

The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.

#### Returns
[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[TKey](EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(IEqualityComparer_TKey_).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(System.Collections.Generic.IEqualityComparer_TKey_).TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey>).TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')  
The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>').