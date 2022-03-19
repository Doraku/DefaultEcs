#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.SetSameAs<T>(EntityRecord) Method

Sets the value of the component of type [T](EntityRecord.SetSameAs_T_(EntityRecord).md#DefaultEcs.Command.EntityRecord.SetSameAs_T_(DefaultEcs.Command.EntityRecord).T 'DefaultEcs.Command.EntityRecord.SetSameAs<T>(DefaultEcs.Command.EntityRecord).T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord').  
This command takes 13 bytes.

```csharp
public void SetSameAs<T>(in DefaultEcs.Command.EntityRecord reference);
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.SetSameAs_T_(DefaultEcs.Command.EntityRecord).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.Command.EntityRecord.SetSameAs_T_(DefaultEcs.Command.EntityRecord).reference'></a>

`reference` [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

The other [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') used as reference.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.