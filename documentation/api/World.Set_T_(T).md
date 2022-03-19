#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.Set<T>(T) Method

Sets the value of the component of type [T](World.Set_T_(T).md#DefaultEcs.World.Set_T_(T).T 'DefaultEcs.World.Set<T>(T).T') on the current [World](World.md 'DefaultEcs.World').  
This method is not thread safe.

```csharp
public void Set<T>(in T component);
```
#### Type parameters

<a name='DefaultEcs.World.Set_T_(T).T'></a>

`T`

The type of the component.
#### Parameters

<a name='DefaultEcs.World.Set_T_(T).component'></a>

`component` [T](World.Set_T_(T).md#DefaultEcs.World.Set_T_(T).T 'DefaultEcs.World.Set<T>(T).T')

The value of the component.

#### Exceptions

[System.InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/System.InvalidOperationException 'System.InvalidOperationException')  
Max number of component of type [T](World.Set_T_(T).md#DefaultEcs.World.Set_T_(T).T 'DefaultEcs.World.Set<T>(T).T') reached.