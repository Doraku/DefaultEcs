#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ActionSystem&lt;T&gt;](ActionSystem_T_.md 'DefaultEcs.System.ActionSystem<T>')

## ActionSystem<T>.Update(T) Method

Updates the system once.  
Does nothing if [IsEnabled](ISystem_T_.IsEnabled.md 'DefaultEcs.System.ISystem<T>.IsEnabled') is false.

```csharp
public void Update(T state);
```
#### Parameters

<a name='DefaultEcs.System.ActionSystem_T_.Update(T).state'></a>

`state` [T](ActionSystem_T_.md#DefaultEcs.System.ActionSystem_T_.T 'DefaultEcs.System.ActionSystem<T>.T')

The state to use.

Implements [Update(T)](ISystem_T_.Update(T).md 'DefaultEcs.System.ISystem<T>.Update(T)')