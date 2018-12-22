#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](./DefaultEcs.md#DefaultEcs-Serialization 'DefaultEcs.Serialization').[TextSerializer](./DefaultEcs-Serialization-TextSerializer.md 'DefaultEcs.Serialization.TextSerializer')
## Write&lt;T&gt;(System.IO.Stream, T) `method`
Writes an object of type [T](#DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream-_T)-T 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).T') on the given stream.
### Type parameters

<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream-_T)-T'></a>
`T`
The type of the object serialized.
### Parameters

<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream-_T)-stream'></a>
`stream`
The [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream') instance on which the object is to be serialized.

<a name='DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream-_T)-obj'></a>
`obj`
The object to serialize.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
[stream](#DefaultEcs-Serialization-TextSerializer-Write-T-(System-IO-Stream-_T)-stream 'DefaultEcs.Serialization.TextSerializer.Write&lt;T&gt;(System.IO.Stream, T).stream') is null.
