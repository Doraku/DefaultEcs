#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AEntitySetSystem&lt;T&gt;](AEntitySetSystem_T_.md 'DefaultEcs.System.AEntitySetSystem<T>')

## AEntitySetSystem<T>.Update(T) Method

Updates the system once.  
Does nothing if [IsEnabled](AEntitySetSystem_T_.IsEnabled.md 'DefaultEcs.System.AEntitySetSystem<T>.IsEnabled') is false or if the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet') is empty.

```csharp
public void Update(T state);
```
#### Parameters

<a name='DefaultEcs.System.AEntitySetSystem_T_.Update(T).state'></a>

`state` [T](AEntitySetSystem_T_.md#DefaultEcs.System.AEntitySetSystem_T_.T 'DefaultEcs.System.AEntitySetSystem<T>.T')

The state to use.

Implements [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)')