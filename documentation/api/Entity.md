#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs](DefaultEcs.md#DefaultEcs 'DefaultEcs')

## Entity Struct

Represents an item in the [World](World.md 'DefaultEcs.World').  
Only use [Entity](Entity.md 'DefaultEcs.Entity') generated from the [CreateEntity()](World.CreateEntity().md 'DefaultEcs.World.CreateEntity()') method.

```csharp
public readonly struct Entity :
System.IDisposable,
System.IEquatable<DefaultEcs.Entity>
```

Implements [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable'), [System.IEquatable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')[Entity](Entity.md 'DefaultEcs.Entity')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.IEquatable-1 'System.IEquatable`1')

| Properties | |
| :--- | :--- |
| [IsAlive](Entity.IsAlive.md 'DefaultEcs.Entity.IsAlive') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') is alive or not. |
| [World](Entity.World.md 'DefaultEcs.Entity.World') | Gets the [World](World.md 'DefaultEcs.World') instance from which current [Entity](Entity.md 'DefaultEcs.Entity') originate. |

| Methods | |
| :--- | :--- |
| [CopyTo(World)](Entity.CopyTo(World).md 'DefaultEcs.Entity.CopyTo(DefaultEcs.World)') | Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World').<br/>This method is not thread safe. |
| [CopyTo(World, ComponentCloner)](Entity.CopyTo(World,ComponentCloner).md 'DefaultEcs.Entity.CopyTo(DefaultEcs.World, DefaultEcs.ComponentCloner)') | Creates a copy of current [Entity](Entity.md 'DefaultEcs.Entity') with all of its components in the given [World](World.md 'DefaultEcs.World') using the given [ComponentCloner](ComponentCloner.md 'DefaultEcs.ComponentCloner').<br/>This method is not thread safe. |
| [Disable()](Entity.Disable().md 'DefaultEcs.Entity.Disable()') | Disables the current [Entity](Entity.md 'DefaultEcs.Entity') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>This method is not thread safe. |
| [Disable&lt;T&gt;()](Entity.Disable_T_().md 'DefaultEcs.Entity.Disable<T>()') | Disables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.Disable_T_().md#DefaultEcs.Entity.Disable_T_().T 'DefaultEcs.Entity.Disable<T>().T') so it does not appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.Disable_T_().md#DefaultEcs.Entity.Disable_T_().T 'DefaultEcs.Entity.Disable<T>().T').<br/>This method is not thread safe. |
| [Dispose()](Entity.Dispose().md 'DefaultEcs.Entity.Dispose()') | Clean the current [Entity](Entity.md 'DefaultEcs.Entity') of all its components.<br/>The current [Entity](Entity.md 'DefaultEcs.Entity') should not be used again after calling this method and [IsAlive](Entity.IsAlive.md 'DefaultEcs.Entity.IsAlive') will return false. |
| [Enable()](Entity.Enable().md 'DefaultEcs.Entity.Enable()') | Enables the current [Entity](Entity.md 'DefaultEcs.Entity') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>This method is not thread safe. |
| [Enable&lt;T&gt;()](Entity.Enable_T_().md 'DefaultEcs.Entity.Enable<T>()') | Enables the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.Enable_T_().md#DefaultEcs.Entity.Enable_T_().T 'DefaultEcs.Entity.Enable<T>().T') so it can appear in [EntitySet](EntitySet.md 'DefaultEcs.EntitySet').<br/>Does nothing if current [Entity](Entity.md 'DefaultEcs.Entity') does not have a component of type [T](Entity.Enable_T_().md#DefaultEcs.Entity.Enable_T_().T 'DefaultEcs.Entity.Enable<T>().T').<br/>This method is not thread safe. |
| [Equals(Entity)](Entity.Equals(Entity).md 'DefaultEcs.Entity.Equals(DefaultEcs.Entity)') | Indicates whether the current object is equal to another object of the same type. |
| [Equals(object)](Entity.Equals(object).md 'DefaultEcs.Entity.Equals(object)') | Indicates whether this instance and a specified object are equal. |
| [Get&lt;T&gt;()](Entity.Get_T_().md 'DefaultEcs.Entity.Get<T>()') | Gets the component of type [T](Entity.Get_T_().md#DefaultEcs.Entity.Get_T_().T 'DefaultEcs.Entity.Get<T>().T') on the current [Entity](Entity.md 'DefaultEcs.Entity'). |
| [GetHashCode()](Entity.GetHashCode().md 'DefaultEcs.Entity.GetHashCode()') | Returns the hash code for this instance. |
| [Has&lt;T&gt;()](Entity.Has_T_().md 'DefaultEcs.Entity.Has<T>()') | Returns whether the current [Entity](Entity.md 'DefaultEcs.Entity') has a component of type [T](Entity.Has_T_().md#DefaultEcs.Entity.Has_T_().T 'DefaultEcs.Entity.Has<T>().T'). |
| [IsEnabled()](Entity.IsEnabled().md 'DefaultEcs.Entity.IsEnabled()') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') is enabled or not. |
| [IsEnabled&lt;T&gt;()](Entity.IsEnabled_T_().md 'DefaultEcs.Entity.IsEnabled<T>()') | Gets whether the current [Entity](Entity.md 'DefaultEcs.Entity') component of type [T](Entity.IsEnabled_T_().md#DefaultEcs.Entity.IsEnabled_T_().T 'DefaultEcs.Entity.IsEnabled<T>().T') is enabled or not. |
| [NotifyChanged&lt;T&gt;()](Entity.NotifyChanged_T_().md 'DefaultEcs.Entity.NotifyChanged<T>()') | Notifies the value of the component of type [T](Entity.NotifyChanged_T_().md#DefaultEcs.Entity.NotifyChanged_T_().T 'DefaultEcs.Entity.NotifyChanged<T>().T') has changed.<br/>This method is not thread safe. |
| [ReadAllComponents(IComponentReader)](Entity.ReadAllComponents(IComponentReader).md 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader)') | Calls on [reader](Entity.ReadAllComponents(IComponentReader).md#DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader 'DefaultEcs.Entity.ReadAllComponents(DefaultEcs.Serialization.IComponentReader).reader') with all the component of the current [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is primiraly used for serialization purpose and should not be called in game logic. |
| [Remove&lt;T&gt;()](Entity.Remove_T_().md 'DefaultEcs.Entity.Remove<T>()') | Removes the component of type [T](Entity.Remove_T_().md#DefaultEcs.Entity.Remove_T_().T 'DefaultEcs.Entity.Remove<T>().T') on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is not thread safe. |
| [Set&lt;T&gt;()](Entity.Set_T_().md 'DefaultEcs.Entity.Set<T>()') | Sets the value of the component of type [T](Entity.Set_T_().md#DefaultEcs.Entity.Set_T_().T 'DefaultEcs.Entity.Set<T>().T') to its default value on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is not thread safe. |
| [Set&lt;T&gt;(T)](Entity.Set_T_(T).md 'DefaultEcs.Entity.Set<T>(T)') | Sets the value of the component of type [T](Entity.Set_T_(T).md#DefaultEcs.Entity.Set_T_(T).T 'DefaultEcs.Entity.Set<T>(T).T') on the current [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is not thread safe. |
| [SetSameAs&lt;T&gt;(Entity)](Entity.SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs<T>(DefaultEcs.Entity)') | Sets the value of the component of type [T](Entity.SetSameAs_T_(Entity).md#DefaultEcs.Entity.SetSameAs_T_(DefaultEcs.Entity).T 'DefaultEcs.Entity.SetSameAs<T>(DefaultEcs.Entity).T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is not thread safe. |
| [SetSameAsWorld&lt;T&gt;()](Entity.SetSameAsWorld_T_().md 'DefaultEcs.Entity.SetSameAsWorld<T>()') | Sets the value of the component of type [T](Entity.SetSameAsWorld_T_().md#DefaultEcs.Entity.SetSameAsWorld_T_().T 'DefaultEcs.Entity.SetSameAsWorld<T>().T') on the current [Entity](Entity.md 'DefaultEcs.Entity') to the same instance of an other [Entity](Entity.md 'DefaultEcs.Entity').<br/>This method is not thread safe. |
| [ToString()](Entity.ToString().md 'DefaultEcs.Entity.ToString()') | Returns a string representation of this instance. |

| Operators | |
| :--- | :--- |
| [operator ==(Entity, Entity)](Entity.operator(Entity,Entity).md 'DefaultEcs.Entity.op_Equality(DefaultEcs.Entity, DefaultEcs.Entity)') | Determines whether two specified entities are the same. |
| [operator !=(Entity, Entity)](Entity.operator!(Entity,Entity).md 'DefaultEcs.Entity.op_Inequality(DefaultEcs.Entity, DefaultEcs.Entity)') | Determines whether two specified entities are not the same. |
