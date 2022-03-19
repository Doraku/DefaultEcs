#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World').[Enumerator](World.Enumerator.md 'DefaultEcs.World.Enumerator')

## World.Enumerator.MoveNext() Method

Advances the enumerator to the next [Entity](Entity.md 'DefaultEcs.Entity') of the [World](World.md 'DefaultEcs.World').

```csharp
public bool MoveNext();
```

Implements [MoveNext()](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator.MoveNext 'System.Collections.IEnumerator.MoveNext')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the enumerator was successfully advanced to the next [Entity](Entity.md 'DefaultEcs.Entity'); false if the enumerator has passed the end of the collection.