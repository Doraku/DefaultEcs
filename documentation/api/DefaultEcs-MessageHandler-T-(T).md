#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## MessageHandler&lt;T&gt;(T) Delegate
Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)](./DefaultEcs-IPublisher-Subscribe-T-(DefaultEcs-MessageHandler-T-).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)') method.  
```csharp
public delegate void MessageHandler<T>(in T message);
```
#### Type parameters
<a name='DefaultEcs-MessageHandler-T-(T)-T'></a>
`T`  
The type of the parameter of the method that this delegate encapsulates.  
  
#### Parameters
<a name='DefaultEcs-MessageHandler-T-(T)-message'></a>
`message` [T](#DefaultEcs-MessageHandler-T-(T)-T 'DefaultEcs.MessageHandler&lt;T&gt;(T).T')  
The parameter of the method that this delegate encapsulates.  
  
