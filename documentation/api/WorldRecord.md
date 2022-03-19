#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command')

## WorldRecord Struct

Represents a [World](World.md 'DefaultEcs.World') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').

```csharp
public readonly ref struct WorldRecord
```

| Methods | |
| :--- | :--- |
| [CreateEntity()](WorldRecord.CreateEntity().md 'DefaultEcs.Command.WorldRecord.CreateEntity()') | Records the creation of an [Entity](Entity.md 'DefaultEcs.Entity') on a [World](World.md 'DefaultEcs.World') and returns an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.<br/>This command takes 9 bytes. |
| [Remove&lt;T&gt;()](WorldRecord.Remove_T_().md 'DefaultEcs.Command.WorldRecord.Remove<T>()') | Removes the component of type [T](WorldRecord.Remove_T_().md#DefaultEcs.Command.WorldRecord.Remove_T_().T 'DefaultEcs.Command.WorldRecord.Remove<T>().T') on the corresponding [World](World.md 'DefaultEcs.World').<br/>This command takes 7 bytes. |
| [Set&lt;T&gt;()](WorldRecord.Set_T_().md 'DefaultEcs.Command.WorldRecord.Set<T>()') | Sets the value of the component of type [T](WorldRecord.Set_T_().md#DefaultEcs.Command.WorldRecord.Set_T_().T 'DefaultEcs.Command.WorldRecord.Set<T>().T') to its default value on the corresponding [World](World.md 'DefaultEcs.World').<br/>For a blittable component, this command takes 7 bytes + the size of the component.<br/>For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type. |
| [Set&lt;T&gt;(T)](WorldRecord.Set_T_(T).md 'DefaultEcs.Command.WorldRecord.Set<T>(T)') | Sets the value of the component of type [T](WorldRecord.Set_T_(T).md#DefaultEcs.Command.WorldRecord.Set_T_(T).T 'DefaultEcs.Command.WorldRecord.Set<T>(T).T') on the corresponding [World](World.md 'DefaultEcs.World').<br/>For a blittable component, this command takes 7 bytes + the size of the component.<br/>For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type. |
