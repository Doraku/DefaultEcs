![DefaultEcs](https://github.com/Doraku/DefaultEcs/blob/master/image/DefaultEcsLogo.png)
DefaultEcs is an [Entity Component System](https://en.wikipedia.org/wiki/Entity_component_system) framework which aims to be accessible with little constraints while retaining as much performance as possible for game development.

[![NuGet](https://buildstats.info/nuget/DefaultEcs)](https://www.nuget.org/packages/DefaultEcs)
[![Coverage Status](https://coveralls.io/repos/github/Doraku/DefaultEcs/badge.svg?branch=master)](https://coveralls.io/github/Doraku/DefaultEcs?branch=master)
![continuous integration status](https://github.com/doraku/defaultecs/workflows/continuous%20integration/badge.svg)
[![preview package](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultEcs/packages/26448)
[![Join the chat at https://gitter.im/Doraku/DefaultEcs](https://badges.gitter.im/Doraku/DefaultEcs.svg)](https://gitter.im/Doraku/DefaultEcs?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

- [API documentation](./documentation/api/DefaultEcs.md 'API documentation')
- [FAQ](./documentation/FAQ.md 'Frequently Asked Questions')
- [Benchmarks](https://github.com/Doraku/Ecs.CSharp.Benchmark)
<a/>

- [Requirements](#requirements)
- [Versioning](#versioning)
- [Analyzer](#analyzer)
- [Overview](#overview)
  - [World](#world)
    - [Message](#message)
  - [Entity](#entity)
  - [Component](#component)
    - [Singleton](#singleton)
    - [Resource](#resource)
  - [Query](#query)
    - [AsPredicate](#aspredicate)
    - [AsEnumerable](#asenumerable)
    - [AsSet](#asset)
    - [AsMap](#asmap)
    - [AsMultiMap](#asmultimap)
  - [System](#system)
    - [ISystem](#isystem)
    - [ActionSystem](#actionsystem)
    - [SequentialSystem](#sequentialsystem)
    - [ParallelSystem](#parallelsystem)
    - [AComponentSystem](#acomponentsystem)
    - [AEntitySetSystem](#aentitysetsystem)
    - [AEntityMultiMapSystem](#aentitymultimapsystem)
  - [Threading](#threading)
    - [IParallelRunnable](#iparallelrunnable)
    - [IParallelRunner](#iparallelrunner)
    - [DefaultParallelRunner](#defaultparallelrunner)
  - [Command](#command)
  - [Serialization](#serialization)
    - [TextSerializer](#textserializer)
    - [BinarySerializer](#binaryserializer)
- [Extension](#extension)
- [Sample](#sample)
- [Projects using DefaultEcs](#projects-using-defaultecs)
- [Dependencies](#dependencies)

# Requirements
DefaultEcs heavily uses features from C#7.0 and Span from the System.Memory package, compatible from .NETStandard 1.1.  
For development, a C#9.0 compatible environment, net framework 4.8, net6.0 are required to build and run all tests (it is possible to disable some targets in the test project if needed).  
It is possible to use DefaultEcs in Unity (check [FAQ](./documentation/FAQ.md#unity)).

# Versioning
This is the current strategy used to version DefaultEcs: v0.major.minor
- 0: DefaultEcs is still in heavy development and although a lot of care is given not to break the current API, it can still happen
- major: incremented when there is a breaking change (reset minor number)
- minor: incremented when there is a new feature or a bug fix

# Analyzer
To help development with DefaultEcs, there is a roslyn analyzer which provides code generation and warnings against potential bad usage. It can be found [here](https://github.com/Doraku/DefaultEcs.Analyzer).

# Overview
## World
The World class acts as the central hub to create entities, query specific entities, get all components for a given type or publish and subscribe to messages that can be used to communicate across types.  
Multiple World objects can be used in parallel, each instance being thread-safe from one another but operations performed on a single instance and all of its created items should be thought as non thread-safe. Depending on what is done, it is still possible to process operations concurrently to optimise performance.

Worlds are created as such:
```csharp
World world = new World();
```

The World class also implements the `IDisposable` interface so you can easily clean up resources by disposing it.

### Message
It is possible to send and receive message transiting in a World:
```csharp
void On(in bool message) { }

// the method On will be called back every time a bool object is published
// it is possible to use any type
world.Subscribe<bool>(On);

world.Publish(true);
```

It is also possible to subscribe to multiple methods of an instance by using the `SubscribeAttribute`:
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

Note that the Subscribe method returns an `IDisposable` object acting as a subscription. To unsubscribe, simply dispose this object.

## Entity
Entities are simple structs acting as keys to manage components.

Entities are created as such:
```csharp
Entity entity = world.CreateEntity();
```

To clear an entity, simply call its `Dispose` method.
```csharp
entity.Dispose();
```

You should not store entities yourself and rely as much as possible on the returned objects from a world query as those will be updated accordingly to component changes.
If you absolutely need to store it separately and found related hard-to-find bug, you might consider temporary enabling runtime entity misuse checks:
```csharp
Entity entity = world.CreateEntity();
Entity.IsMisuseDetectionEnabled = true; // this property is available in release as well, but is not used
entity.Set<bool>();
entity.Dispose();
if (entity.Has<bool>()) {
    // in debug configuration you will get entity misuse exception trying to perform Has<T> there as the entity is already dead.
}
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

There is faster alternative to IsAlive property:
```csharp
if (!entity.IsAliveVersion)
{
    // make sure to only use this if you are sure entity was at least valid before, and its world is still alive
    // i.e created from existing valid world through CreateEntity method, and not through default struct constructor
}
```

You can also make an entity act as if it was disposed so it is removed from world queries while keeping all its components, this is useful when you need to activate/deactivate an entity from your game logic:
```csharp
entity.Disable();

// this will return false;
entity.IsEnabled();

entity.Enable();

// and now it will return true;
entity.IsEnabled();
```

## Component
Components are not restricted by any heritage hierarchy. It is recommended that component objects only hold data and be structs to generate as little as possible garbage and to have them contiguous in memory, but you can use classes and interfaces too:
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

To reduce memory usage, it is possible to set a maximum capacity for a given component type. If nothing is set, then the maximum entity count of the world will be used. This call needs to be done before any component of the specified type is set:
```csharp
world.SetMaxCapacity<Example>(42);
```

Components can live on two levels, on entities or directly on the world itself:
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

// be careful that the component type is specific to the method generic parameter type, not the component type
entity.Set<IExample>(new CExample());

// this will return false as the component type previously set is IExample, not CExample
entity.Has<CExample>();
```

It is possible to share the same component value between entities or even the world. This is useful if you want to update a component value on multiple entities with a single call:
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

Components on entities can also be disabled and re-enabled. This is useful if you want to quickly make an entity act as if its component composition has changed so it is picked up by world queries without paying the price of actually removing the component:
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

There are two ways to update a component value, either use the `Set<T>(newValue)` method or set/edit the value returned by `Get<T>()`. One major difference between the two is that `Set<T>(newValue)` will also notify internal queries that the component value has changed:
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

### Singleton
By combining the previous calls, it is possible to define a component type as a singleton:
```csharp
// only one component value for int can exist on this world
world.SetMaxCapacity<int>(1);

// and it is used by the world
world.Set<int>(42);

// entity.Set<int>(10); this line would throw
// the only way to set the component on entities would be to use the world component
entity.SetSameAsWorld<int>();
```

### Resource
Not all components can easily be serialized to be loaded from data files (texture, sound, ...). To help with the handling of those cases, helper types are provided to provide a way to load managed resources, shared across entities and even worlds, and automatically dispose them once no entity using them exists anymore.  
To set up a managed resource on an entity, the type `ManagedResource<TInfo, TResource>` needs to be set as a component where `TInfo` is a type used as a single identifier for a single resource and information needed to load it, and `TResource` is the type of the resource.  
Should multiple resources of the same type be needed on a single entity, it is also possible to set the type `ManagedResource<TInfo[], TResource>` as a component.  
If the `ManagedResource` component is removed from the entity or the entity holding it is disposed, the internal reference count on the resource will decrease and it will be disposed if zero is reached.  
To actually load the resource, an implementation of the class `AResourceManager<TInfo, TResource>` is needed as shown in the example:
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

// this is how to set up a resource manager on a world, it will process all currently existing entities with the special component type, and react to all future entities also
textureResourceManager.Manage(_world);
```
This feature only cares for entity components, not the world components.
Plus, it's intended mostly for init, so keep it in mind before trying to use it in any non-init systems as the performance might not be the best.

## Query
To perform operations, systems should query entities from the world. This is performed by requesting entities through the world and using the fluent API to create rules
```csharp
world
    .GetEntities() // this is the starting point of a query, you can also query disabled entities with GetDisabledEntities()
    .With<int>().With<double>() // require that entities have both an int and double components
    .Without<string>().Without<char>() // require that entities do not have both a string nor a char component
    .WithEither<long>().Or<ulong>() // require that entities have either a long or ulong component
    .WithoutEither<short>().Or<ushort>() // require that entities do not have either a short or a ushort component
    ...
    .WhenAdded<int>() // require that entities have just been added an int component
    .WhenChanged<int>() // require that entities have their int component changed
    .WhenRemoved<string>() // require that entities have their string component removed
    ...
```

Once you are satisfied with the rules you can then finish the query by choosing how to get the entities:
### AsPredicate
```csharp
world
    .GetEntities()
    ...
    .AsPredicate();
```
Gets a `Predicate<Entity>` that checks for your declared rules. `When...` rules are ignored.  
This is useful if you need to check for some entity component composition.

### AsEnumerable
```csharp
world
    .GetEntities()
    ...
    .AsEnumerable();
```
Gets an `IEnumerable<Entity>` that when enumerated returns all the entities respecting your declared rules. `When...` rules are ignored.  
This is useful if you need to do an initialisation on specific entities, this should not be used in a hot path.

### AsSet
```csharp
world
    .GetEntities()
    ...
    .AsSet();
```
Gets an `EntitySet` containing all entities respecting your declared rules. Its content is cached for fast access and is automatically updated as you change your entity component composition.
If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.
This is the base type used in the provided system implementation.

### AsMap
```csharp
world
    .GetEntities()
    ...
    .AsMap<TKey>();
```
Gets an `EntityMap<TKey>` which maps a single entity with a component type of `TKey` value. Its content is cached for fast access and is automatically updated as you change your entity component composition.
You can think of it as ecs-framework intergated version of `Dictionary<TKey,Entity>`.
This is useful if you need O(1) access to an entity based on a key.

For complex situations when you want to compare specific field(s) instead of whole component, you can pass `IEqualityComparer<TKey>` when creating the map:
```csharp
    public static class TestsApplication {
        public static void Main() {
            World testWorld = new World();
            var comparer = new TestComponentComparer();
            var testComponentMap = testWorld.GetEntities().AsMap<TestComponent>(comparer);

            Entity one = testWorld.CreateEntity();
            Entity two = testWorld.CreateEntity();
            Entity three = testWorld.CreateEntity();
            one.Set(new TestComponent() { UniqueID = 1, SomeBool = true });
            two.Set(new TestComponent() { UniqueID = 1, SomeBool = false });

            // Now we will get error because EntityMap we have only cares about the bool equality
            three.Set(new TestComponent() { UniqueID = 2, SomeBool = true });
        }
    }
    public struct TestComponent {
        public byte UniqueID;
        public bool SomeBool;
    }
    public class TestComponentComparer : IEqualityComparer<TestComponent> {
        bool IEqualityComparer<TestComponent>.Equals(TestComponent x, TestComponent y) => x.SomeBool == y.SomeBool;
        int IEqualityComparer<TestComponent>.GetHashCode(TestComponent obj) => obj.GetHashCode();
    }
```

If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.

### AsMultiMap
```csharp
world
    .GetEntities()
    ...
    .AsMultiMap<TKey>();
```
Gets an `EntityMultiMap<TKey>` which maps multiple entities with a component type of `TKey` value. Its content is cached for fast access and is automatically updated as you change your entity component composition.
You can think of it as ecs-framework intergated version of `Dictionary<TKey,Entity[]>`.
This is useful if you need O(1) access to entities based on a key.
Just like `EntityMap<TKey>` it supports custom component equality by passing `IEqualityComparer<TKey>`

If `When...` rules are present, you should call its `Complete()` method once you are done processing its entities to clear it.

## System
Although there is no obligation to use them, a set of base classes is provided to help with the creation of systems:
### ISystem
This is a base interface for all systems. It exposes an `Update` method and an `IsEnabled` property. In all derived types provided in DefaultEcs, the responsibility to check this property is handled by the callee, not the caller. It is set to true by default.

### ActionSystem
This class is used to quickly make a system with a given custom action to be called on every update:
```csharp
private void Exit(float elapsedTime)
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

### SequentialSystem
This class is used to easily create a list of systems to be updated in a sequential order:
```csharp
ISystem<float> system = new SequentialSystem<float>(
    new InputSystem(),
    new AISystem(),
    new PositionSystem(),
    new DrawSystem()
);
...

// this will call the systems in order: InputSystem -> AISystem -> PositionSystem -> DrawSystem
```

### ParallelSystem
This class is used to easily create a list of systems to be updated in parallel:
```csharp
ISystem<float> system = new ParallelSystem<float>(
    new DefaultParallelRunner(Environment.ProcessorCount),    
    new System1(),
    new System2(),
    new System3(),
    new System4()
);
...

// this will call the systems in parallel
```

### AComponentSystem
This is a base class to create systems that update based on a specific component type from a given World:
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

    protected override void PreUpdate(float elapsedTime)
    {
        _batch.Begin();
    }

    protected override void Update(float elapsedTime, ref DrawInfo component)
    {
        _batch.Draw(_square, component.Destination, component.Color);
    }

    protected override void PostUpdate(float elapsedTime)
    {
        _batch.End();
    }
}
```
Note that components do not have to reside on entities to be processed by such a system (world components) and their enabled/disabled state on their owning entity is ignored.

### AEntitySetSystem
This is a base class to create system to update a given `EntitySet`:
```csharp
public sealed class VelocitySystem : AEntitySetSystem<float>
{
    public VelocitySystem(World world, IParallelRunner runner)
        : base(world.GetEntities().With<Velocity>().With<Position>().AsSet(), runner)
    {
    }

    protected override void Update(float elapsedTime, in Entity entity)
    {
        ref Velocity velocity = ref entity.Get<Velocity>();
        ref Position position = ref entity.Get<Position>();

        Vector2 offset = velocity.Value * elapsedTime;

        position.Value.X += offset.X;
        position.Value.Y += offset.Y;
    }
}
```

It is also possible to declare the component types by using the `WithAttribute` and `WithoutAttribute` on the system type:
```csharp
[With<Velocity>]
[With(typeof(Position)]
public sealed class VelocitySystem : AEntitySetSystem<float>
{
    // Note the usage of useBuffer paramater in constructor.
    // Setting it to false will yield us better performance.
    // But now setting removing, or enabling-disabling components on entity that are part of filter (namely, Velocity and Position) is no longer safe.
    // Manipulating entity (i.e. disabling it, or disposing) is now also no longer safe.
    public VelocitySystem(World world) : base(world, useBuffer: false) { }

    protected override void Update(float elapsedTime, in Entity entity)
    {
        ref Velocity velocity = ref entity.Get<Velocity>();
        ref Position position = ref entity.Get<Position>();

        Vector2 offset = velocity.Value * elapsedTime;

        position.Value.X += offset.X;
        position.Value.Y += offset.Y;
    }
}
```

### AEntityMultiMapSystem
This is a base class to create systems that update a given `EntityMultiMap`. If the key implements `IComparable`, the keys will be processed in a sorted order. Otherwise you can provide your own key order:
```csharp
public sealed class LayerSystem : AEntityMultiMapSystem<float, Layer>
{
    // we define the layer order
    private static readonly Layer[] _layers = new[]
    {
        Layer.Background,
        Layer.Unit,
        Layer.Particle,
        Layer.Ui
    };

    private readonly SpriteBatch _batch;
    
    public LayerSystem(SpriteBatch batch, World world)
        : base(world.GetEntities().With<DrawInfo>().AsMultiMap<Layer>())
    {
        _batch = batch;
    }

    protected override Span<Layer> GetKeys()
    {
        return _layers.AsSpan();
    }

    // entities will be drawn layer by layer
    protected override void Update(float state, in Layer key, in Entity entity)
    {
        _batch.Draw(drawInfo.Texture, drawInfo.Position, null, drawInfo.Color, drawInfo.Rotation, drawInfo.Origin, drawInfo.Size, SpriteEffects.None, 0f);
    }
}
```

## Threading
Some systems are compatible with multi-threaded execution: `ParallelSystem`, `AEntitySetSystem` and `AComponentSystem`. This is done by passing an `IParallelRunner` to their respective constructors:
```csharp
IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

ISystem<float> system = new VelocitySystem(world, runner);

// this will process the update on Environment.ProcessorCount threads
system.Update(elapsedTime);
```
It is safe to run a system with multi-threading when:
* for an AEntitySetSystem or an AEntityMultiMapSystem
  * each entity with no dependency to another entity can be safely updated separately
  * there is no entity component composition altering operation done on a world nor on an entity. Here is a list of non thread-safe operations you shouldn't do, see [Command](#Overview_Command) for how to perform such operations safely:
    * Creating and disposing an entity
    * Removing a component from an entity/world
    * Enabling or disabling an entity
    * Enabling or disabling a component on an entity
    * Calling `SetMaxCapacity` on a world
    * Calling `Optimize` on a world
    * Calling `TrimExcess` on a world
    * Calling `Set`/`SameAs`/`SameAsWorld` on an entity/world
    * Calling `NotifyChanged` on an entity
    * Calling `CopyTo` on an entity
* for an `AComponentSystem`
  * each component with no dependency to another component can be safely updated separately

### IParallelRunnable
This interface allows for creation of a custom parallelisable process by an `IParallelRunner`:
```csharp
IParallelRunner runner = new DefaultParallelRunner(Environment.ProcessorCount);

public class CustomRunnable : IParallelRunnable
{
    public void Run(int index, int maxIndex)
    {
        // a runnable is separated into (maxIndex + 1) parts running in parallel, index indicates the part currently running
    }
}

runner.Run(new CustomRunnable());
```

### IParallelRunner
This interface allows for creation of custom parallel execution:
```csharp
public class TaskRunner : IParallelRunner
{
    public int DegreeOfParallelism { get; }

    public void Run(IParallelRunnable runnable)
    {
        Enumerable.Range(0, DegreeOfParallelism).AsParallel().ForAll(i => runnable.Run(i, DegreeOfParallelism));
    }
}
```

### DefaultParallelRunner
This is the default implementation of `IParallelRunner`. It uses tasks to run an `IParallelRunnable` and only returns when the entire runnable has been processed. When `index == maxIndex` it indicates the code is in the calling thread.  
It is safe to reuse the same `DefaultParallelRunner` in multiple systems but it should not be used in parallel itself.
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

## Command
Since it is not possible to make structural modification on an entity in multi-threaded context, the `EntityCommandRecorder` type is provided to address this.  
It is possible to record commands on entities in a thread-safe way to later execute them when those structural modifications are safe to do:
```csharp
// This creates an expandable recorder with a default capacity of 1024 commands
EntityCommandRecorder recorder = new EntityCommandRecorder();

// This creates a fixed capacity recorder of 512 commands
EntityCommandRecorder recorder = new EntityCommandRecorder(512);

// This creates an expandable recorder with a default capacity of 512 command which can expand to a maximum capacity of 2048
EntityCommandRecorder recorder = new EntityCommandRecorder(512, 2048);
```

Note that a fixed capacity `EntityCommandRecorder` (or one which has expanded to its max capacity) has the best performance.  
When needed, an expandable `EntityCommandRecorder` will double its capacity so it is preferred to use a power of 2 as the default capacity.

Some examples:
```csharp
// Get a WorldRecord to record entity creation
WorldRecord worldRecord = recorder.Record(world);

// Defers the creation of a new entity
EntityRecord entityRecord = worldRecord.CreateEntity();

// EntityRecord has the same API as Entity so all actions expected are available to record as commands
entityRecord.Set<bool>(true);

// To execute all recorded commands
recorder.Execute();
```

## Serialization
DefaultEcs supports serialization to save and load a world state. Two implementations are provided which are equal in functionality and it is possible to create a custom serialization engine using the framework of your choice by implementing a set of interfaces:

- `ISerializer` is the base interface
- `IComponentTypeReader` is used to get the settings of the serialized world in case a component max capacity has been set for a specific type different from the world's max capacity
- `IComponentReader` is used to get all the components of an entity

The provided implementations for `TextSerializer` and `BinarySerializer` are highly permissive and will serialize all fields and properties even if they are private or read-only, and do not require any attributes to work.  
This was the goal from the start as graphic and framework libraries do not always have well decorated types which would be used as components.  
Although the lowest target is netstandard1.1, please be aware that the capability of both implementations to handle types with no default constructors may not work if the version of your .NET platform is too low. Other known limitations are:
- no multi-dimensional array support
- no cyclic object graph support (all objects are copied, thus creating an infinite loop)
- not compatible with Xamarin.iOS, AOT platforms (uses the `System.Reflection.Emit` namespace)


```csharp
ISerializer serializer = new TextSerializer(); // or BinarySerializer

using (Stream stream = File.Create(filePath))
{
    serializer.Serialize(stream, world);
}

using (Stream stream = File.OpenRead(filePath))
{
    World worldCopy = serializer.Deserialize(stream);
}
```

Each implementation has its own serialization context which can be used to transform a given type to something else or just change the value during serialization or deserialization.
```csharp
using BinarySerializationContext context = new BinarySerializationContext()
    .Marshal<string, string>(_ => null) // set every string as null during serialization
    .Marshal<NonSerializableData, SerializableData>(d => new SerializableData(d)) // transform non serializable data to a serializable type during serialization
    .Unmarshal<SerializableData, NonSerializableData>(d => Load(d)); // reload non serializable data from serializable data during deserialization

BinarySerializer serializer = new BinarySerializer(context);
```

### TextSerializer
The purpose of this serializer is to provide a readable save format which can be edited by hand.
```
// declare the maximum number of entities in the World, this must be before any Entity or ComponentMaxCapacity line
WorldMaxCapacity 42

// this line is used to define an alias for a type used as a component inside the world and must be declared before being used
ComponentType Int32 System.Int32, System.Private.CoreLib

// this line is used to set the max capacity for the given type, in case it is different from the world max capacity
ComponentMaxCapacity Int32 13

// this creates a new entity with the id "Foo"
Entity Foo

// this line sets the component of the type with the alias Int32 on the previously created Entity to the value 13
Component Int32 13

// let's say we have the type defined as such already declared with the alias Test
// struct Test
// {
//     int Hello
//     int World
// }
ComponentType Test MyNamespace.Text, MyLib

// composite objects are set like this
Component Test {
	Hello 42
	// this line is ignored since the type does not have a member with the name Wow
	// also the World member will have its default value since not present
	Wow 43
}

// this creates a new entity with no id
Entity

// this sets the component of the type with the alias Test of the previously created Entity as the same as the one of the Entity with the id Foo
ComponentSameAs Test Foo
```
### BinarySerializer
This serializer is optimized for speed and file size.

# Extension
A DefaultEcs.Extension project is present to show how other features can be built upon the base framework. Those features are just provided as example and are not part of DefaultEcs because the implementation is not generic nor satisfactory enough.
- [Children](https://github.com/Doraku/DefaultEcs/blob/master/source/DefaultEcs.Extension/Children/EntityExtension.cs) makes it so entities can be linked together and disposing the parent will also dispose its children
- [Hierarchy](https://github.com/Doraku/DefaultEcs/tree/master/source/DefaultEcs.Extension/Hierarchy) shows an example on how to create a hierarchy level between entities so parents are processed before their children

# Sample
Some sample projects are available to paint a better picture on how to use DefaultEcs. Those examples were done relatively fast so they might not be an adequate representation of what an Entity Component System framework application might look like.

[DefaultBoids](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBoids)

[![DefaultBoids](https://img.youtube.com/vi/yEdcqOTCteY/0.jpg)](https://youtu.be/yEdcqOTCteY)

A really simple implementation of a [boids simulation](https://en.wikipedia.org/wiki/Boids), here displaying 30k boids with an old Intel Core i5-3570K CPU 3.40GHz at ~70fps.  
This project uses code generation from [DefaultEcs.Analyzer](https://github.com/Doraku/DefaultEcs.Analyzer) for its systems where possible.

[DefaultBrick](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBrick)
[win10-x64](https://github.com/Doraku/DefaultEcs/releases/download/v0.9.0/DefaultBrick_win10-x64.zip)

![](https://github.com/Doraku/DefaultEcs/raw/master/image/defaultbrick.gif)

Basic breakout clone. The collision is buggy! As said before, not much time was spent debugging those. Ball moves faster the more bricks you destroy and resets to default speed if you lose. The stage reloads once completed.  
This project does not use attributes for system queries, everything is statically declared.

[DefaultSlap](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultSlap)
[win10-x64](https://github.com/Doraku/DefaultEcs/releases/download/v0.9.0/DefaultSlap_win10-x64.zip)

![](https://github.com/Doraku/DefaultEcs/raw/master/image/defaultslap.gif)

Basic fly swatter clone. Every five seconds flies (blue squares) will damage the player (up to 3 times until the "game" resets) and new ones will spawn.  
This project uses attributes for system queries.

# Projects using DefaultEcs
Does your game use DefaultEcs? Don't hesitate to contact me.  

[![Chambers of Anubis](https://img.itch.zone/aW1nLzQ2MDYzODcucG5n/original/IALw4S.png)](https://github.com/PodeCaradox/HellowIInJam)

# Dependencies
CI, tests and code quality rely on these awesome projects:
- [Coverlet](https://github.com/coverlet-coverage/coverlet)
- [NFluent](https://github.com/tpierrain/NFluent)
- [NSubstitute](https://github.com/nsubstitute/NSubstitute)
- [Roslynator](https://github.com/JosefPihrt/Roslynator)
- [XUnit](https://github.com/xunit/xunit)
