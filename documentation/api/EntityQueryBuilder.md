#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## EntityQueryBuilder Class
Represent an helper object to create rules to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public sealed class EntityQueryBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EntityQueryBuilder  
### Methods

***
[AsEnumerable()](EntityQueryBuilder_AsEnumerable().md 'DefaultEcs.EntityQueryBuilder.AsEnumerable()')

Returns an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') of [Entity](Entity.md 'DefaultEcs.Entity') with the specified rules.  

***
[AsMap&lt;TKey&gt;()](EntityQueryBuilder_AsMap_TKey_().md 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;()')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMap&lt;TKey&gt;(IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_AsMap_TKey_(IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMap&lt;TKey&gt;(int)](EntityQueryBuilder_AsMap_TKey_(int).md 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(int)')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMap&lt;TKey&gt;(int, IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_AsMap_TKey_(int_IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.AsMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;()](EntityQueryBuilder_AsMultiMap_TKey_().md 'DefaultEcs.EntityQueryBuilder.AsMultiMap&lt;TKey&gt;()')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;(IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_AsMultiMap_TKey_(IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;(int)](EntityQueryBuilder_AsMultiMap_TKey_(int).md 'DefaultEcs.EntityQueryBuilder.AsMultiMap&lt;TKey&gt;(int)')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;(int, IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_AsMultiMap_TKey_(int_IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.AsMultiMap&lt;TKey&gt;(int, System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsPredicate()](EntityQueryBuilder_AsPredicate().md 'DefaultEcs.EntityQueryBuilder.AsPredicate()')

Returns a [System.Predicate&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1') representing the specified rules.  

***
[AsSet()](EntityQueryBuilder_AsSet().md 'DefaultEcs.EntityQueryBuilder.AsSet()')

Returns an [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') with the specified rules.  

***
[Copy()](EntityQueryBuilder_Copy().md 'DefaultEcs.EntityQueryBuilder.Copy()')

Copies all the rules of the current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') to a new instance.  

***
[WhenAdded&lt;T&gt;()](EntityQueryBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_WhenAdded_T_().md#DefaultEcs_EntityQueryBuilder_WhenAdded_T_()_T 'DefaultEcs.EntityQueryBuilder.WhenAdded&lt;T&gt;().T') is added.  

***
[WhenAddedEither&lt;T&gt;()](EntityQueryBuilder_WhenAddedEither_T_().md 'DefaultEcs.EntityQueryBuilder.WhenAddedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  

***
[WhenChanged&lt;T&gt;()](EntityQueryBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_WhenChanged_T_().md#DefaultEcs_EntityQueryBuilder_WhenChanged_T_()_T 'DefaultEcs.EntityQueryBuilder.WhenChanged&lt;T&gt;().T') is changed.  

***
[WhenChangedEither&lt;T&gt;()](EntityQueryBuilder_WhenChangedEither_T_().md 'DefaultEcs.EntityQueryBuilder.WhenChangedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is changed.  

***
[WhenRemoved&lt;T&gt;()](EntityQueryBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_WhenRemoved_T_().md#DefaultEcs_EntityQueryBuilder_WhenRemoved_T_()_T 'DefaultEcs.EntityQueryBuilder.WhenRemoved&lt;T&gt;().T') is removed.  

***
[WhenRemovedEither&lt;T&gt;()](EntityQueryBuilder_WhenRemovedEither_T_().md 'DefaultEcs.EntityQueryBuilder.WhenRemovedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.  

***
[With&lt;T&gt;()](EntityQueryBuilder_With_T_().md 'DefaultEcs.EntityQueryBuilder.With&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_With_T_().md#DefaultEcs_EntityQueryBuilder_With_T_()_T 'DefaultEcs.EntityQueryBuilder.With&lt;T&gt;().T').  

***
[With&lt;T&gt;(ComponentPredicate&lt;T&gt;)](EntityQueryBuilder_With_T_(ComponentPredicate_T_).md 'DefaultEcs.EntityQueryBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;)')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_With_T_(ComponentPredicate_T_).md#DefaultEcs_EntityQueryBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_T 'DefaultEcs.EntityQueryBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T') validating the given [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  

***
[WithEither&lt;T&gt;()](EntityQueryBuilder_WithEither_T_().md 'DefaultEcs.EntityQueryBuilder.WithEither&lt;T&gt;()')

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the either group.  

***
[Without&lt;T&gt;()](EntityQueryBuilder_Without_T_().md 'DefaultEcs.EntityQueryBuilder.Without&lt;T&gt;()')

Makes a rule to ignore [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_Without_T_().md#DefaultEcs_EntityQueryBuilder_Without_T_()_T 'DefaultEcs.EntityQueryBuilder.Without&lt;T&gt;().T').  

***
[WithoutEither&lt;T&gt;()](EntityQueryBuilder_WithoutEither_T_().md 'DefaultEcs.EntityQueryBuilder.WithoutEither&lt;T&gt;()')

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the either group.  
