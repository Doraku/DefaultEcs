#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;) Method
Returns an [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntitiesMap<TKey> AsMultiMap<TKey>(int capacity, System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int_System-Collections-Generic-IEqualityComparer-TKey-)-TKey'></a>
`TKey`  
The component type to use as key.  
  
#### Parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int_System-Collections-Generic-IEqualityComparer-TKey-)-capacity'></a>
`capacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The initial number of element the [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') can contain.  
  
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int_System-Collections-Generic-IEqualityComparer-TKey-)-comparer'></a>
`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](#DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int_System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.  
  
#### Returns
[DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](#DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(int_System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;').  
