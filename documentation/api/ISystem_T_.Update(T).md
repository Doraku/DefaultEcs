#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ISystem&lt;T&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem<T>')

## ISystem<T>.Update(T) Method

Updates the system once.  
Does nothing if [IsEnabled](ISystem_T_.IsEnabled.md 'DefaultEcs.System.ISystem<T>.IsEnabled') is false.

```csharp
void Update(T state);
```
#### Parameters

<a name='DefaultEcs.System.ISystem_T_.Update(T).state'></a>

`state` [T](ISystem_T_.md#DefaultEcs.System.ISystem_T_.T 'DefaultEcs.System.ISystem<T>.T')

The state to use.