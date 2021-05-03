#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.Serialization](DefaultEcs.md#DefaultEcs_Serialization 'DefaultEcs.Serialization')
## ISerializerExtension Class
Provides extension methods to the [ISerializer](ISerializer.md 'DefaultEcs.Serialization.ISerializer') type.  
```csharp
public static class ISerializerExtension
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; ISerializerExtension  
### Methods

***
[Serialize(ISerializer, Stream, Entity[])](ISerializerExtension_Serialize(ISerializer_Stream_Entity__).md 'DefaultEcs.Serialization.ISerializerExtension.Serialize(DefaultEcs.Serialization.ISerializer, System.IO.Stream, DefaultEcs.Entity[])')

Serializes the given [Entity](Entity.md 'DefaultEcs.Entity') instances with their components into the provided [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream').  
