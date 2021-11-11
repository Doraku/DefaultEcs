#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs_Command 'DefaultEcs.Command').[WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord')
## WorldRecord.Remove&lt;T&gt;() Method
Removes the component of type [T](WorldRecord_Remove_T_().md#DefaultEcs_Command_WorldRecord_Remove_T_()_T 'DefaultEcs.Command.WorldRecord.Remove&lt;T&gt;().T') on the corresponding [World](World.md 'DefaultEcs.World').  
This command takes 7 bytes.  
```csharp
public void Remove<T>();
```
#### Type parameters
<a name='DefaultEcs_Command_WorldRecord_Remove_T_()_T'></a>
`T`  
The type of the component.
  
#### Exceptions
[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.
