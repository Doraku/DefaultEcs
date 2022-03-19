#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[WhenRemovedAttribute](WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute')

## WhenRemovedAttribute(Type[]) Constructor

Initialize a new instance of the [WhenRemovedAttribute](WhenRemovedAttribute.md 'DefaultEcs.System.WhenRemovedAttribute') type.

```csharp
public WhenRemovedAttribute(params System.Type[] componentTypes);
```
#### Parameters

<a name='DefaultEcs.System.WhenRemovedAttribute.WhenRemovedAttribute(System.Type[]).componentTypes'></a>

`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The types of the component to react to their deletion.