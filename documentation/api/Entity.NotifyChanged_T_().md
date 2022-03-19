#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[Entity](Entity.md 'DefaultEcs.Entity')

## Entity.NotifyChanged<T>() Method

Notifies the value of the component of type [T](Entity.NotifyChanged_T_().md#DefaultEcs.Entity.NotifyChanged_T_().T 'DefaultEcs.Entity.NotifyChanged<T>().T') has changed.  
This method is not thread safe.

```csharp
public void NotifyChanged<T>();
```
#### Type parameters

<a name='DefaultEcs.Entity.NotifyChanged_T_().T'></a>

`T`

The type of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') was not created from a [World](World.md 'DefaultEcs.World').

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
[Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.NotifyChanged_T_().md#DefaultEcs.Entity.NotifyChanged_T_().T 'DefaultEcs.Entity.NotifyChanged<T>().T').