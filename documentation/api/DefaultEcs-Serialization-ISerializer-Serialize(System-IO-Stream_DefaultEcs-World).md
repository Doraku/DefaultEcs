#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')
## ISerializer.Serialize(System.IO.Stream, DefaultEcs.World) Method
Serializes the given [World](./DefaultEcs-World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
void Serialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_DefaultEcs-World)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.  
  
<a name='DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_DefaultEcs-World)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to save.  
  
