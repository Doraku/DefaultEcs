### [DefaultEcs](./DefaultEcs.md 'DefaultEcs')
### [DefaultEcs.System.AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;')
## #ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;) `constructor`
Initialise a new instance of the [DefaultEcs.System.AEntitySystem&lt;T&gt;](./DefaultEcs-System-AEntitySystem-T-.md 'DefaultEcs.System.AEntitySystem&lt;T&gt;') class with the given [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World').<br/>To create the inner [DefaultEcs.EntitySet](./DefaultEcs-EntitySet.md 'DefaultEcs.EntitySet'), [DefaultEcs.System.WithAttribute](./DefaultEcs-System-WithAttribute.md 'DefaultEcs.System.WithAttribute') and [DefaultEcs.System.WithoutAttribute](./DefaultEcs-System-WithoutAttribute.md 'DefaultEcs.System.WithoutAttribute') attributes will be used.
### Parameters

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-T-)-world'></a>
`world`
>The [DefaultEcs.World](./DefaultEcs-World.md 'DefaultEcs.World') from which to get the [DefaultEcs.Entity](./DefaultEcs-Entity.md 'DefaultEcs.Entity') instances to process the update.

<a name='DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-T-)-runner'></a>
`runner`
>The [DefaultEcs.System.SystemRunner&lt;T&gt;](./DefaultEcs-System-SystemRunner-T-.md 'DefaultEcs.System.SystemRunner&lt;T&gt;') used to process the update in parallel if not null.
### Exceptions

[System.ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/System.ArgumentNullException 'System.ArgumentNullException')
>[world](#DefaultEcs-System-AEntitySystem-T---ctor(DefaultEcs-World-_DefaultEcs-System-SystemRunner-T-)-world 'DefaultEcs.System.AEntitySystem&lt;T&gt;.#ctor(DefaultEcs.World, DefaultEcs.System.SystemRunner&lt;T&gt;).world') is null.
