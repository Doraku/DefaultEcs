### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState-_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;')
## #ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;) `constructor`
Initialise a new instance of the [DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;](./DefaultEcs-System-AComponentSystem-TState-_TComponent-.md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;') class with the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') and [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;').
### Parameters

<a name='DefaultEcs-System-AComponentSystem-TState-_TComponent---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-TState-)-world'></a>
`world`

The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') on which to process the update.

<a name='DefaultEcs-System-AComponentSystem-TState-_TComponent---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-TState-)-runner'></a>
`runner`

The [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')

[world](#DefaultEcs-System-AComponentSystem-TState-_TComponent---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-TState-)-world 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;).world') is null.
