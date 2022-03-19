#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## Components<T> Struct

Provides a fast access to the components of type [T](Components_T_.md#DefaultEcs.Components_T_.T 'DefaultEcs.Components<T>.T').  
Note that all entity modification operations are not safe (anything different than a simple [Get&lt;T&gt;()](Entity.Get_T_().md 'DefaultEcs.Entity.Get<T>()')) and may invalidate the [Components&lt;T&gt;](Components_T_.md 'DefaultEcs.Components<T>').

```csharp
public readonly ref struct Components<T>
```
#### Type parameters

<a name='DefaultEcs.Components_T_.T'></a>

`T`

The type of the component.

| Properties | |
| :--- | :--- |
| [this[Entity]](Components_T_.this[Entity].md 'DefaultEcs.Components<T>.this[DefaultEcs.Entity]') | Gets the component of type [T](Components_T_.md#DefaultEcs.Components_T_.T 'DefaultEcs.Components<T>.T') on the provided [Entity](Entity.md 'DefaultEcs.Entity'). |
