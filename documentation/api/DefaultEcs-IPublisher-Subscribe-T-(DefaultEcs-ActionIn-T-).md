#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[IPublisher](./DefaultEcs-IPublisher.md 'DefaultEcs.IPublisher')
## IPublisher.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;) Method
Subscribes an [ActionIn&lt;T&gt;(T)](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)') to be called back when a [T](#DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-ActionIn-T-)-T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;).T') object is published.  
```C#
System.IDisposable Subscribe<T>(DefaultEcs.ActionIn<T> action);
```
#### Type parameters
<a name='DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-ActionIn-T-)-T'></a>
`T`  
The type of the object to be called back with.  
  
#### Parameters
<a name='DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-ActionIn-T-)-action'></a>
`action` [DefaultEcs.ActionIn&lt;](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)')[T](#DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-ActionIn-T-)-T 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;).T')[&gt;](./DefaultEcs-ActionIn-T-(T).md 'DefaultEcs.ActionIn&lt;T&gt;(T)')  
The delegate to be called back.  
  
#### Returns
[System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  
An [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable') object used to unsubscribe.  
