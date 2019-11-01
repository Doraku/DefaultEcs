#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Command](./DefaultEcs-Command.md 'DefaultEcs.Command').[EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder')
## EntityCommandRecorder(int) Constructor
Creates a fixed sized [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
```C#
public EntityCommandRecorder(int maxCapacity);
```
#### Parameters
<a name='DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int)-maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The size of the [EntityCommandRecorder](./DefaultEcs-Command-EntityCommandRecorder.md 'DefaultEcs.Command.EntityCommandRecorder').  
  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](#DefaultEcs-Command-EntityCommandRecorder-EntityCommandRecorder(int)-maxCapacity 'DefaultEcs.Command.EntityCommandRecorder.EntityCommandRecorder(int).maxCapacity') cannot be negative.  
