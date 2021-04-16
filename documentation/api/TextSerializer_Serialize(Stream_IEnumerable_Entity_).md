#### [DefaultEcs](index.md 'index')
### [DefaultEcs.Serialization](index.md#DefaultEcs_Serialization 'DefaultEcs.Serialization').[TextSerializer](TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Serialize(Stream, IEnumerable&lt;Entity&gt;) Method
Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```csharp
public void Serialize(System.IO.Stream stream, System.Collections.Generic.IEnumerable<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs_Serialization_TextSerializer_Serialize(System_IO_Stream_System_Collections_Generic_IEnumerable_DefaultEcs_Entity_)_stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.
  
<a name='DefaultEcs_Serialization_TextSerializer_Serialize(System_IO_Stream_System_Collections_Generic_IEnumerable_DefaultEcs_Entity_)_entities'></a>
`entities` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The [Entity](Entity.md 'DefaultEcs.Entity') instances to save.
  
