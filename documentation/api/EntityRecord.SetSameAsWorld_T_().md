#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.SetSameAsWorld<T>() Method

Sets the value of the component of type [T](EntityRecord.SetSameAsWorld_T_().md#DefaultEcs.Command.EntityRecord.SetSameAsWorld_T_().T 'DefaultEcs.Command.EntityRecord.SetSameAsWorld<T>().T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of its [World](World.md 'DefaultEcs.World').  
This command takes 9 bytes.

```csharp
public void SetSameAsWorld<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.SetSameAsWorld_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.