#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;) Method
Subscribes an [ActionIn&lt;T&gt;(T)](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)') to be called back when a [T](#DefaultEcs-World-Subscribe-T-(DefaultEcs-ActionIn-T-)-T 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;).T') object is published.  
```C#
public System.IDisposable Subscribe<T>(DefaultEcs.ActionIn<T> action);
```
#### Type parameters
<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-ActionIn-T-)-T'></a>
`T`  
The type of the object to be called back with.  
#### Parameters
<a name='DefaultEcs-World-Subscribe-T-(DefaultEcs-ActionIn-T-)-action'></a>
action [ActionIn&lt;T&gt;(T)](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)')  
The delegate to be called back.  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
