#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Command](DefaultEcs.md#DefaultEcs.Command 'DefaultEcs.Command').[EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord')

## EntityRecord.Dispose() Method

Clean the corresponding [Entity](Entity.md 'DefaultEcs.Entity') of all its components.  
The current [EntityRecord](EntityRecord.md 'DefaultEcs.Command.EntityRecord') should not be used again after calling this method.  
This command takes 5 bytes.

```csharp
public void Dispose();
```

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Command buffer is full.