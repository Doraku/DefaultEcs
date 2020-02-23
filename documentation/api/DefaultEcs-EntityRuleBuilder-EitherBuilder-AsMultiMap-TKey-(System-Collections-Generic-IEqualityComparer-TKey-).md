#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder').[EntityRuleBuilder.EitherBuilder](./DefaultEcs-EntityRuleBuilder-EitherBuilder.md 'DefaultEcs.EntityRuleBuilder.EitherBuilder')
## EntityRuleBuilder.EitherBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;) Method
Returns an [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntitiesMap<TKey> AsMultiMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-EitherBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey'></a>
`TKey`  
The component type to use as key.  
  
#### Parameters
<a name='DefaultEcs-EntityRuleBuilder-EitherBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-comparer'></a>
`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](#DefaultEcs-EntityRuleBuilder-EitherBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.EitherBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.  
  
#### Returns
[DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](#DefaultEcs-EntityRuleBuilder-EitherBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.EitherBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;').  
