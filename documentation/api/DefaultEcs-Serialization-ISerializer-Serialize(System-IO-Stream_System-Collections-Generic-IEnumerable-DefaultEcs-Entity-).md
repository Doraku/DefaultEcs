#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer')
## ISerializer.Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;) Method
Serializes the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
```C#
void Serialize(System.IO.Stream stream, System.Collections.Generic.IEnumerable<DefaultEcs.Entity> entities);
```
#### Parameters
<a name='DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-stream'></a>
stream [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')  
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.  
<a name='DefaultEcs-Serialization-ISerializer-Serialize(System-IO-Stream_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-entities'></a>
entities [System.Collections.Generic.IEnumerable](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable')  
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to save.  
