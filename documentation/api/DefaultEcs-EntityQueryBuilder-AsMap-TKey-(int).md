#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityQueryBuilder](./DefaultEcs-EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.AsMap&lt;TKey&gt;(int) Method
Returns an [EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMap<TKey> AsMap<TKey>(int capacity);
```
#### Type parameters
<a name='DefaultEcs-EntityQueryBuilder-AsMap-TKey-(int)-TKey'></a>
`TKey`  
The component type to use as key.  
  
#### Parameters
<a name='DefaultEcs-EntityQueryBuilder-AsMap-TKey-(int)-capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;') can contain.  
  
#### Returns
[DefaultEcs.EntityMap&lt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;')[TKey](#DefaultEcs-EntityQueryBuilder-AsMap-TKey-(int)-TKey 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(int).TKey')[&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;')  
The [EntityMap&lt;TKey&gt;](./DefaultEcs-EntityMap-TKey-.md 'DefaultEcs.EntityMap&lt;TKey&gt;').  
