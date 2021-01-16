#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.System](./DefaultEcs-System.md 'DefaultEcs.System').[AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;')
## AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;) Constructor
Initialise a new instance of the [AEntityMultiMapSystem&lt;TState,TKey&gt;](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;') class with the given [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;').  
```csharp
protected AEntityMultiMapSystem(DefaultEcs.EntityMultiMap<TKey> map);
```
#### Parameters
<a name='DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-)-map'></a>
`map` [DefaultEcs.EntityMultiMap&lt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')[TKey](./DefaultEcs-System-AEntityMultiMapSystem-TState_TKey-.md#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--TKey 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.TKey')[&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;')  
The [EntityMultiMap&lt;TKey&gt;](./DefaultEcs-EntityMultiMap-TKey-.md 'DefaultEcs.EntityMultiMap&lt;TKey&gt;') on which to process the update.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[map](#DefaultEcs-System-AEntityMultiMapSystem-TState_TKey--AEntityMultiMapSystem(DefaultEcs-EntityMultiMap-TKey-)-map 'DefaultEcs.System.AEntityMultiMapSystem&lt;TState,TKey&gt;.AEntityMultiMapSystem(DefaultEcs.EntityMultiMap&lt;TKey&gt;).map') is null.  
