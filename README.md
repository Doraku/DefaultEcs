![DefaultEcs](https://github.com/Doraku/DefaultEcs/raw/master/image/DefaultEcsLogo.png)
DefaultEcs is an Entity Component System framework which aims to be accessible with little constraints while retaining as much performance as possible for game development.

[![NuGet](https://img.shields.io/badge/nuget-v0.7.0-brightgreen.svg)](https://www.nuget.org/packages/DefaultEcs)

- [Requirement](#Requirement)
- [Overview](#Overview)
  - [World](#Overview_World)
  - [Entity](#Overview_Entity)
  - [Component](#Overview_Component)
  - [System](#Overview_System)
    - [ISystem](#Overview_System_ISystem)
    - [ActionSystem](#Overview_System_ActionSystem)
    - [SequentialSystem](#Overview_System_SequentialSystem)
    - [AEntitySystem](#Overview_System_AEntitySystem)
    - [AComponentSystem](#Overview_System_AComponentSystem)
    - [SystemRunner](#Overview_System_SystemRunner)
  - [Message](#Overview_Message)
  - [Serialization](#Overview_Serialization)
    - [TextSerializer](#Overview_Serialization_TextSerializer)
    - [BinarySerializer](#Overview_Serialization_BinarySerializer)
- [Sample](#Sample)
- [Performance](#Performance)

<a name='Requirement'></a>
# Requirement
DefaultEcs use heavily features from C#7.0 and Span from the System.Memory package, compatible from .NETStandard 1.1.

<a name='Overview'></a>
# Overview
<a name='Overview_World'></a>
## World
The World class act as a manager to create entity, get a selection of specific entities, get a family of component or publish and subscribe to messages that can be used to communicate in a decoupled way between the different elements.
Multiple World objects can be used in parallel, each instance being thread-safe from one an other but operations performed on a single instance and all of its created items should be thought as non thread-safe but depending on what is done, it is still possible to process operations concurrently to optimise performance.

Worlds are created as such
```C#
World world = new World();
```

It should be noted that the World class also implement the IDisposable interface.

<a name='Overview_Entity'></a>
## Entity
Entities are simple struct wraping above two Int32, acting as a key to manage components.

Entities are created as such
```csharp
Entity entity = world.CreateEntity();
```

To clear an entity, simply call its Dispose method
```csharp
entity.Dispose();
```

It is possible to create a relationship between entities
```csharp
Entity parentEntity = world.CreateEntity();
Entity childEntity = world.CreateEntity();

// both lines have the same outcome
parentEntity.SetAsParentOf(childEntity);
childEntity.SetAsChildOf(parentEntity);

// disposing the parent will also dispose the child
parentEntity.Dispose();
```

<a name='Overview_Component'></a>
## Component
Components are not restricted by any heritage hierarchy. It is recommanded that component objects only hold data and to be struct to generate as little as possible garbage and to have them contiguous in memory.
```csharp
public struct Example
{
    public float Value;
}
```

To reduce memory, it is possible to set a maximum count for a given component type. If nothing is set, then the maximum entity count of the world will be used.
```csharp
int maxComponentCount = 42;
world.SetMaximumComponentCount<Example>(maxComponentCount);
```

It is then possible to add the component to the entity
```C#
entity.Set(new Example { Value = 42 });
```

It is also possible to share a component between entities without creating a new object
```C#
entity.SetSameAs<Example>(referenceEntity);
```
If the component is removed from the entity used as reference, it will not remove the component from the other entities using the same component.

To get a component from an entity, simply do the following
```C#
entity.Get<Example>();
```
Note that the Get method return the component as a ref so you can directly update its value without using the Set method again (but it still need to be set at least once).

<a name='Overview_System'></a>
## System
To perform operation, systems should get EntitySet from the World instance. EntitySet are updated as components are added/removed from entities and are used to get a subset of entities with the required component.
EntitySet are created from EntitySetBuilder and it is possible to apply rules for required components or excluded components
```C#
// this set when enumerated will give all the entities with an Example component
EntitySet set = world.GetEntities().With<Example>().Build();

// this set when enumerated will give all the entities without an Example component
EntitySet set = world.GetEntities().Without<Example>().Build();

// this set when enumerated will give all the entities with both an Example and an int component
EntitySet set = world.GetEntities().With<Example>().With<int>().Build();

// this gives all the component of type Example currently used in the world
Span<Example> components = world.GetAllComponents<Example>();
```

Although there is no obligation, a set of base classes are provided to help the creation of systems:
<a name='Overview_System_ISystem'></a>
### ISystem<T>
This is a base interface for all the systems.

<a name='Overview_System_ActionSystem'></a>
### ActionSystem<T>
This class is used to quickly make a system with a given custom action to be called on every update.
```C#
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
```C#
ISystem<float> system = new SequentialSystem<float>(
        new InputSystem(),
        new AISystem(),
        new PositionSystem(),
        new DrawSystem()
    );
...

// this will call in order InputSystem, AISystem, PositionSystem and DrawSystem
system.Update(elaspedTime);
```

<a name='Overview_System_AEntitySystem'></a>
### AEntitySystem<T>
This is a base class to create system to update a given EntitySet.
```C#
public sealed class VelocitySystem : AEntitySystem<float>
{
    public VelocitySystem(World world, SystemRunner<float> runner)
        : base(world.GetEntities().With<Velocity>().With<Position>().Build(), runner)
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
```C#
[With(typeof(Velocity)]
[With(typeof(Position)]
public sealed class VelocitySystem : AEntitySystem<float>
{
    public VelocitySystem(World world, SystemRunner<float> runner)
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

<a name='Overview_System_AComponentSystem'></a>
### AComponentSystem<TState, TComponent>
This is a base class to create system to update a specific component type from a given World.
```C#
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

<a name='Overview_System_SystemRunner'></a>
### SystemRunner
While not directly a system, an instance of this class can be given to base constructor of AEntitySystem and AComponentSystem to provide multithreading processing of system.
```C#
SystemRunner runner = new SystemRunner(Environment.ProcessorCount);

ISystem<float> system = new VelocitySystem(world, runner);

// this will process the update on Environment.ProcessorCount threads
system.Update(elaspedTime);
```

It is safe to run a system with multithreading when:
* for an AEntitySystem
  * each entity can be safely updated separately with no dependency to an other entity
  * there is no new Set, Remove or Dispose action on entity (only read or update)
* for an AComponentSystem
  * each component can be safely updated separately with no dependency to an other component

<a name='Overview_Message'></a>
## Message
It is possible to send and receive message transiting in a World.
```C#
void On(in bool message) { }

// the method On will be called back every time a bool object is published
// it is possible to use any type
world.Subscribe<bool>(On);

world.Publish(true);
```

It is also possible to subscribe to multiple method of an instance by using the SubscribeAttribute:
```C#
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

<a name='Overview_Serialization'></a>
## Serialization
DefaultEcs support serialization to save and load a World state. Two implementations are provided which are equals in feature and it is possible to create a custom serialization engine using the framework of your choice by implementing a set of interfaces.

- ISerializer is the base interface
- IComponentTypeReader is used to get the settings of the serialized World in case a maxComponentCount has been set for a specific type different from the maxEntityCount
- IComponentReader is used to get all the components of an Entity

The provided implementation TextSerializer and BinarySerializer are highly permissive and will serialize every fields and properties even if the are private or readonly and do not require any attribute decoration to work.
This was a target from the get go as graphic and framework libraries do not always have well decorated type which would be used as component.
Although the lowest target is netstandard1.1, please be aware that the capability of both implementation to handle type with no default constructor maybe not work if the version of your .NET plateform is too low.


```C#
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

<a name='Overview_Serialization_TextSerializer'></a>
### TextSerializer
The purpose of this serializer is to provide a readable save format which can be edited by hand.
```
// declare the maximum number of entity in the World, this must be before any Entity or MaxComponentCount line
MaxEntityCount 42

// this line is used to define an alias for a type used as component inside the world and must be declared before being used
ComponentType Int32 System.Int32, System.Private.CoreLib

// this line is used to set the maxComponentCount for the given type, in case it is different from the maxEntityCount
MaxComponentCount Int32 13

// this line create an entity with the id "MyEntity", this must be before any Component, ComponentSameAs or ParentChild line
Entity MyEntity

// this line set the component of the type with the alias Int32 on the previously created Entity to the value 13
Component Int32 13

// let's say we have the type defined as such already declared with the alias Test
// struct Test
// {
//     int Hello
//     int World
// }
// composite objects are setted like this
Component Test {
	Hello 666
	// this line is ignored since the type does not have a member with the name Wow
	// also the World member will have its default value since not present
	Wow 42
}

// this create a new entity with no id
Entity
Component Int32 1337

// this create a new entity with the id "Foo"
Entity Foo

// this sets the component of the type with the alias Test of the previously created Entity as the same as the one of the Entity with the id MyEntity
ComponentSameAs Test MyEntity

// this sets the entity with the id MyEntity as the parent of the entity with the id Foo
ParentChild MyEntity Foo
```
<a name='Overview_Serialization_BinarySerializer'></a>
### BinarySerializer
This serializer is optimized for speed and file space.

<a name='Sample'></a>
# Sample
Some sample projects are available to give a better picture on how to use DefaultEcs. Those exemples were done relatively fast so they are probably not the best representation of the Entity Component System framework application.

[DefaultBrick](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBrick)
Basic breakout clone.

[DefaultSlap](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultSlap)
Basic fly swatter clone.

<a name='Performance'></a>
# Performance
Feel free to correct my use of the compared ecs libraries as I looked only for basic uses which may not be the most performant way.

```
BenchmarkDotNet=v0.11.0, OS=Windows 10.0.17134.165 (1803/April2018Update/Redstone4)
Intel Core i5-3570K CPU 3.40GHz (Ivy Bridge), 1 CPU, 4 logical and 4 physical cores
Frequency=3320337 Hz, Resolution=301.1742 ns, Timer=TSC
  [Host]     : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0
  Job-UJZYDN : .NET Framework 4.7.2 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3131.0

InvocationCount=10  IterationCount=10  LaunchCount=1
RunStrategy=Monitoring  UnrollFactor=1  WarmupCount=10
```

SingleComponentEntityEnumeration: add one to the basic component (containing one int) of 100000 entities

 Method | Mean | Error | StdDev
---:|---:|---:|---:
[DefaultEcs_EntitySet](# 'using directly the EntitySet class (single threaded)')                                                       |   292.30 us |   0.6382 us |  0.4221 us
[DefaultEcs_System](# 'using the AEntitySystem base class (single threaded)')                                                          |   365.22 us |   7.6181 us |  5.0389 us
[*DefaultEcs_System](# 'same as above but overriding ReadOnlySpan<Entity> Update method instead of the single Entity one')             |   293.36 us |   0.5569 us |  0.3684 us
[DefaultEcs_MultiSystem](# 'using the AEntitySystem base class (multi threaded)')                                                      |   105.90 us |  18.5030 us | 12.2386 us
[*DefaultEcs_MultiSystem](# 'same as above but overriding ReadOnlySpan<Entity> Update method instead of the single Entity one')        |    84.15 us |   6.8169 us |  4.5090 us
[DefaultEcs_Component](# 'using directly the World class (single threaded)')                                                           |   110.81 us |   7.0749 us |  4.6796 us
[DefaultEcs_ComponentSystem](# 'using the AComponentSystem base class (single threaded)')                                              |   250.65 us |   0.3340 us |  0.2210 us
[*DefaultEcs_ComponentSystem](# 'same as above but overriding Span<Component> Update method instead of the single Component one')      |    84.49 us |   0.2756 us |  0.1823 us
[DefaultEcs_ComponentMultiSystem](# 'using the AComponentSystem base class (multi threaded)')                                          |    68.72 us |   4.8234 us |  3.1904 us
[*DefaultEcs_ComponentMultiSystem](# 'same as above but overriding Span<Component> Update method instead of the single Component one') |    29.02 us |   5.3375 us |  3.5304 us
[Entitas-CSharp](https://github.com/sschmid/Entitas-CSharp)|
[Entitas_System](# 'using the JobSystem base class (single threaded)')                                                                 | 3,404.56 us | 101.3847 us | 67.0597 us
[Entitas_MultiSystem](# 'using the JobSystem base class (multi threaded)')                                                             | 2,107.79 us |  79.0974 us | 52.3180 us

DoubleComponentEntityEnumeration: do basic movement with two component (position, speed) on 100000 entities

 Method | Mean | Error | StdDev
---:|---:|---:|---:
[DefaultEcs_EntitySet](# 'using directly the EntitySet class (single threaded)')                                                |   600.6 us |  0.8557 us |  0.5660 us
[DefaultEcs_System](# 'using the AEntitySystem base class (single threaded)')                                                   |   657.9 us |  0.6519 us |  0.4312 us
[*DefaultEcs_System](# 'same as above but overriding ReadOnlySpan<Entity> Update method instead of the single Entity one')      |   598.2 us |  7.0261 us |  4.6473 us
[DefaultEcs_MultiSystem](# 'using the AEntitySystem base class (multi threaded)')                                               |   185.4 us | 13.9892 us |  9.2530 us
[*DefaultEcs_MultiSystem](# 'same as above but overriding ReadOnlySpan<Entity> Update method instead of the single Entity one') |   169.8 us | 21.8569 us | 14.4570 us
[Entitas-CSharp](https://github.com/sschmid/Entitas-CSharp)|
[Entitas_System](# 'using the JobSystem base class (single threaded)')                                                          | 3,087.1 us | 25.3565 us | 16.7718 us
[Entitas_MultiSystem](# 'using the JobSystem base class (multi threaded)')                                                      | 2,239.0 us | 36.4984 us | 24.1415 us
