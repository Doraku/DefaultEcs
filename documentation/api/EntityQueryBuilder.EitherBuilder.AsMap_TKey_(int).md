#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder').[EitherBuilder](EntityQueryBuilder.EitherBuilder.md 'DefaultEcs.EntityQueryBuilder.EitherBuilder')

## EntityQueryBuilder.EitherBuilder.AsMap<TKey>(int) Method

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>') with the specified rules.

```csharp
public DefaultEcs.EntityMap<TKey> AsMap<TKey>(int capacity);
```
#### Type parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap_TKey_(int).TKey'></a>

`TKey`

The component type to use as key.
#### Parameters

<a name='DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap_TKey_(int).capacity'></a>

`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The initial number of element the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>') can contain.

#### Returns
[DefaultEcs.EntityMap&lt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>')[TKey](EntityQueryBuilder.EitherBuilder.AsMap_TKey_(int).md#DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap_TKey_(int).TKey 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap<TKey>(int).TKey')[&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>')  
The [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>').