#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.Enumerator Struct
Enumerates the [Entity](Entity.md 'DefaultEcs.Entity') of a [World](World.md 'DefaultEcs.World').  
```csharp
public struct World.Enumerator :
System.Collections.Generic.IEnumerator<DefaultEcs.Entity>,
System.Collections.IEnumerator,
System.IDisposable
```

Implements [System.Collections.Generic.IEnumerator&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerator-1 'System.Collections.Generic.IEnumerator`1'), [System.Collections.IEnumerator](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.IEnumerator 'System.Collections.IEnumerator'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
### Properties

***
[Current](World_Enumerator_Current.md 'DefaultEcs.World.Enumerator.Current')

Gets the [Entity](Entity.md 'DefaultEcs.Entity') at the current position of the enumerator.  
### Methods

***
[Dispose()](World_Enumerator_Dispose().md 'DefaultEcs.World.Enumerator.Dispose()')

Releases all resources used by the [Enumerator](World_Enumerator.md 'DefaultEcs.World.Enumerator').  

***
[MoveNext()](World_Enumerator_MoveNext().md 'DefaultEcs.World.Enumerator.MoveNext()')

Advances the enumerator to the next [Entity](Entity.md 'DefaultEcs.Entity') of the [World](World.md 'DefaultEcs.World').  

***
[Reset()](World_Enumerator_Reset().md 'DefaultEcs.World.Enumerator.Reset()')

Sets the enumerator to its initial position, which is before the first [Entity](Entity.md 'DefaultEcs.Entity') in the collection.  
### Explicit Interface Implementations

***
[System.Collections.IEnumerator.Current](World_Enumerator_System_Collections_IEnumerator_Current.md 'DefaultEcs.World.Enumerator.System.Collections.IEnumerator.Current')

Gets the [Entity](Entity.md 'DefaultEcs.Entity') at the current position of the enumerator.  
