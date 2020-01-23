#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## ActionIn&lt;T&gt;(T) Delegate
Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)](./DefaultEcs-World-Subscribe-T-(DefaultEcs-ActionIn-T-).md 'DefaultEcs.World.Subscribe&lt;T&gt;(DefaultEcs.ActionIn&lt;T&gt;)') method.  
```csharp
public delegate void ActionIn<T>(in T message);
```
#### Type parameters
<a name='DefaultEcs-ActionIn-T-(T)-T'></a>
`T`  
The type of message to subscribe to.  
  
#### Parameters
<a name='DefaultEcs-ActionIn-T-(T)-message'></a>
`message` [T](#DefaultEcs-ActionIn-T-(T)-T 'DefaultEcs.ActionIn&lt;T&gt;(T).T')  
The recieved message.  
  
