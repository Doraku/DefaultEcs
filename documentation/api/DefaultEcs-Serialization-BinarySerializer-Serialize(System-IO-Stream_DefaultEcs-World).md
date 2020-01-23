#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World) Method
Serializes the given [World](./DefaultEcs-World.md 'DefaultEcs.World') into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public void Serialize(System.IO.Stream stream, DefaultEcs.World world);
```
#### Parameters
<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_DefaultEcs-World)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.  
  
<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_DefaultEcs-World)-world'></a>
`world` [World](./DefaultEcs-World.md 'DefaultEcs.World')  
The [World](./DefaultEcs-World.md 'DefaultEcs.World') instance to save.  
  
#### Exceptions
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[stream](#DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_DefaultEcs-World)-stream 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).stream') is null.  
[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](#DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream_DefaultEcs-World)-world 'DefaultEcs.Serialization.BinarySerializer.Serialize(System.IO.Stream, DefaultEcs.World).world') is null.  
