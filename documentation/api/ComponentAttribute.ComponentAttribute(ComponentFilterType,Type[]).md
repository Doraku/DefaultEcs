#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute')

## ComponentAttribute(ComponentFilterType, Type[]) Constructor

Initialize a new instance of the [ComponentAttribute](ComponentAttribute.md 'DefaultEcs.System.ComponentAttribute') type.

```csharp
public ComponentAttribute(DefaultEcs.System.ComponentFilterType filterType, params System.Type[] componentTypes);
```
#### Parameters

<a name='DefaultEcs.System.ComponentAttribute.ComponentAttribute(DefaultEcs.System.ComponentFilterType,System.Type[]).filterType'></a>

`filterType` [ComponentFilterType](ComponentFilterType.md 'DefaultEcs.System.ComponentFilterType')

The type of filter to apply with the given types.

<a name='DefaultEcs.System.ComponentAttribute.ComponentAttribute(DefaultEcs.System.ComponentFilterType,System.Type[]).componentTypes'></a>

`componentTypes` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')

The types of the component.