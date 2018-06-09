![DefaultEcs](https://github.com/Doraku/DefaultEcs/blob/master/DefaultEcsLogo.png)
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
```csharp
Entity entity = world.CreateEntity();
```

## Component
Components are not restricted by any heritage hierarchy. It is recommanded that component objects only hold data and to be struct to generate as little as possible garbage and to have them contiguous in memory.
```csharp
public struct Example
{
    public float Value;
}
```

To reduce memory, it is possible to set a maximum count for a given component type. If nothing is set, then the maximum entity count of the world will be used as needed.
```csharp
int maxComponentCount = 42;
world.SetComponentTypeMaximumCount<Example>(maxComponentCount);
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
### ISystem<T>
This is a base interface for all the systems.

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

### AEntitySetSystem<T>
This is a base class to create system to update a given EntitySet.
```C#
public sealed class VelocitySystem : AEntitySetSystem<float>
{
    public VelocitySystem(World world, SystemRunner<float> runner)
        : base(world.GetEntities().With<Velocity>().With<Position>().Build(), runner)
    {
    }

    protected override void Update(float elaspedTime, ReadOnlySpan<Entity> entities)
    {
        foreach (Entity entity in entities)
        {
            ref Velocity velocity = ref entity.Get<Velocity>();
            ref Position position = ref entity.Get<Position>();

            Vector2 offset = velocity.Value * elaspedTime;

            position.Value.X += offset.X;
            position.Value.Y += offset.Y;
        }
    }
}
```

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

    protected override void Update(float elaspedTime, Span<DrawInfo> components)
    {
        _batch.Begin();

        for (int i = 0; i < components.Length; ++i)
        {
            _batch.Draw(_square, components[i].Destination, components[i].Color);
        }

        _batch.End();
    }
}
```

### SystemRunner
While not directly a system, an instance of this class can be given to base constructor of AEntitySetSystem and AComponentSystem to provide multithreading processing of system.
```C#
SystemRunner runner = new SystemRunner(Environment.ProcessorCount);

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

## Message
It is possible to send and receive message transiting in a World.
```C#
void On(in bool message) { }

// the method On will be called back every time a bool object is published
// it is possible to use any type
world.Subscribe<bool>(On);

world.Publish(true);
```
Note that the Subscribe method return an IDisposable object acting as a subscription. To unsubscripe, simple dispose this object.

## Sample
Some sample projects are available to give a better picture on how to use DefaultEcs. Those exemples were done relatively fast so they are probably not the best representation of the Entity Component System framework application.

[DefaultBrick](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultBrick)
Basic breakout clone.

[DefaultSlap](https://github.com/Doraku/DefaultEcs/tree/master/source/Sample/DefaultSlap)
Basic fly swatter clone.