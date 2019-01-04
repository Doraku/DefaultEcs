#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](./DefaultEcs.md#DefaultEcs-Serialization 'DefaultEcs.Serialization').[ISerializerExtension](./DefaultEcs-Serialization-ISerializerExtension.md 'DefaultEcs.Serialization.ISerializerExtension')
## Serialize(DefaultEcs.Serialization.ISerializer, System.IO.Stream, DefaultEcs.Entity[]) `method`
Serializes the given [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').
### Parameters

<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer-_System-IO-Stream-_DefaultEcs-Entity--)-serializer'></a>
`serializer`

The [ISerializer](./DefaultEcs-Serialization-ISerializer.md 'DefaultEcs.Serialization.ISerializer') instance to use.

<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer-_System-IO-Stream-_DefaultEcs-Entity--)-stream'></a>
`stream`

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') in which the data will be saved.

<a name='DefaultEcs-Serialization-ISerializerExtension-Serialize(DefaultEcs-Serialization-ISerializer-_System-IO-Stream-_DefaultEcs-Entity--)-entities'></a>
`entities`

The [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to save.
