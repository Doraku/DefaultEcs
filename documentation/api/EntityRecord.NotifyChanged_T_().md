#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.NotifyChanged<T>() Method

Notifies the value of the component of type [T](EntityRecord.NotifyChanged_T_().md#DefaultEcs.Command.EntityRecord.NotifyChanged_T_().T 'DefaultEcs.Command.EntityRecord.NotifyChanged<T>().T') has changed on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
This command takes 9 bytes.

```csharp
public void NotifyChanged<T>();
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.NotifyChanged_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.