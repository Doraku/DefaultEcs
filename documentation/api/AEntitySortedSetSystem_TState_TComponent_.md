#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs_System 'DefaultEcs.System')
## AEntitySortedSetSystem&lt;TState,TComponent&gt; Class
Represents a base class to process updates on a given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') instance.  
Only [Get&lt;T&gt;()](Entity_Get_T_().md 'DefaultEcs.Entity.Get&lt;T&gt;()'), [Set&lt;T&gt;(T)](Entity_Set_T_(T).md 'DefaultEcs.Entity.Set&lt;T&gt;(T)') and [SetSameAs&lt;T&gt;(Entity)](Entity_SetSameAs_T_(Entity).md 'DefaultEcs.Entity.SetSameAs&lt;T&gt;(DefaultEcs.Entity)') operation on already present component type are safe.  
```csharp
public abstract class AEntitySortedSetSystem<TState,TComponent> :
DefaultEcs.System.ISystem<TState>,
System.IDisposable
```
#### Type parameters
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TState'></a>
`TState`  
The type of the object used as state to update the system.
  
<a name='DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TComponent'></a>
`TComponent`  
The type of the component to sort [Entity](Entity.md 'DefaultEcs.Entity') by.
  

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AEntitySortedSetSystem&lt;TState,TComponent&gt;  

Implements [DefaultEcs.System.ISystem&lt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;')[TState](AEntitySortedSetSystem_TState_TComponent_.md#DefaultEcs_System_AEntitySortedSetSystem_TState_TComponent__TState 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.TState')[&gt;](ISystem_T_.md 'DefaultEcs.System.ISystem&lt;T&gt;'), [System.IDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IDisposable 'System.IDisposable')  

| Constructors | |
| :--- | :--- |
| [AEntitySortedSetSystem(EntitySortedSet&lt;TComponent&gt;)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(EntitySortedSet_TComponent_).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet&lt;TComponent&gt;)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').<br/> |
| [AEntitySortedSetSystem(EntitySortedSet&lt;TComponent&gt;, bool)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(EntitySortedSet_TComponent__bool).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.EntitySortedSet&lt;TComponent&gt;, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;').<br/> |
| [AEntitySortedSetSystem(World)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.<br/> |
| [AEntitySortedSetSystem(World, bool)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World_bool).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.<br/> |
| [AEntitySortedSetSystem(World, Func&lt;object,World,EntitySortedSet&lt;TComponent&gt;&gt;)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World_Func_object_World_EntitySortedSet_TComponent__).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySortedSet&lt;TComponent&gt;&gt;)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>The current instance will be passed as the first parameter of the factory.<br/> |
| [AEntitySortedSetSystem(World, Func&lt;object,World,EntitySortedSet&lt;TComponent&gt;&gt;, bool)](AEntitySortedSetSystem_TState_TComponent__AEntitySortedSetSystem(World_Func_object_World_EntitySortedSet_TComponent___bool).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.AEntitySortedSetSystem(DefaultEcs.World, System.Func&lt;object,DefaultEcs.World,DefaultEcs.EntitySortedSet&lt;TComponent&gt;&gt;, bool)') | Initialise a new instance of the [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') class with the given [World](World.md 'DefaultEcs.World') and factory.<br/>To create the inner [EntitySet](EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.<br/> |

| Properties | |
| :--- | :--- |
| [IsEnabled](AEntitySortedSetSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.IsEnabled') | Gets or sets whether the current [AEntitySortedSetSystem&lt;TState,TComponent&gt;](AEntitySortedSetSystem_TState_TComponent_.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;') instance should update or not.<br/> |
| [SortedSet](AEntitySortedSetSystem_TState_TComponent__SortedSet.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.SortedSet') | Gets the [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') instance on which this system operates.<br/> |
| [World](AEntitySortedSetSystem_TState_TComponent__World.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.World') | Gets the [World](World.md 'DefaultEcs.World') instance on which this system operates.<br/> |

| Methods | |
| :--- | :--- |
| [Dispose()](AEntitySortedSetSystem_TState_TComponent__Dispose().md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.Dispose()') | Disposes of the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') instance.<br/> |
| [PostUpdate(TState)](AEntitySortedSetSystem_TState_TComponent__PostUpdate(TState).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.PostUpdate(TState)') | Performs a post-update treatment.<br/> |
| [PreUpdate(TState)](AEntitySortedSetSystem_TState_TComponent__PreUpdate(TState).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.PreUpdate(TState)') | Performs a pre-update treatment.<br/> |
| [Update(TState)](AEntitySortedSetSystem_TState_TComponent__Update(TState).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.Update(TState)') | Updates the system once.<br/>Does nothing if [IsEnabled](AEntitySortedSetSystem_TState_TComponent__IsEnabled.md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.IsEnabled') is false or if the inner [EntitySortedSet&lt;TComponent&gt;](EntitySortedSet_TComponent_.md 'DefaultEcs.EntitySortedSet&lt;TComponent&gt;') is empty.<br/> |
| [Update(TState, Entity)](AEntitySortedSetSystem_TState_TComponent__Update(TState_Entity).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.Update(TState, DefaultEcs.Entity)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instance once.<br/> |
| [Update(TState, ReadOnlySpan&lt;Entity&gt;)](AEntitySortedSetSystem_TState_TComponent__Update(TState_ReadOnlySpan_Entity_).md 'DefaultEcs.System.AEntitySortedSetSystem&lt;TState,TComponent&gt;.Update(TState, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)') | Update the given [Entity](Entity.md 'DefaultEcs.Entity') instances once.<br/> |
