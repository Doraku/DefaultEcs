#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[WorldRecord](WorldRecord.md 'DefaultEcs.Command.WorldRecord')

## WorldRecord.Remove<T>() Method

Removes the component of type [T](WorldRecord.Remove_T_().md#DefaultEcs.Command.WorldRecord.Remove_T_().T 'DefaultEcs.Command.WorldRecord.Remove<T>().T') on the corresponding [World](World.md 'DefaultEcs.World').  
This command takes 7 bytes.

```csharp
public void Remove<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.WorldRecord.Remove_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.