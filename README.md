# DefaultEcs
DefaultEcs is an Entity Component System framework which aims to be accessible with little constraints while retaining as much performance as possible for game development.

## World
The World class act as a manager to create entity, get a selection of specific entities, get a family of component or publish and subscribe to messages that can be used to communicate in a decoupled way between the different elements.
Multiple World objects can be used in parallel, each instance being thread-safe from one an other but operations performed on a single instance and all of its created items should be thought as non thread-safe but depending on what is done, it is still possible to process operations concurrently to optimise performance.

Worlds are created as such
```C#
int maxEntityCount = 42;
World world = new World(maxEntityCount);
```

It should be noted that the World class also implement the IDisposable interface.

## Entity
Entities are simple struct wraping above two Int32, acting as a key to manage components.

Entities are created s such
```C#
Entity entity = world.CreateEntity();
```

## Component
Components are not restricted by any heritage hierarchy. It is recommanded that component objects only hold data and to be struct to generate as little as possible garbage and to have them contiguous in memory.
```C#
public struct Example
{
    public float Value;
}
```

Before being used, the component type should be added to the world instance
```C#
int maxComponentCount = 42;
world.AddComponentType<Example>(maxComponentCount);
```

It is then possible to add the component to the entity
```C#
entity.Set(new Example { Value = 42 });
```

It is also possible to share a component between entities without creating a new object
```C#
entity.SetSameAs<Example>(referenceEntity);
```

## System
Like components, systems are not restricted by any heritage hierarchy, that way execution logic and optimisation can be fined tuned as required.

To perform operation, systems should get EntitySet from the World instance. EntitySet are updated as components are added/removed from entities and are used to get a subset of entities with the required component
```C#
// this set when enumerated will give all the entities with an Example component
EntitySet<Example> set = world.GetEntityWith<Example>()
```

EntitySet should be created before entities are instanced.

## Message
It is possible to send and receive message transiting in a World.
```C#
void On(in bool message) { }

// the method On will be called back every time a bool object is published
// it is possible to use any type
world.Subscribe<bool>(On);

world.Publish(true);
```