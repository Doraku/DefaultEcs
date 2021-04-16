#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.AsMap&lt;TKey&gt;(int) Method
Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMap<TKey> AsMap<TKey>(int capacity);
```
#### Type parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMap_TKey_(int)_TKey'></a>
`TKey`  
The component type to use as key.
  
#### Parameters
<a name='DefaultEcs_EntityQueryBuilder_AsMap_TKey_(int)_capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') can contain.
  
#### Returns
[DefaultEcs.EntityMap&lt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')[TKey](EntityQueryBuilder_AsMap_TKey_(int).md#DefaultEcs_EntityQueryBuilder_AsMap_TKey_(int)_TKey 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(int).TKey')[&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;')  
The [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;').
