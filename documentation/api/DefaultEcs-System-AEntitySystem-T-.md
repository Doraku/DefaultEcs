#### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System](./DefaultEcs.md#DefaultEcs-System 'DefaultEcs.System')
## AEntitySystem&lt;T&gt; `type`
Represents a base class to process updates on a given [EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet') instance.
### Type parameters

<a name='DefaultEcs-System-AEntitySystem-T--T'></a>
`T`

The type of the object used as state to update the system.
### Constructors
- [#ctor(DefaultEcs.EntitySet)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-EntitySet).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.EntitySet)')
- [#ctor(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-EntitySet-_DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.EntitySet, DefaultEcs.System.SystemRunner&lt;T&gt;)')
- [#ctor(DefaultEcs.World)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World)')
- [#ctor(DefaultEcs.World, DefaultEcs.IEntitySetObserver)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-IEntitySetObserver).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World, DefaultEcs.IEntitySetObserver)')
- [#ctor(DefaultEcs.World, DefaultEcs.IEntitySetObserver, DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-IEntitySetObserver-_DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World, DefaultEcs.IEntitySetObserver, DefaultEcs.System.SystemRunner&lt;T&gt;)')
- [#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;)](./DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-T-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;)')
### Properties
- [IsEnabled](./DefaultEcs-System-AEntitySystem-T--IsEnabled.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.IsEnabled')
### Methods
- [Dispose()](./DefaultEcs-System-AEntitySystem-T--Dispose().md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Dispose()')
- [Update(T, DefaultEcs.Entity)](./DefaultEcs-System-AEntitySystem-T--Update(T-_DefaultEcs-Entity).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, DefaultEcs.Entity)')
- [Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)](./DefaultEcs-System-AEntitySystem-T--Update(T-_System-ReadOnlySpan-DefaultEcs-Entity-).md 'DefaultEcs.System.AEntitySystem&lt;T&gt;.Update(T, System.ReadOnlySpan&lt;DefaultEcs.Entity&gt;)')
