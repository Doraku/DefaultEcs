#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.AsMultiMap<TKey>(int) Method

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') with the specified rules.

```csharp
public DefaultEcs.EntityMultiMap<TKey> AsMultiMap<TKey>(int capacity);
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(int).TKey'></a>

`TKey`

The component type to use as key.
#### Parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(int).capacity'></a>

`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The initial number of element the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>') can contain.

#### Returns
[DefaultEcs.EntityMultiMap&lt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')[TKey](EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(int).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap_TKey_(int).TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap<TKey>(int).TKey')[&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>')  
The [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap<TKey>').