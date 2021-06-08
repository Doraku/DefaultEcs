#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')
## Entity Struct
Represents an item in the [World](World.md 'DefaultEcs.World').  
Only use [Entity](Entity.md 'DefaultEcs.Entity') generated from the [CreateEntity()](World_CreateEntity().md 'DefaultEcs.World.CreateEntity()') method.  
```csharp
public readonly struct Entity :
System.IDisposable,
System.IEquatable<DefaultEcs.Entity>
```

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')  

| Properties | |
| :--- | :--- |
| [IsAlive](Entity_IsAlive.md 'DefaultEcs.Entity.IsAlive') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') is alive or not.<br/> |
| [World](Entity_World.md 'DefaultEcs.Entity.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [Entity](Entity.md 'DefaultEcs.Entity') originate.<br/> |

| Methods | |
| :--- | :--- |
| [CopyTo(World)](Entity_CopyTo(World).md 'DefaultEcs.Entity.CopyTo(DefaultEcs.World)') | Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World').<br/> |
| [CopyTo(World, ComponentCloner)](Entity_CopyTo(World_ComponentCloner).md 'DefaultEcs.Entity.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner)') | Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World') using the given [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner').<br/> |
| [Disable&lt;T&gt;()](Entity_Disable_T_().md 'DefaultEcs.Entity.Disable&lt;T&gt;()') | Disables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity_Disable_T_().md#DefaultEcs_Entity_Disable_T_()_T 'DefaultEcs.Entity.Disable&lt;T&gt;().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity_Disable_T_().md#DefaultEcs_Entity_Disable_T_()_T 'DefaultEcs.Entity.Disable&lt;T&gt;().T').<br/> |
| [Disable()](Entity_Disable().md 'DefaultEcs.Entity.Disable()') | Disables the current [Entity](Entity.md 'DefaultEcs.Entity') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/> |
| [Dispose()](Entity_Dispose().md 'DefaultEcs.Entity.Dispose()') | Clean the current [Entity](Entity.md 'DefaultEcs.Entity') of all its components.<br/>The current [Entity](Entity.md 'DefaultEcs.Entity') should not be used again after calling this method and [IsAlive](Entity_IsAlive.md 'DefaultEcs.Entity.IsAlive') will return false.<br/> |
| [Enable&lt;T&gt;()](Entity_Enable_T_().md 'DefaultEcs.Entity.Enable&lt;T&gt;()') | Enables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity_Enable_T_().md#DefaultEcs_Entity_Enable_T_()_T 'DefaultEcs.Entity.Enable&lt;T&gt;().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity_Enable_T_().md#DefaultEcs_Entity_Enable_T_()_T 'DefaultEcs.Entity.Enable&lt;T&gt;().T').<br/> |
| [Enable()](Entity_Enable().md 'DefaultEcs.Entity.Enable()') | Enables the current [Entity](Entity.md 'DefaultEcs.Entity') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/> |
| [Equals(Entity)](Entity_Equals(Entity).md 'DefaultEcs.Entity.Equals(DefaultEcs.Entity)') | Indicates whether the current object is equal to another object of the same type.<br/> |
| [Equals(object)](Entity_Equals(object).md 'DefaultEcs.Entity.Equals(object)') | Indicates whether this instance and a specified object are equal.<br/> |
| [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()') | Gets the component of type [T](Entity_Get_T_().md#DefaultEcs_Entity_Get_T_()_T 'DefaultEcs.Entity.Get&lt;T&gt;().T') on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [GetHashCode()](Entity_GetHashCode().md 'DefaultEcs.Entity.GetHashCode()') | Returns the hash code for this instance.<br/> |
| [Has&lt;T&gt;()](Entity_Has_T_().md 'DefaultEcs.Entity.Has&lt;T&gt;()') | Returns whether the current [Entity](Entity.md 'DefaultEcs.Entity') has a component of type [T](Entity_Has_T_().md#DefaultEcs_Entity_Has_T_()_T 'DefaultEcs.Entity.Has&lt;T&gt;().T').<br/> |
| [IsEnabled&lt;T&gt;()](Entity_IsEnabled_T_().md 'DefaultEcs.Entity.IsEnabled&lt;T&gt;()') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity_IsEnabled_T_().md#DefaultEcs_Entity_IsEnabled_T_()_T 'DefaultEcs.Entity.IsEnabled&lt;T&gt;().T') is enabled or not.<br/> |
| [IsEnabled()](Entity_IsEnabled().md 'DefaultEcs.Entity.IsEnabled()') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') is enabled or not.<br/> |
| [NotifyChanged&lt;T&gt;()](Entity_NotifyChanged_T_().md 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;()') | Notifies the value of the component of type [T](Entity_NotifyChanged_T_().md#DefaultEcs_Entity_NotifyChanged_T_()_T 'DefaultEcs.Entity.NotifyChanged&lt;T&gt;().T') has changed.<br/> |
| [ReadAllComponents(IComponentReader)](Entity_ReadAllComponents(IComponentReader).md 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader)') | Calls on [reader](Entity_ReadAllComponents(IComponentReader).md#DefaultEcs_Entity_ReadAllComponents(DefaultEcs_Serialization_IComponentReader)_reader 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader') with all the component of the current [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is primiraly used for serialization purpose and should not be called in game logic.<br/> |
| [Remove&lt;T&gt;()](Entity_Remove_T_().md 'DefaultEcs.Entity.Remove&lt;T&gt;()') | Removes the component of type [T](Entity_Remove_T_().md#DefaultEcs_Entity_Remove_T_()_T 'DefaultEcs.Entity.Remove&lt;T&gt;().T') on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [Set&lt;T&gt;()](Entity_Set_T_().md 'DefaultEcs.Entity.Set&lt;T&gt;()') | Sets the value of the component of type [T](Entity_Set_T_().md#DefaultEcs_Entity_Set_T_()_T 'DefaultEcs.Entity.Set&lt;T&gt;().T') to its default value on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [Set&lt;T&gt;(T)](Entity_Set_T_(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') | Sets the value of the component of type [T](Entity_Set_T_(T).md#DefaultEcs_Entity_Set_T_(T)_T 'DefaultEcs.Entity.Set&lt;T&gt;(T).T') on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [SetSameAs&lt;T&gt;(Entity)](Entity_SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') | Sets the value of the component of type [T](Entity_SetSameAs_T_(Entity).md#DefaultEcs_Entity_SetSameAs_T_(DefaultEcs_Entity)_T 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity).T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [SetSameAsWorld&lt;T&gt;()](Entity_SetSameAsWorld_T_().md 'DefaultEcs.Entity.SetSameAsWorld&lt;T&gt;()') | Sets the value of the component of type [T](Entity_SetSameAsWorld_T_().md#DefaultEcs_Entity_SetSameAsWorld_T_()_T 'DefaultEcs.Entity.SetSameAsWorld&lt;T&gt;().T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').<br/> |
| [ToString()](Entity_ToString().md 'DefaultEcs.Entity.ToString()') | Returns a string representation of this instance.<br/> |

| Operators | |
| :--- | :--- |
| [operator ==(Entity, Entity)](Entity_operator(Entity_Entity).md 'DefaultEcs.Entity.op_Equality(DefaultEcs.Entity, DefaultEcs.Entity)') | Determines whether two specified entities are the same. |
| [operator !=(Entity, Entity)](Entity_operator!(Entity_Entity).md 'DefaultEcs.Entity.op_Inequality(DefaultEcs.Entity, DefaultEcs.Entity)') | Determines whether two specified entities are not the same. |
