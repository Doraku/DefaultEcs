#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;')
## AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;) Constructor
Initialise a new instance of the [AEntitiesSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;') class with the given [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;').  
```csharp
protected AEntitiesSystem(DefaultEcs.EntitiesMap<TKey> map);
```
#### Parameters
<a name='DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-)-map'></a>
`map` [DefaultEcs.EntitiesMap&lt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntitiesSystem-TState_TKey-.md#DefaultEcs-System-AEntitiesSystem-TState_TKey--TKey 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;')  
The [EntitiesMap&lt;TKey&gt;](./DefaultEcs-EntitiesMap-TKey-.md 'DefaultEcs.EntitiesMap&lt;TKey&gt;') on which to process the update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](#DefaultEcs-System-AEntitiesSystem-TState_TKey--AEntitiesSystem(DefaultEcs-EntitiesMap-TKey-)-map 'DefaultEcs.System.AEntitiesSystem&lt;TState,TKey&gt;.AEntitiesSystem(DefaultEcs.EntitiesMap&lt;TKey&gt;).map') is null.  
