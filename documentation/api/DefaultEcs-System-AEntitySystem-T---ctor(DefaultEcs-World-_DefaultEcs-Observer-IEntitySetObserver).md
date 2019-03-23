#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](./DefaultEcs.md#DefaultEcs-System 'DefaultEcs.System').[AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## #ctor(DefaultEcs.World, DefaultEcs.Observer.IEntitySetObserver) `constructor`
Initialise a new instance of the [AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [World](./DefaultEcs-World.md 'DefaultEcs.World').
To create the inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.
### Parameters

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-Observer-IEntitySetObserver)-world'></a>
`world`

The [World](./DefaultEcs-World.md 'DefaultEcs.World') from which to get the [Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-Observer-IEntitySetObserver)-observer'></a>
`observer`

The [IEntitySetObserver](./DefaultEcs-Observer-IEntitySetObserver.md 'DefaultEcs.Observer.IEntitySetObserver') to notify when an entity is added/removed from the created inner [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet').
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')

[world](#DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-Observer-IEntitySetObserver)-world 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World, DefaultEcs.Observer.IEntitySetObserver).world') is null.
