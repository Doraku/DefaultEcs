#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord')
## WorldRecord.Set&lt;T&gt;(T) Method
Sets the value of the component of type [T](WorldRecord_Set_T_(T).md#DefaultEcs_Command_WorldRecord_Set_T_(T)_T 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;(T).T') on the corresponding [World](World.md 'DefaultEcs.World').  
For a blittable component, this command takes 7 bytes + the size of the component.  
For non blittable component, this command takes 11 bytes and may cause some allocation because of boxing on struct component type.  
```csharp
public void Set<T>(in T component);
```
#### Type parameters
<a name='DefaultEcs_Command_WorldRecord_Set_T_(T)_T'></a>
`T`  
The type of the component.
  
#### Parameters
<a name='DefaultEcs_Command_WorldRecord_Set_T_(T)_component'></a>
`component` [T](WorldRecord_Set_T_(T).md#DefaultEcs_Command_WorldRecord_Set_T_(T)_T 'DefaultEcs.Command.WorldRecord.Set&lt;T&gt;(T).T')  
The value of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
