#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')
## ISerializer.Deserialize(System.IO.Stream) Method
Deserializes a [World](./DefaultEcs-World.md 'DefaultEcs.World') instance from the given [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```C#
DefaultEcs.World Deserialize(System.IO.Stream stream);
```
#### Parameters
<a name='DefaultEcs-Serialization-ISerializer-Deserialize(System-IO-Stream)-stream'></a>
stream [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') from which the data will be loaded.  
#### Returns
[World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance loaded.  
