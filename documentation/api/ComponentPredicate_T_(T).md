#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## ComponentPredicate<T>(T) Delegate

Represents the method that defines a set of criteria and determines whether the specified component meets those criteria.

```csharp
public delegate bool ComponentPredicate<T>(in T value);
```
#### Type parameters

<a name='DefaultEcs.ComponentPredicate_T_(T).T'></a>

`T`

The type of the component to compare.
#### Parameters

<a name='DefaultEcs.ComponentPredicate_T_(T).value'></a>

`value` [T](ComponentPredicate_T_(T).md#DefaultEcs.ComponentPredicate_T_(T).T 'DefaultEcs.ComponentPredicate<T>(T).T')

The component value.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
true if the component meets the criteria; otherwise, false.