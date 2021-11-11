#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')
## World.SetMaxCapacity&lt;T&gt;(int) Method
Sets up the current [World](World.md 'DefaultEcs.World') to handle component of type [T](World_SetMaxCapacity_T_(int).md#DefaultEcs_World_SetMaxCapacity_T_(int)_T 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int).T') with a different maximum count than [MaxCapacity](World_MaxCapacity.md 'DefaultEcs.World.MaxCapacity').  
If the type of component is already handled by the current [World](World.md 'DefaultEcs.World'), does nothing.  
This method is not thread safe.  
```csharp
public bool SetMaxCapacity<T>(int maxCapacity);
```
#### Type parameters
<a name='DefaultEcs_World_SetMaxCapacity_T_(int)_T'></a>
`T`  
The type of component.
  
#### Parameters
<a name='DefaultEcs_World_SetMaxCapacity_T_(int)_maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of component of type [T](World_SetMaxCapacity_T_(int).md#DefaultEcs_World_SetMaxCapacity_T_(int)_T 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int).T') that can exist in this [World](World.md 'DefaultEcs.World').
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the maximum count has been setted or not.
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](World_SetMaxCapacity_T_(int).md#DefaultEcs_World_SetMaxCapacity_T_(int)_maxCapacity 'DefaultEcs.World.SetMaxCapacity&lt;T&gt;(int).maxCapacity') cannot be negative.
