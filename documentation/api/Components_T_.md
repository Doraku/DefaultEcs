#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## Components&lt;T&gt; Struct
Provides a fast access to the components of type [T](Components_T_.md#DefaultEcs_Components_T__T 'DefaultEcs.Components&lt;T&gt;.T').  
Note that all entity modification operations are not safe (anything different than a simple [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()')) and may invalidate the [Components&lt;T&gt;](Components_T_.md 'DefaultEcs.Components&lt;T&gt;').  
```csharp
public readonly ref struct Components<T>
```
#### Type parameters
<a name='DefaultEcs_Components_T__T'></a>
`T`  
The type of the component.
  

| Properties | |
| :--- | :--- |
| [this[Entity]](Components_T__this_Entity_.md 'DefaultEcs.Components&lt;T&gt;.this[DefaultEcs.Entity]') | Gets the component of type [T](Components_T_.md#DefaultEcs_Components_T__T 'DefaultEcs.Components&lt;T&gt;.T') on the provided [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
