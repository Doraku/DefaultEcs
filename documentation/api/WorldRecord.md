#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command')
## WorldRecord Struct
Represents a [World](World.md 'DefaultEcs.World') on which to create commands to record in a [EntityCommandRecorder](EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
```csharp
public readonly ref struct WorldRecord
```

| Methods | |
| :--- | :--- |
| [CreateEntity()](WorldRecord_CreateEntity().md 'DefaultEcs.Command.WorldRecord.CreateEntity()') | Records the creation of an [Entity](Entity.md 'DefaultEcs.Entity') on a [World](World.md 'DefaultEcs.World') and returns an [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') to record action on it.<br/>This command takes 9 bytes.<br/> |
| [Remove&lt;T&gt;()](WorldRecord_Remove_T_().md 'DefaultEcs.Command.WorldRecord.Remove&lt;T&gt;()') | Removes the component of type [T](WorldRecord_Remove_T_().md#DefaultEcs_Command_WorldRecord_Remove_T_()_T 'DefaultEcs.Command.WorldRecord.Remove&lt;T&gt;().T') on the corresponding [World](World.md 'DefaultEcs.World').<br/>This command takes 7 bytes.<br/> |
| [Set&lt;T&gt;()](WorldRecord_Set_T_().md 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;()') | Sets the value of the component of type [T](WorldRecord_Set_T_().md#DefaultEcs_Command_WorldRecord_Set_T_()_T 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;().T') to its default value on the corresponding [World](World.md 'DefaultEcs.World').<br/>For a blittable component, this command takes 7 bytes + the size of the component.<br/>For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type.<br/> |
| [Set&lt;T&gt;(T)](WorldRecord_Set_T_(T).md 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;(T)') | Sets the value of the component of type [T](WorldRecord_Set_T_(T).md#DefaultEcs_Command_WorldRecord_Set_T_(T)_T 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;(T).T') on the corresponding [World](World.md 'DefaultEcs.World').<br/>For a blittable component, this command takes 7 bytes + the size of the component.<br/>For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type.<br/> |
