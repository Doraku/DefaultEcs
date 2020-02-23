#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;) Method
Subscribes an [MessageHandler&lt;T&gt;(T)](./DefaultEcs-MessageHandler-T-(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)') to be called back when a [T](#DefaultEcs-World-Subscribe-T-(DefaultEcs-MessageHandler-T-)-T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T') object is published.  
```csharp
public System.IDisposable Subscribe<T>(DefaultEcs.MessageHandler<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-MessageHandler-T-)-T'></a>
`T`  
The type of the object to be called back with.  
  
#### Parameters
<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-MessageHandler-T-)-action'></a>
`action` [DefaultEcs.MessageHandler&lt;](./DefaultEcs-MessageHandler-T-(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)')[T](#DefaultEcs-World-Subscribe-T-(DefaultEcs-MessageHandler-T-)-T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;).T')[&gt;](./DefaultEcs-MessageHandler-T-(T).md 'DefaultEcs.MessageHandler&lt;T&gt;(T)')  
The delegate to be called back.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
