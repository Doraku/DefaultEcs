### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization.TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## Read&lt;T&gt;(System.IO.Stream) `method`
Read an object of type [T](./DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream).md#T 'T') from the given stream.
### Type parameters

<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-T'></a>
`T`

The type of the object deserialized.
### Parameters

<a name='DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-stream'></a>
`stream`

The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance from which the object is to be deserialized.
### Returns
The object deserialized.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')

[stream](#DefaultEcs-Serialization-TextSerializer-Read-T-(System-IO-Stream)-stream 'DefaultEcs.Serialization.TextSerializer.Read&lt;T&gt;(System.IO.Stream).stream') is null.
