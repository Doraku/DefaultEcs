#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./DefaultEcs.md 'DefaultEcs').[World](./DefaultEcs-World.md 'DefaultEcs.World')
## World.GetMaxCapacity&lt;T&gt;() Method
Gets the maximum number of [T](#DefaultEcs-World-GetMaxCapacity-T-()-T 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;().T') components this [World](./DefaultEcs-World.md 'DefaultEcs.World') can create.  
```C#
public int GetMaxCapacity<T>();
```
#### Type parameters
<a name='DefaultEcs-World-GetMaxCapacity-T-()-T'></a>
`T`  
  
  
#### Returns
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')  
The maximum number of [T](#DefaultEcs-World-GetMaxCapacity-T-()-T 'DefaultEcs.World.GetMaxCapacity&lt;T&gt;().T') components this [World](./DefaultEcs-World.md 'DefaultEcs.World') can create, or -1 if it is currently not handled.  
