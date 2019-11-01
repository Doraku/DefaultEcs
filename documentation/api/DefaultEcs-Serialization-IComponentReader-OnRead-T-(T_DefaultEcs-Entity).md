#### [DefaultEcs](./index.md 'index')
### [DefaultEcs](./index.md 'index').[DefaultEcs.Serialization](./DefaultEcs-Serialization.md 'DefaultEcs.Serialization').[IComponentReader](./DefaultEcs-Serialization-IComponentReader.md 'DefaultEcs.Serialization.IComponentReader')
## IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity) Method
Processes the component of type [T](#DefaultEcs-Serialization-IComponentReader-OnRead-T-(T_DefaultEcs-Entity)-T 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity).T').  
```C#
void OnRead<T>(ref T component, in DefaultEcs.Entity componentOwner);
```
#### Type parameters
<a name='DefaultEcs-Serialization-IComponentReader-OnRead-T-(T_DefaultEcs-Entity)-T'></a>
`T`  
The type of component.  
#### Parameters
<a name='DefaultEcs-Serialization-IComponentReader-OnRead-T-(T_DefaultEcs-Entity)-component'></a>
component [T](#DefaultEcs-Serialization-IComponentReader-OnRead-T-(T_DefaultEcs-Entity)-T 'DefaultEcs.Serialization.IComponentReader.OnRead&lt;T&gt;(T, DefaultEcs.Entity).T')  
The component.  
<a name='DefaultEcs-Serialization-IComponentReader-OnRead-T-(T_DefaultEcs-Entity)-componentOwner'></a>
componentOwner [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity')  
The owner of the component instance, in case it is used by multiple [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity').  
