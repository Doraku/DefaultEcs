#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>').[KeyEnumerator](EntityMap_TKey_.KeyEnumerator.md 'DefaultEcs.EntityMap<TKey>.KeyEnumerator')

## EntityMap<TKey>.KeyEnumerator.MoveNext() Method

Advances the enumerator to the next [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey') of the [EntityMap&lt;TKey&gt;](EntityMap_TKey_.md 'DefaultEcs.EntityMap<TKey>').

```csharp
public bool MoveNext();
```

Implements [MoveNext()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.MoveNext 'System.Collections.IEnumerator.MoveNext')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the enumerator was successfully advanced to the next [TKey](EntityMap_TKey_.KeyEnumerator.md#DefaultEcs.EntityMap_TKey_.KeyEnumerator.TKey 'DefaultEcs.EntityMap<TKey>.KeyEnumerator.TKey'); false if the enumerator has passed the end of the collection.