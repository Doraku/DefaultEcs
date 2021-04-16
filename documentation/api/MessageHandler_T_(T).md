#### [DefaultEcs](index.md 'index')
### [DefaultEcs](index.md#DefaultEcs 'DefaultEcs')
## MessageHandler&lt;T&gt;(T) Delegate
Encapsulates a method that has a single in parameter and does not return a value used for [Subscribe&lt;T&gt;(MessageHandler&lt;T&gt;)](IPublisher_Subscribe_T_(MessageHandler_T_).md 'DefaultEcs.IPublisher.Subscribe&lt;T&gt;(DefaultEcs.MessageHandler&lt;T&gt;)') method.  
```csharp
public delegate void MessageHandler<T>(in T message);
```
#### Type parameters
<a name='DefaultEcs_MessageHandler_T_(T)_T'></a>
`T`  
The type of the parameter of the method that this delegate encapsulates.
  
#### Parameters
<a name='DefaultEcs_MessageHandler_T_(T)_message'></a>
`message` [T](MessageHandler_T_(T).md#DefaultEcs_MessageHandler_T_(T)_T 'DefaultEcs.MessageHandler&lt;T&gt;(T).T')  
The parameter of the method that this delegate encapsulates.
  
