#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder')
## EntityQueryBuilder.EitherBuilder Class
Represents an helper object to create an either group rule to retrieve a specific subset of [Entity](Entity.md 'DefaultEcs.Entity').  
```csharp
public sealed class EntityQueryBuilder.EitherBuilder
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; EitherBuilder  
### Methods

***
[AsEnumerable()](EntityQueryBuilder_EitherBuilder_AsEnumerable().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsEnumerable()')

Returns an [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') of [Entity](Entity.md 'DefaultEcs.Entity') with the specified rules.  

***
[AsMap&lt;TKey&gt;()](EntityQueryBuilder_EitherBuilder_AsMap_TKey_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap&lt;TKey&gt;()')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMap&lt;TKey&gt;(IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_EitherBuilder_AsMap_TKey_(IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;()](EntityQueryBuilder_EitherBuilder_AsMultiMap_TKey_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap&lt;TKey&gt;()')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsMultiMap&lt;TKey&gt;(IEqualityComparer&lt;TKey&gt;)](EntityQueryBuilder_EitherBuilder_AsMultiMap_TKey_(IEqualityComparer_TKey_).md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsMultiMap&lt;TKey&gt;(System.Collections.Generic.IEqualityComparer&lt;TKey&gt;)')

Returns an [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') with the specified rules.  

***
[AsPredicate()](EntityQueryBuilder_EitherBuilder_AsPredicate().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsPredicate()')

Returns a [System.Predicate&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Predicate-1 'System.Predicate`1') representing the specified rules.  

***
[AsSet()](EntityQueryBuilder_EitherBuilder_AsSet().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.AsSet()')

Returns an [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') with the specified rules.  

***
[Copy()](EntityQueryBuilder_EitherBuilder_Copy().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.Copy()')

Copies all the rules of the current [EntityQueryBuilder](EntityQueryBuilder.md 'DefaultEcs.EntityQueryBuilder') to a new instance.  

***
[Or&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_Or_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.Or&lt;T&gt;()')

Add the type [T](EntityQueryBuilder_EitherBuilder_Or_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_Or_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.Or&lt;T&gt;().T') to current either group.  

***
[WhenAdded&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenAdded_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenAdded&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_EitherBuilder_WhenAdded_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_WhenAdded_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenAdded&lt;T&gt;().T') is added.  

***
[WhenAddedEither&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenAddedEither_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenAddedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is added.  

***
[WhenChanged&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenChanged_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenChanged&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_EitherBuilder_WhenChanged_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_WhenChanged_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenChanged&lt;T&gt;().T') is changed.  

***
[WhenChangedEither&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenChangedEither_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenChangedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is changed.  

***
[WhenRemoved&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenRemoved_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemoved&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when a component of type [T](EntityQueryBuilder_EitherBuilder_WhenRemoved_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_WhenRemoved_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemoved&lt;T&gt;().T') is removed.  

***
[WhenRemovedEither&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WhenRemovedEither_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WhenRemovedEither&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') when one component of the either group is removed.  

***
[With&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_With_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;()')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_EitherBuilder_With_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;().T').  

***
[With&lt;T&gt;(ComponentPredicate&lt;T&gt;)](EntityQueryBuilder_EitherBuilder_With_T_(ComponentPredicate_T_).md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;)')

Makes a rule to observe [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_EitherBuilder_With_T_(ComponentPredicate_T_).md#DefaultEcs_EntityQueryBuilder_EitherBuilder_With_T_(DefaultEcs_ComponentPredicate_T_)_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.With&lt;T&gt;(DefaultEcs.ComponentPredicate&lt;T&gt;).T') validating the given [ComponentPredicate&lt;T&gt;(T)](ComponentPredicate_T_(T).md 'DefaultEcs.ComponentPredicate&lt;T&gt;(T)').  

***
[WithEither&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WithEither_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WithEither&lt;T&gt;()')

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') with at least one component of the either group.  

***
[Without&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_Without_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.Without&lt;T&gt;()')

Makes a rule to ignore [Entity](Entity.md 'DefaultEcs.Entity') with a component of type [T](EntityQueryBuilder_EitherBuilder_Without_T_().md#DefaultEcs_EntityQueryBuilder_EitherBuilder_Without_T_()_T 'DefaultEcs.EntityQueryBuilder.EitherBuilder.Without&lt;T&gt;().T').  

***
[WithoutEither&lt;T&gt;()](EntityQueryBuilder_EitherBuilder_WithoutEither_T_().md 'DefaultEcs.EntityQueryBuilder.EitherBuilder.WithoutEither&lt;T&gt;()')

Makes a rule to obsverve [Entity](Entity.md 'DefaultEcs.Entity') without at least one component of the either group.  
