#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.Enable<T>() Method

Enables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord.Enable_T_().md#DefaultEcs.Command.EntityRecord.Enable_T_().T 'DefaultEcs.Command.EntityRecord.Enable<T>().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
Does nothing if corresponding [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](EntityRecord.Enable_T_().md#DefaultEcs.Command.EntityRecord.Enable_T_().T 'DefaultEcs.Command.EntityRecord.Enable<T>().T').  
This command takes 9 bytes.

```csharp
public void Enable<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.Enable_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.