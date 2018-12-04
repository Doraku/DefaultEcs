### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
## DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt; `type`
Represents a base class to process updates on a given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') instance to all its components of type [TComponent](#DefaultEcs-System-AComponentSystem-TState-_TComponent--TComponent 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.TComponent').
### Type parameters

<a name='DefaultEcs-System-AComponentSystem-TState-_TComponent--TState'></a>
`TState`
>The type of the object used as state to update the system.

<a name='DefaultEcs-System-AComponentSystem-TState-_TComponent--TComponent'></a>
`TComponent`
>The type of component to update.
### constructor
- [#ctor(DefaultEcs.World)](./DefaultEcs-System-AComponentSystem-TState-_TComponent---ctor(DefaultEcs-World).md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.#ctor(DefaultEcs.World)')
- [#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;)](./DefaultEcs-System-AComponentSystem-TState-_TComponent---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-TState-).md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;TState&gt;)')
### method
- [Dispose()](./DefaultEcs-System-AComponentSystem-TState-_TComponent--Dispose().md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.Dispose()')
- [Update(TState, System.Span&lt;TComponent&gt;)](./DefaultEcs-System-AComponentSystem-TState-_TComponent--Update(TState-_System-Span-TComponent-).md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.Update(TState, System.Span&lt;TComponent&gt;)')
- [Update(TState, TComponent)](./DefaultEcs-System-AComponentSystem-TState-_TComponent--Update(TState-_TComponent).md 'DefaultEcs.System.AComponentSystem&lt;TState, TComponent&gt;.Update(TState, TComponent)')
