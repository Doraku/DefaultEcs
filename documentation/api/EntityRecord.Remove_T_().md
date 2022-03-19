#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.Remove<T>() Method

Removes the component of type [T](EntityRecord.Remove_T_().md#DefaultEcs.Command.EntityRecord.Remove_T_().T 'DefaultEcs.Command.EntityRecord.Remove<T>().T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.

```csharp
public void Remove<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.Remove_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.