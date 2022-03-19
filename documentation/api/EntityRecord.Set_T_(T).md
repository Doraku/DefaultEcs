#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.Set<T>(T) Method

Sets the value of the component of type [T](EntityRecord.Set_T_(T).md#DefaultEcs.Command.EntityRecord.Set_T_(T).T 'DefaultEcs.Command.EntityRecord.Set<T>(T).T') on the corresponding [Entity](Entity.md 'DefaultEcs.Entity').  
For a blittable component, this command takes 9 bytes + the size of the component.  
For non blittable component, this command takes 13 bytes and may cause some allocation because of boxing on struct component type.

```csharp
public void Set<T>(in T component);
```
#### Type parameters

<a name='DefaultEcs.Command.EntityRecord.Set_T_(T).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.Command.EntityRecord.Set_T_(T).component'></a>

`component` [T](EntityRecord.Set_T_(T).md#DefaultEcs.Command.EntityRecord.Set_T_(T).T 'DefaultEcs.Command.EntityRecord.Set<T>(T).T')

The value of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.