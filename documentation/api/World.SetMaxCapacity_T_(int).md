#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.SetMaxCapacity<T>(int) Method

Sets up the current [World](World.md 'DefaultEcs.World') to handle component of type [T](World.SetMaxCapacity_T_(int).md#DefaultEcs.World.SetMaxCapacity_T_(int).T 'DefaultEcs.World.SetMaxCapacity<T>(int).T') with a different maximum count than [MaxCapacity](World.MaxCapacity.md 'DefaultEcs.World.MaxCapacity').  
If the type of component is already handled by the current [World](World.md 'DefaultEcs.World'), does nothing.  
This method is not thread safe.

```csharp
public bool SetMaxCapacity<T>(int maxCapacity);
```
#### Type parameters

<a name='DefaultEcs.World.SetMaxCapacity_T_(int).T'></a>

`T`

The type of component.
#### Parameters

<a name='DefaultEcs.World.SetMaxCapacity_T_(int).maxCapacity'></a>

`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

The maximum number of component of type [T](World.SetMaxCapacity_T_(int).md#DefaultEcs.World.SetMaxCapacity_T_(int).T 'DefaultEcs.World.SetMaxCapacity<T>(int).T') that can exist in this [World](World.md 'DefaultEcs.World').

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the maximum count has been setted or not.

#### Exceptions

[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](World.SetMaxCapacity_T_(int).md#DefaultEcs.World.SetMaxCapacity_T_(int).maxCapacity 'DefaultEcs.World.SetMaxCapacity<T>(int).maxCapacity') cannot be negative.