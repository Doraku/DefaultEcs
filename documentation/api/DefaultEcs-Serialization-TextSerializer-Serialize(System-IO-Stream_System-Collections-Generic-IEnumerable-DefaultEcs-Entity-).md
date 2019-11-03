#### [DefaultEcs](./index.md 'index')
### [DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## TextSerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;) Method
Serializes the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```C#
public void Serialize(System.IO.Stream stream, System.Collections.Generic.IEnumerable<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-stream'></a>
`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.  
  
<a name='DefaultEcs-Serialization-TextSerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-entities'></a>
`entities` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to save.  
  
