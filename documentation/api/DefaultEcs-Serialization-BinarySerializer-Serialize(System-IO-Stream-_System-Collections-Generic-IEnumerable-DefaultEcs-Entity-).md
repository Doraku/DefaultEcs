#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](./DefaultEcs.md#DefaultEcs-Serialization 'DefaultEcs.Serialization').[BinarySerializer](./DefaultEcs-Serialization-BinarySerializer.md 'DefaultEcs.Serialization.BinarySerializer')
## Serialize(System.IO.Stream, System.Collections.Generic.IEnumerable&lt;DefaultEcs.Entity&gt;) `method`
Serializes the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').
### Parameters

<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-stream'></a>
`stream`
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs-Serialization-BinarySerializer-Serialize(System-IO-Stream-_System-Collections-Generic-IEnumerable-DefaultEcs-Entity-)-entities'></a>
`entities`
The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to save.
