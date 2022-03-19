#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs').[World](World.md 'DefaultEcs.World')

## World.TrimExcess<T>() Method

Resizes inner storage to exactly the number of [T](World.TrimExcess_T_().md#DefaultEcs.World.TrimExcess_T_().T 'DefaultEcs.World.TrimExcess<T>().T') components this [World](World.md 'DefaultEcs.World') contains.  
This method is not thread safe.

```csharp
public void TrimExcess<T>();
```
#### Type parameters

<a name='DefaultEcs.World.TrimExcess_T_().T'></a>

`T`

The type of the component storage to trim.