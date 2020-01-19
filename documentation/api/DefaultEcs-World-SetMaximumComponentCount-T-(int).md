#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.SetMaximumComponentCount&lt;T&gt;(int) Method
Sets up the current [World](./DefaultEcs-World.md 'DefaultEcs.World') to handle component of type [T](#DefaultEcs-World-SetMaximumComponentCount-T-(int)-T 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(int).T') with a different maximum count than [MaxCapacity](./DefaultEcs-World-MaxCapacity.md 'DefaultEcs.World.MaxCapacity').  
If the type of component is already handled by the current [World](./DefaultEcs-World.md 'DefaultEcs.World'), does nothing.  
```C#
public bool SetMaximumComponentCount<T>(int maxCapacity);
```
#### Type parameters
<a name='DefaultEcs-World-SetMaximumComponentCount-T-(int)-T'></a>
`T`  
The type of component.  
  
#### Parameters
<a name='DefaultEcs-World-SetMaximumComponentCount-T-(int)-maxCapacity'></a>
`maxCapacity` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of component of type [T](#DefaultEcs-World-SetMaximumComponentCount-T-(int)-T 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(int).T') that can exist in this [World](./DefaultEcs-World.md 'DefaultEcs.World').  
  
#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
Whether the maximum count has been setted or not.  
#### Exceptions
[System.ArgumentException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentException 'System.ArgumentException')  
[maxCapacity](#DefaultEcs-World-SetMaximumComponentCount-T-(int)-maxCapacity 'DefaultEcs.World.SetMaximumComponentCount&lt;T&gt;(int).maxCapacity') cannot be negative.  
