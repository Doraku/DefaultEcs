#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[EntityRuleBuilder](./DefaultEcs-EntityRuleBuilder.md 'DefaultEcs.EntityRuleBuilder')
## EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;) Method
Returns an [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  
```csharp
public DefaultEcs.EntityMultiMap<TKey> AsMultiMap<TKey>(System.Collections.Generic.IEqualityComparer<TKey> comparer);
```
#### Type parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey'></a>
`TKey`  
The component type to use as key.  
  
#### Parameters
<a name='DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-comparer'></a>
`comparer` [System.Collections.Generic.IEqualityComparer&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')[TKey](#DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1')  
The [System.Collections.Generic.IEqualityComparer&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEqualityComparer-1 'System.Collections.Generic.IEqualityComparer`1') implementation to use when comparing keys, or null to use the default [System.Collections.Generic.EqualityComparer&lt;&gt;.Default](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.EqualityComparer-1.Default 'System.Collections.Generic.EqualityComparer`1.Default') for the type of the key.  
  
#### Returns
[DefaultEcs.EntityMultiMap&lt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](#DefaultEcs-EntityRuleBuilder-AsMultiMap-TKey-(System-Collections-Generic-IEqualityComparer-TKey-)-TKey 'DefaultEcs.EntityRuleBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;).TKey')[&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
The [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  
