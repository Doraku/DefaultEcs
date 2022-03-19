#### [DefaultEcs](DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](DefaultEcs.md#DefaultEcs.System 'DefaultEcs.System').[AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>')

## AComponentSystem(World) Constructor

Initialise a new instance of the [AComponentSystem&lt;TState,TComponent&gt;](AComponentSystem_TState,TComponent_.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>') class with the given [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World').

```csharp
protected AComponentSystem(DefaultEcs.World world);
```
#### Parameters

<a name='DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World).world'></a>

`world` [World](World.md 'DefaultEcs.World')

The [World](AComponentSystem_TState,TComponent_.World.md 'DefaultEcs.System.AComponentSystem<TState,TComponent>.World') on which to process the update.

#### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')  
[world](AComponentSystem_TState,TComponent_.AComponentSystem(World).md#DefaultEcs.System.AComponentSystem_TState,TComponent_.AComponentSystem(DefaultEcs.World).world 'DefaultEcs.System.AComponentSystem<TState,TComponent>.AComponentSystem(DefaultEcs.World).world') is null.