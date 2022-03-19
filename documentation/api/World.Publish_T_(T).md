#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Publish<T>(T) Method

Publishes a [T](World.Publish_T_(T).md#DefaultEcs.World.Publish_T_(T).T 'DefaultEcs.World.Publish<T>(T).T') object.

```csharp
public void Publish<T>(in T message);
```
#### Type parameters

<a name='DefaultEcs.World.Publish_T_(T).T'></a>

`T`

The type of the object to publish.
#### Parameters

<a name='DefaultEcs.World.Publish_T_(T).message'></a>

`message` [T](World.Publish_T_(T).md#DefaultEcs.World.Publish_T_(T).T 'DefaultEcs.World.Publish<T>(T).T')

The object to publish.

Implements [Publish&lt;T&gt;(T)](IPublisher.Publish_T_(T).md 'DefaultEcs.IPublisher.Publish<T>(T)')