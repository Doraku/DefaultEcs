This page contains some more specific questions you could have which are not covered by the general README overview.

- [Why the name DefaultEcs?](#defaultecs)
- [How to use DefaultEcs in a game loop?](#game_loop)
- [How to have multiple entities dependencies in systems?](#system_dependencies)
- [How to queue messages instead of handling them synchronously?](#queue_message)
- [How to use DefaultEcs in Unity?](#unity)
- [How to update systems at half the framerate?](#system_decorator)

<a name='defaultecs'></a>
## Why the name DefaultEcs?
Naming things is hard, and I am certainly bad at it. The name DefaultEcs has two opposite meaning:
- making this framework as good as possible so it just become the default choice for ecs
- a play on the C# `default()` syntax, which return a zeroed variable for a struct type or null for a reference type, `default(ecs)` giving you nothing of importance in the end as I am not that bright and the framework may not be that good

<a name='game_loop'></a>
## How to use DefaultEcs in a game loop?
DefaultEcs is easy enough to insert into a [game loop](https://gameprogrammingpatterns.com/game-loop.html) by using the provided [system](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs-System-ISystem-T-.md) implementation.
```csharp
ISystem<GameState> mainSystem;
GameState state;

while (true)
{
    mainSystem.Update(state);
}
```
It is completely resonable to seperate your update and render process in their own systems as some game frameworks allow the update to run multiple times compared to the presentation of a frame.
```csharp
ISystem<GameState> updateSystem;
ISystem<GameState> renderSystem;
GameState state;

while (true)
{
    updateSystem.Update(state);
    renderSystem.Update(state);
}
```
You are free to handle the exit clause however you want as DefaultEcs do not force any specific usage.

<a name='system_dependencies'></a>
## How to have multiple entities dependencies in systems?
While the provided system implementation to handle entities update [AEntitySystem](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs-System-AEntitySystem-T-.md) only have one internal EntitySet, nothing stop you to generate more EntitySet if for example you need to handle collision between two sets.
```csharp
// don't care about collision between enemies and collision between allies
[With(typeof(Enemy), typeof(CollisionBox))]
public sealed class CollisionSystem : AEntitySystem<float>
{
    private readonly EntitySet _allies;

    public CollisionSystem(World world, SystemRunner<float> runner)
        : base(world, runner)
    {
        _allies = world.GetEntities().With<Ally>().With<CollisionBox>().AsSet();
    }

    protected override void Update(float state, ReadOnlySpan<Entity> entities)
    {
        foreach (ref readonly Entity ally in _allies.GetEntities())
        {
            foreach (ref readonly Entity entity in entities)
            {
                if (entity.Get<CollisionBox>().Intersects(ally.Get<CollisionBox>()))
                {
                    ...
                }
            }
        }
    }
}
```

<a name='queue_message'></a>
## How to queue messages instead of handling them synchronously?
The [IPublisher](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs-IPublisher.md) implementation of the World type handle message synchronously. While nothing is provided to make them asynchronous it is a simple enough feat.
```csharp
internal sealed class BulletSystem : ISystem<float>
{
    private readonly List<NewBulletMessage> _newBullets;

    public BulletSystem(World world, Configuration configuration)
    {
        _newBullets = new List<NewBulletMessage>(100);

        _subscription = world.Subscribe(this);
    }

    [Subscribe]
    private void On(in NewBulletMessage message) => _newBullets.Add(message);

    public bool IsEnabled { get; set; } = true;

    public void Update(float state)
    {
        if (IsEnabled)
        {
            foreach (NewBulletMessage message in _newBullets)
            {
	            // setup bullet
            }
            _newBullets.Clear();
        }
    }
}
```
By handling them as an ISystem  you can then easily decide when in your update workflow you want to actually handle them. Keep in mind to use a thread safe collection to store the received message if you use a multithreaded update.

<a name='unity'></a>
## How to use DefaultEcs in Unity?
DefaultEcs is not available as a unity package for now but it is still possible to use it in Unity since the version 0.15.1.

While Unity does not handle directly nuget packages, [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) tries to fill this need and will let you easily add DefaultEcs (and its dependencies) in your Unity project.  
If you want to add it manually, you will have to download [DefaultEcs](https://www.nuget.org/packages/DefaultEcs/) and its dependencies [System.Buffers](https://www.nuget.org/packages/System.Buffers/), [System.Memory](https://www.nuget.org/packages/System.Memory/) and [System.Runtime.CompilerServices.Unsafe](https://www.nuget.org/packages/System.Runtime.CompilerServices.Unsafe/).

Once the dlls inside your Unity project you will then need to disable `Validate References` on DefaultEcs.dll and System.Memory.dll:

![Unity](https://github.com/Doraku/DefaultEcs/blob/master/image/unity.png)

Note that this feature has only been available since a specific version of Unity.

You should then be able to use DefaultEcs in your Unity project. Keep in mind that if you choose the IL2CPP backend, some features will not work (the provided serializers) and some others will require extra code (check [AoTHelper](https://github.com/Doraku/DefaultEcs/blob/master/documentation/api/DefaultEcs-AoTHelper.md)).

<a name='system_decorator'></a>
## How to update systems at half the framerate?
Sometimes you may want to execute your systems update under certain condition (different framerate, some other condition). To do so it is preferable use the decorator pattern with the `ISystem<T>` as base.
```csharp
public sealed HalfUpdateSystem<T> : ISystem<T>
{
    private readonly ISystem<T> _system;
    
    private bool _oddUpdate;
    
    public HalfUpdateSystem(params ISystem<T> systems)
    {
        _systems = new SequentialSystem<T>(systems);
	_oddUpdate = false;
    }
    
    public bool IsEnabled { get; set; } = true;
    
    public void Update(T state)
    {
        if (IsEnabled && (_oddUpdate = !_oddUpdate))
	{
	    _system.Update(state);
	}
    }
    
    public void Dispose() => _system.Dispose();
}
```
Obviously you can use the rule you want for the update (check a specific amount of time has passed, ...) this is just an example.
