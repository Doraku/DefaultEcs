#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.Disable<T>() Method

Disables the corresponding [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](EntityRecord.Disable_T_().md#DefaultEcs.Command.EntityRecord.Disable_T_().T 'DefaultEcs.Command.EntityRecord.Disable<T>().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').  
This command takes 9 bytes.

```csharp
public void Disable<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.Disable_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.