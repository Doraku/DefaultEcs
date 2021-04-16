#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')
## EntityMultiMap&lt;TKey&gt;.KeyEnumerator Struct
Enumerates the [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') of a [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  
```csharp
public struct EntityMultiMap<TKey>.KeyEnumerator :
System.Collections.Generic.IEnumerator<TKey>,
System.Collections.IEnumerator,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey'></a>
`TKey`  
  

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Properties

***
[Current](EntityMultiMap_TKey__KeyEnumerator_Current.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.Current')

Gets the [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') at the current position of the enumerator.  
### Methods

***
[Dispose()](EntityMultiMap_TKey__KeyEnumerator_Dispose().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.Dispose()')

Releases all resources used by the [KeyEnumerator](EntityMultiMap_TKey__KeyEnumerator.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator').  

***
[MoveNext()](EntityMultiMap_TKey__KeyEnumerator_MoveNext().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.MoveNext()')

Advances the enumerator to the next [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') of the [EntityMultiMap&lt;TKey&gt;](EntityMultiMap_TKey_.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').
### Explicit Interface Implementations

***
[System.Collections.IEnumerator.Current](EntityMultiMap_TKey__KeyEnumerator_System_Collections_IEnumerator_Current.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.System.Collections.IEnumerator.Current')

Gets the [TKey](EntityMultiMap_TKey__KeyEnumerator.md#DefaultEcs_EntityMultiMap_TKey__KeyEnumerator_TKey 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.TKey') at the current position of the enumerator.  

***
[System.Collections.IEnumerator.Reset()](EntityMultiMap_TKey__KeyEnumerator_System_Collections_IEnumerator_Reset().md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;.KeyEnumerator.System.Collections.IEnumerator.Reset()')

Sets the enumerator to its initial position, which is before the first element in the collection.
