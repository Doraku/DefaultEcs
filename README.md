![DefaultEcs](https://github.com/Doraku/DefaultEcs/blob/master/image/DefaultEcsLogo.png)
DefaultEcs is an [Entity Component System](https://en.wikipedia.org/wiki/Entity_component_system) framework which aims to be accessible with little constraints while retaining as much performance as possible for game development.

[![NuGet](https://buildstats.info/nuget/DefaultEcs)](https://www.nuget.org/packages/DefaultEcs)
[![Coverage Status](https://coveralls.io/repos/github/Doraku/DefaultEcs/badge.svg?branch=master)](https://coveralls.io/github/Doraku/DefaultEcs?branch=master)
![continuous integration status](https://github.com/doraku/defaultecs/workflows/continuous%20integration/badge.svg)
[![preview package](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultEcs/packages/26448)
[![Join the chat at https://gitter.im/Doraku/DefaultEcs](https://badges.gitter.im/Doraku/DefaultEcs.svg)](https://gitter.im/Doraku/DefaultEcs?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

- [Api documentation](./documentation/api/DefaultEcs.md 'Api documentation')
- [FAQ](./documentation/FAQ.md 'Frequently Asked Questions')
- [Benchmarks](https://github.com/Doraku/Ecs.CSharp.Benchmark)
<a/>

- [Requirement](#Requirement)
- [Versioning](#Versioning)
- [Analyzer](#Analyzer)
- [Overview](#Overview)
  - [World](#Overview_World)
    - [Message](#Overview_Message)
  - [Entity](#Overview_Entity)
  - [Component](#Overview_Component)
    - [Singleton](#Overview_Singleton)
    - [Resource](#Overview_Resource)
  - [Query](#Overview_Query)
    - [AsPredicate](#Overview_Query_AsPredicate)
    - [AsEnumerable](#Overview_Query_AsEnumerable)
    - [AsSet](#Overview_Query_AsSet)
    - [AsMap](#Overview_Query_AsMap)
    - [AsMultiMap](#Overview_Query_AsMultiMap)
  - [System](#Overview_System)
    - [ISystem](#Overview_System_ISystem)
    - [ActionSystem](#Overview_System_ActionSystem)
    - [SequentialSystem](#Overview_System_SequentialSystem)
    - [ParallelSystem](#Overview_System_ParallelSystem)
    - [AComponentSystem](#Overview_System_AComponentSystem)
    - [AEntitySetSystem](#Overview_System_AEntitySetSystem)
    - [AEntityMultiMapSystem](#Overview_System_AEntityMultiMapSystem)
  - [Threading](#Overview_Threading)
    - [IParallelRunnable](#Overview_Threading_IParallelRunnable)
    - [IParallelRunner](#Overview_Threading_IParallelRunner)
    - [DefaultParallelRunner](#Overview_Threading_DefaultParallelRunner)
  - [Command](#Overview_Command)
  - [Serialization](#Overview_Serialization)
    - [TextSerializer](#Overview_Serialization_TextSerializer)
    - [BinarySerializer](#Overview_Serialization_BinarySerializer)
- [Extension](#Extension)
- [Sample](#Sample)
- [Projects using DefaultEcs](#Projects)
- [Dependencies](#Dependencies)

<a name='Requirement'></a>
# Requirement
DefaultEcs heavily uses features from C#7.0 and Span from the System.Memory package, compatible from .NETStandard 1.1.  
For development, a C#9.0 compatible environment, net framework 4.8, netcore 3.1 and net5 are required to build and run all tests (it is possible to disable some target in the test project if needed).  
It is possible to use DefaultEcs in Unity (check [FAQ](./documentation/FAQ.md#unity)).

<a name='Versioning'></a>
# Versioning
This is the current strategy used to version DefaultEcs: v0.major.minor
- 0: DefaultEcs is still in heavy development and although a lot of care is given to not break the current api, it can still happen
- major: incremented when there is a breaking change (reset minor number)
- minor: incremented when there is a new feature or a bug fix

<a name='Analyzer'></a>
# Analyzer
To help development with DefaultEcs, there is a roslyn analyzer which provides code generator and warnings against potential bad usages. It can be found [here](https://github.com/Doraku/DefaultEcs.Analyzer).

<a name='Overview'></a>
# Overview
<a name='Overview_World'></a>
## World
The World class act as the central hub to create entities, query specific entities,  get all components for a given type or publish and subscribe to messages that can be used to communicate across types.  
Multiple World objects can be used in parallel, each instance being thread-safe from one another but operations performed on a single instance and all of its created items should be thought as non thread-safe. Depending on what is done, it is still possible to process operations concurrently to optimise performance.

Worlds are created as such
```csharp
World world = new World();
```

The World class also implement the `IDisposable` interface so you can easily cleanup an instance resources by disposing it.

<a name='Overview_Message'></a>
### Message
It is possible to send and receive message transiting in a World.
```csharp
void On(in bool message) { }

// the method On will be called back every time a bool object is published
// it is possible to use any type
world.Subscribe<bool>(On);

world.Publish(true);
```

It is also possible to subscribe to multiple method of an instance by using the SubscribeAttribute:
```csharp
public class Dummy
{
    [Subscribe]
    void On(in bool message) { }
	
    [Subscribe]
    void On(in int message) { }
	
    void On(in string message) { }
}

Dummy dummy = new Dummy();

// this will subscribe the decorated methods only
world.Subscribe(dummy);

// the dummy bool method will be called
world.Publish(true);

// but not the string one as it dit not have the SubscribeAttribute
world.Publish(string.Empty);
```

Note that the Subscribe method return an IDisposable object acting as a subscription. To unsubscribe, simply dispose this object.

<a name='Overview_Entity'></a>
## Entity
Entities are simple struct acting as a key to manage components.

Entities are created as such
```csharp
Entity entity = world.CreateEntity();
```

You should not store entities yourself and rely as much as possible on returned object from a world query as those will be updated accordingly to component changes.  
To clear an entity, simply call its `Dispose` method.
```csharp
entity.Dispose();
```

Once disposed, you should not use the entity again. If you need a safeguard, you can check the `IsAlive` property:
```csharp
#if DEBUG
if (!entity.IsAlive)
{
    // something is wrong
}
#endif
```

You can also make an entity act as if it was disposed so it is removed from world queries while keeping all its components, this is usefull when you need to activate/diactivate entity from your game logic
```csharp
entity.Disable();

// this will return false;
entity.IsEnabled();

entity.Enable();

// and now it will return true;
entity.IsEnabled();
```

<a name='Overview_Component'></a>
## Component
Components are not restricted by any heritage hierarchy. It is recommanded that component objects only hold data and to be struct to generate as little as possible garbage and to have them contiguous in memory but you can use class type and interface too.
```csharp
public struct Example
{
    public float Value;
}

public interface IExample
{
    float Value { get; set; }
}

public class CExample : IExample
{
    public float Value { get; set; }
}
```

To reduce memory usage, it is possible to set a maximum capacity for a given component type. If nothing is set, then the maximum entity count of the world will be used. This call need to be done before any component of the specified type is set.
```csharp
world.SetMaxCapacity<Example>(42);
```

Components can live on two level, on entities or directly on the world itself.
```csharp
entity.Set<int>(42);

// check if the entity has an int component
if (entity.Has<int>())
{
    // get the int component of the entity
    if (--entity.Get<int>() <= 0)
    {
        // remove the int component from the entity
        entity.Remove<int>();
    }
}

// all those methods are also available on the World type
world.Set<int>(42);

if (world.Has<int>() && --world.Get<int>() <= 0)
{
    world.Remove<int>();
}

// be carefull that the component type is specific to the method generic parameter type, not the component type
entity.Set<IExample>(new CExample());

// this will return false as the component type previously set is IExample, not CExample
entity.Has<CExample>();
```

It is possible to share the same component value between entities or even the world value. This is usefull if you want to update a component value on multiple entities with a single call.
```csharp
referenceEntity.Set<int>(42);
entity.SetSameAs<int>(referenceEntity);

referenceEntity.Set<int>(1337);
// the value for entity will also be 1337
entity.Get<int>();

world.Set<string>("hello");
entity.SetSameAsWorld<string>();
world.Set<string>("world");
// the value for entity will also be "world"
entity.Get<string>();
```
If the component is removed from the entity used as reference or the world, it will not remove the component from the other entities using the same component.

Component on entities can also be disabled and reenabled. This is usefull if you want to quickly make an entity act as if its component composition has changed so it is picked up by world queries without paying the price to actually remove a component.
```csharp
entity.Disable<int>();

// this still return true
entity.Has<int>();
// but this will return false
entity.IsEnabled<int>();

entity.Enable<int>();
// now this will return true
entity.IsEnabled<int>();
```

There is two way to update a component value, either use the `Set<T>(newValue)` method or setting/editing the value returned by `Get<T>()`. One major difference between the two is that `Set<T>(newValue)` will also notify internal queries that the component value has changed.
```csharp
entity.Set<int>(42);

// we set a new value
entity.Set<int>(1337);

ref int component = ref entity.Get<int>();
// we have actually changed the component value but the internal queries have not been notified.
component = 42;

// we can notify manually by calling this method if we need to.
entity.NotifyChanged<int>();
```

<a name='Overview_Singleton'></a>
### Singleton
By combining the previous calls, it is possible to define a component type as a singleton:
```
// only one component value for int can exist on this world
world.SetMaxCapacity<int>(1);

// and it is used by the world
world.Set<int>(42);

// entity.Set<int>(10); this line would throw
// the only way to set the component on entities would be to use the world component
entity.SetSameAsWorld<int>();
```

<a name='Overview_Resource'></a>
### Resource
Not all components can easily be serialized to be loaded from data file (texture, sound, ...). To help with the handling of those cases, helper types are provided to give a way to load managed resources, shared across entities and even worlds, and automatically dispose them once no entity using them exist anymore.  
To setup a managed resource on an entity, the type `ManagedResource<TInfo, TResource>` need to be set as a component where TInfo is a type used as a single identifier for a single resource and information needed to load it, and TResource is the type of the resource.  
Should multiple resource of the same type be needed on a single entity, it is also possible to set the type `ManagedResource<TInfo[], TResource>` as component.  
If the `ManagedResource` component is removed from the entity or the entity holding it disposed, the internal reference count on the resource will decrease and it will be disposed if zero is reached.  
To actually load the resource, an implementation of the class `AResourceManager<TInfo, TResource>` is need as shown in the next exemple:
```csharp
// TInfo is string, the name of the texture and TResource is Texture2D
public sealed class TextureResourceManager : AResourceManager<string, Texture2D>
{
    private readonly GraphicsDevice _device;
    private readonly ITextureLoader _loader;

    // ITextureLoader is the actual loader, not shown here
    public TextureResourceManager(GraphicsDevice device, ITextureLoader loader)
    {
        _device = device;
        _loader = loader;
    }

    // this will only be called if the texture with the key info has never been loaded yet or it has previously been disposed because it was not used anymore
    protected override Texture2D Load(string info) => _loader.Load(_device, info);

    // this is the callback method where the entity with the ManagedResource<string, Texture2D> component is set, the TInfo and the resource are given do act as needed
    protected override void OnResourceLoaded(in Entity entity, string info, Texture2D resource)
    {
        // here we just set the texture to a field of an other component of the entity which contains all the information needed to draw it (position, size, origin, rotation, texture, ...)
        entity.Get<DrawInfo>().Texture = resource;
    }
}

// we simply set the special component like any other one
entity.Set(new ManagedResource<string, Texture2D>("square.png"));

// or we could set multiple resources like this
entity.Set(new ManagedResource<string[], Texture2D>(new [] { "square.png", "circle.png" }));

// you can also use the helper class
entity.Set(ManagedResource<Texture2D>.Create("square.png")); // set up a ManagedResource<string, Texture2D>
entity.Set(ManagedResource<Texture2D>.Create("square.png", "circle.png")); // set up a ManagedResource<string[], Texture2D>

// this is how to set up a resource manager on a world, it will process all curently existing entities with the special component type, and react to all futur entities also
textureResourceManager.Manage(_world);
```
This feature only care for entities component, not the world component.

<a name='Overview_Query'></a>
## Query
To perform operation, systems should query entities from the world. This is performed by requesting entities through the world and using the fluent api to create rules
```csharp
world
    .GetEntities() // this is the starting point of a query, you can also query disabled entities with GetDisabledEntities()
    .With<int>().With<double>() // require that entities have both an int and double components
    .Without<string>().Without<char>() // require that entities do not have both a string nor a char component
    .WithEither<long>().Or<ulong>() // require that entities have either a long or ulong component
    .WithoutEither<short>().Or<ushort>() // require that entities doe no have either a short or a ushort component
    ...
    .WhenAdded<int>() // require that entities have just been added an int component
    .WhenChanged<int>() // require that entities have their int component changed
    .WhenRemoved<string>() // require that entities have their string component removed
    ...
```
Once you are satified with the rules you can then finish the query by chosing how to get the entities.

<a name='Overview_Query_AsPredicate'></a>
### AsPredicate
```csharp
world
    .GetEntities()
    ...
    .AsPredicate();
```
Get a `Predicate<Entity>` that check for your declared rules. `When...` rules are ignored.  
This is usefull if you need to check for some entity component composition.

<a name='Overview_Query_AsEnumerable'></a>
### AsEnumerable
```csharp
world
    .GetEntities()
    ...
    .AsEnumerable();
```
Get a `IEnumerable<Entity>` that when enumerated returns all the entities respecting your declared rules. `When...` rules are ignored.  
This is usefull if you need to do an initialisation on specific entities, this should not be used in a hot path.

<a name='Overview_Query_AsSet'></a>
### AsSet
```csharp
world
    .GetEntities()
    ...
    .AsSet();
```
Get a `EntitySet` containing all entities respecting your declared rules. Its content is cached for fast access and is automatically updated as you change your entities composition.
If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.
This is the base type used in the provided system implementation.

<a name='Overview_Query_AsMap'></a>
### AsSet
```csharp
world
    .GetEntities()
    ...
    .AsMap<TKey>();
```
Get a `EntityMap<TKey>` which map a single entity with a component type `TKey` value. Its content is cached for fast access and is automatically updated as you change your entities composition.
If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.
This is usefull if you need o(1) access to an entity based on a key.

<a name='Overview_Query_AsMultiMap'></a>
### AsSet
```csharp
world
    .GetEntities()
    ...
    .AsMultiMap<TKey>();
```
Get a `EntityMultiMap<TKey>` which map multiple entities with a component type `TKey` value. Its content is cached for fast access and is automatically updated as you change your entities composition.
If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.
This is usefull if you need o(1) access to entities based on a key.

<a name='Overview_System'></a>
## System
Although there is no obligation, a set of base classes are provided to help the creation of systems:
<a name='Overview_System_ISystem'></a>
### ISystem
This is a base interface for all the systems. it exposes an `Update` method and an `IsEnabled` property. In all derived types provided in DefaultEcs, the responsibility to check this property is handled by the callee, not the caller. It is set to true by default.

<a name='Overview_System_ActionSystem'></a>
### ActionSystem
This class is used to quickly make a system with a given custom action to be called on every update.
```csharp
private void Exit(float elaspedTime)
{
    if (EscapedIsPressed)
    {
        // escape code
    }
}

...

ISystem<float> system = new ActionSystem<float>(Exit);

...

// this will call the Exit method as a system
system.Update(elapsedTime);
```

<a name='Overview_System_SequentialSystem'></a>
### SequentialSystem
This class is used to easily create a list of system to be updated in a sequential order.
```csharp
ISystem<float> system = new SequentialSystem<float>(
    new InputSystem(),
    new AISystem(),
    new PositionSystem(),
    new DrawSystem()
);
...

// this will call in order InputSystem, AISystem, PositionSystem and DrawSystem
syste

<a name='Overview_System_ParallelSystem'></a>
### ParallelSystem
This class is used to easily create a list of system to be updated in parallel.
```csharp
ISystem<float> system = new ParallelSystem<float>(
    new DefaultParallelRunner(Environment.ProcessorCount),    
    new System1(),
    new System2(),
    new System3(),
    new System4()
);
...

// this will call all systems in parallel
```

<a name='Overview_System_AComponentSystem'></a>
### AComponentSystem
This is a base class to create system to update a specific component type from a given World.
```csharp
public class DrawSystem : AComponentSystem<float, DrawInfo>
{
    private readonly SpriteBatch _batch;
    private readonly Texture2D _square;

    public DrawSystem(SpriteBatch batch, Texture2D square, World world)
        : base(world)
    {
        _batch = batch;
        _square = square;
    }

    protected override void PreUpdate()
    {
        _batch.Begin();
    }

    protected override void Update(float elaspedTime, ref DrawInfo component)
    {
        _batch.Draw(_square, component.Destination, component.Color);
    }

    protected override void PostUpdate()
    {
        _batch.End();
    }
}
```
Note that components do not have to reside on an entities to be processed by such a system (world components) and their enable/disable state on their owning entity is ignored.

<a name='Overview_System_AEntitySetSystem'></a>
### AEntitySetSystem
This is a base class to create system to update a given EntitySet.
```csharp
public sealed class VelocitySystem : AEntitySetSystem<float>
{
    public VelocitySystem(World world, IParallelRunner runner)
        : base(world.GetEntities().With<Velocity>().With<Position>().AsSet(), runner)
    {
    }

    protected override void Update(float elaspedTime, in Entity entity)
    {
        ref Velocity velocity = ref entity.Get<Velocity>();
        ref Position position = ref entity.Get<Position>();

        Vector2 offset = velocity.Value * elaspedTime;

        position.Value.X += offset.X;
        position.Value.Y += offset.Y;
    }
}
```

It is also possible to declare the needed component by using the WithAttribute and WithoutAttribute on the system type.
```csharp
[With(typeof(Velocity)]
[With(typeof(Position)]
public sealed class VelocitySystem : AEntitySetSystem<float>
{
    public VelocitySystem(World world, IParallelRunner runner)
        : base(world, runner)
    {
    }

    protected override void Update(float elaspedTime, in Entity entity)
    {
        ref Velocity velocity = ref entity.Get<Velocity>();
        ref Position position = ref entity.Get<Position>();

        Vector2 offset = velocity.Value * elaspedTime;

        position.Value.X += offset.X;
        position.Value.Y += offset.Y;
    }
}
```
    - [AEntityMultiMapSystem](#Overview_System_AEntityMultiMapSystem)

<a name='Overview_System_AEntityMultiMapSystem'></a>
### AEntityMultiMapSystem
This is a base class to create system to update a given EntityMultiMap. If the key implemente `IComparable`, they keys will processed in a sorted order, or you can give your own key order.
```csharp
public sealed class LayerSystem : AEntityMultiMapSystem<float, Layer>
{
    // we define the layers order
    private static readonly Layer[] _layers = new[]
    {
        Layer.Background,
        Layer.Unit,
        Layer.Particle,
        Layer.Ui
    };

    [ConstructorParameter]
    private readonly SpriteBatch _batch;
    
    public LayerSystem(SpriteBatch batch, World world)
        : base(world.GetEntities().With<DrawInfo>().AsMultiMap<Layer>())
    {
        _batch = batch;
    }

    protected override Span<Layer> GetKeys() => _layers.AsSpan();

    // entities will be drawn layer by layer
    protected override void Update(float state, in Layer key, in Entity entity) => _batch.Draw(drawInfo.Texture, drawInfo.Position, null, drawInfo.Color, drawInfo.Rotation, drawInfo.Origin, drawInfo.Size, SpriteEffects.None, 0f);
}
```

<a name='Overview_Threading'></a>
## Threading
Some systems are compatible with multithreading execution: ParallelSystem, AEntitySetSystem and AComponentSystem. This is done by passing a IParallelRunner to their respective constructor.
```csharp
IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

ISystem<float> system = new VelocitySystem(world, runner);

// this will process the update on Environment.ProcessorCount threads
system.Update(elaspedTime);
```
It is safe to run a system with multithreading when:
* for an AEntitySetSystem
  * each entity can be safely updated separately with no dependency to an other entity
  * there is no new Set, Remove or Dispose action on entity (only read or update)
* for an AComponentSystem
  * each component can be safely updated separately with no dependency to an other component

<a name='Overview_Threading_IParallelRunnable'></a>
### IParallelRunnable
This interface allow the creation of custom parallelisable process by an IParallelRunner.
```csharp
IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

public class CustomRunnable : IParallelRunnable
{
    public void Run(int index, int maxIndex)
    {
        // a runnable is separated in (maxIndex + 1) part to run in parallel, index gives you the part running
    }
}

runner.Run(new CustomRunnable());
```

<a name='Overview_Threading_IParallelRunner'></a>
### IParallelRunner
This interface allow the creation of custom parallel execution.
```csharp
public class TaskRunner : IParallelRunner
{
    int DegreeOfParallelism { get; }

    public void Run(IParallelRunnable runnable) Enumerable.Range(0, DegreeOfParallelism).AsParallel().ForAll(i => runnable.Run(i, DegreeOfParallelism));
}
```

<a name='Overview_Threading_DefaultParallelRunner'></a>
### DefaultParallelRunner
This is the default implementation of IParallelRunner. it uses exclusive Task to run an IParallelRunnable and only return when the full runnable has been processed. When `index == maxIndex` this is the calling thread.  
It is safe to reuse the same DefaultParallelRunner in multiple system but it should not be used in parallel itself.
```csharp
IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

// wrong
ISystem<float> system = new ParallelSystem<float>(runner,
    new ParallelSystem1(runner),
    new ParallelSystem2(runner));
    
// ok
ISystem<float> system = new SequentialSystem<float>(
    new ParallelSystem1(runner),
    new ParallelSystem2(runner));
```

<a name='Overview_Command'></a>
## Command
Since it is not possible to make structural modification on an Entity in a multithreading  context, the EntityCommandRecorder type is provided to adress this short-coming.  
It is possible de record command on entities in a thread-safe way to later execute them when those structural modifications are safe to do.
```csharp
// This creates an expandable recorder with a default capacity of 1Ko
EntityCommandRecorder recorder = new EntityCommandRecorder();

// This creates a fixed capacity recorder of .5Ko
EntityCommandRecorder recorder = new EntityCommandRecorder(512);

// This creates an expandable recorder with a default capacity of .5Ko which can have a maximum capacity of 2Ko
EntityCommandRecorder recorder = new EntityCommandRecorder(512, 2048);
```

Note that a fixed capacity EntityCommandRecorder (or one which has expanded to its max capacity) has better performance.  
When needed, an expandable EntityCommandRecorder will double its capacity so it is preferred to use a power of 2 as default capacity.

```csharp
// Create a new Entity defered and give an EntityRecord to record commands on it
EntityRecord newRecord = recorder.CreateEntity();

// Register an Entity and give an EntityRecord to record commands on it
EntityRecord record = recorder.Record(entity);

// EntityRecord has the same API as Entity so all action expected are available to record as command this way
newRecord.Set<bool>(true);

// To execute all recorded commands
recorder.Execute(world);
```

<a name='Overview_Serialization'></a>
## Serialization
DefaultEcs support serialization to save and load a World state. Two implementations are provided which are equals in feature and it is possible to create a custom serialization engine using the framework of your choice by implementing a set of interfaces.

- ISerializer is the base interface
- IComponentTypeReader is used to get the settings of the serialized World in case a component max capacity has been set for a specific type different from the world max capacity
- IComponentReader is used to get all the components of an Entity

The provided implementation TextSerializer and BinarySerializer are highly permissive and will serialize every fields and properties even if the are private or readonly and do not require any attribute decoration to work.  
This was a target from the get go as graphic and framework libraries do not always have well decorated type which would be used as component.  
Although the lowest target is netstandard1.1, please be aware that the capability of both implementation to handle type with no default constructor maybe not work if the version of your .NET plateform is too low. Other known limitations are:
- do not handle multidimensional arrays
- do not handle cyclic object graph (all objects are copied, thus creating an infinit loop)
- not compatible with Xamarin.iOS, AOT platforms (use System.Reflection.Emit namespace)


```csharp
ISerializer serializer = new TextSerializer();

using (Stream stream = File.Create(filePath))
{
    serializer.Serialize(stream, world);
}

using (Stream stream = File.OpenRead(filePath))
{
    World worldCopy = serializer.Deserialize(stream);
}
```
Each implementation has its own serialization context which can be used to transform a given type to something else or just change the value at serialization and deserialization time.
```csharp
using BinarySerializationContext context = new BinarySerializationContext()
    .Marshal<string, string>(_ => null) // set every string as null during serialization
    .Marshal<NonSerializableData, SerializableData>(d => new SerializableData(d)) // transform non serializable data to a serializable type during serialization
    .Unmarshal<SerializableData, NonSerializableData>(d => Load(d)); // reload non serializable data from serializable data during deserialization

BinarySerializer serializer = new BinarySerializer(context);
```

<a name='Overview_Serialization_TextSerializer'></a>
### TextSerializer
The purpose of this serializer is to provide a readable save format which can be edited by hand.
```
// declare the maximum number of entity in the World, this must be before any Entity or ComponentMaxCapacity line
WorldMaxCapacity 42

// this line is used to define an alias for a type used as component inside the world and must be declared before being used
ComponentType Int32 System.Int32, System.Private.CoreLib

// this line is used to set the max capacity for the given type, in case it is different from the world max capacity
ComponentMaxCapacity Int32 13

// this create a new entity with the id "Foo"
Entity Foo

// this line set the component of the type with the alias Int32 on the previously created Entity to the value 13
Component Int32 13

// let's say we have the type defined as such already declared with the alias Test
// struct Test
// {
//     int Hello
//     int World
// }
ComponentType Test MyNamespace.Text, MyLib

// composite objects are setted like this
Component Test {
	Hello 666
	// this line is ignored since the type does not have a member with the name Wow
	// also the World member will have its default value since not present
	Wow 42
}

// this create a new entity with no id
Entity

// this sets the component of the type with the alias Test of the previously created Entity as the same as the one of the Entity with the id Foo
ComponentSameAs Test Foo
```
<a name='Overview_Serialization_BinarySerializer'></a>
### BinarySerializer
This serializer is optimized for speed and file space.

<a name='Extension'></a>
# Extension
A DefaultEcs.Extension project is present to show how other features can be built upon the base framework. Those features are just provided as example and are not part of DefaultEcs because the implementation is not generic nor satisfactory enough.
- [Children](https://github.com/Doraku/DefaultEcs/blob/master/source/DefaultEcs.Extension/Children/EntityExtension.cs) makes so entities can be linked together so disposing the parent will also dispose its children
- [Hierarchy](https://github.com/Doraku/DefaultEcs/tree/master/source/DefaultEcs.Extension/Hierarchy) show an example on how to create hierarchy level between entities so parents are processed before their children

<a name='Sample'></a>
# Sample
Some sample projects are available to give a better picture on how to use DefaultEcs. Those exemples were done relatively fast so they are probably not the best representation of the Entity Component System framework application.

[DefaultBoids](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBoids)

[![DefaultBoids](https://img.youtube.com/vi/yEdcqOTCteY/0.jpg)](https://youtu.be/yEdcqOTCteY)

A really simple implementation of a [boids simulation](https://en.wikipedia.org/wiki/Boids), here displaying 30k boids with an old Intel Core i5-3570K CPU 3.40GHz at ~70fps.  
This project use code generation from [DefaultEcs.Analyzer](https://github.com/Doraku/DefaultEcs.Analyzer) for its systems whenever possible.

[DefaultBrick](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBrick)
[win10-x64](https://github.com/Doraku/DefaultEcs/releases/download/v0.9.0/DefaultBrick_win10-x64.zip)

![](https://github.com/Doraku/DefaultEcs/raw/master/image/defaultbrick.gif)

Basic breakout clone. The collision is buggy! As said not much time was spent debuging those. Ball moves faster as the more bricks you destroy and reset to default speed if lost. The stage reload once completed.  
This project do not use attribute for system query, everything is statically declared.

[DefaultSlap](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultSlap)
[win10-x64](https://github.com/Doraku/DefaultEcs/releases/download/v0.9.0/DefaultSlap_win10-x64.zip)

![](https://github.com/Doraku/DefaultEcs/raw/master/image/defaultslap.gif)

Basic fly swatter clone. Every five seconds, flies (blue square) will damage the player (up to 3 times until the "game" resets) and new ones will spawn.  
This project use attributes for system query.

<a name='Projects'></a>
# Projects using DefaultEcs
Your game uses DefaultEcs? Don't hesitate to contact me.  

[![Chambers of Anubis](https://img.itch.zone/aW1nLzQ2MDYzODcucG5n/original/IALw4S.png)](https://github.com/PodeCaradox/HellowIInJam)

<a name='Dependencies'></a>
# Dependencies
CI, tests and code quality rely on those awesome projects:
- [Coverlet](https://github.com/coverlet-coverage/coverlet)
- [NFulent](https://github.com/tpierrain/NFluent)
- [NSubstitute](https://github.com/nsubstitute/NSubstitute)
- [Roslynator](https://github.com/JosefPihrt/Roslynator)
- [XUnit](https://github.com/xunit/xunit)